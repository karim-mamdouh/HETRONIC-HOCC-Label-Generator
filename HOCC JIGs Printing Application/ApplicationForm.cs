using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Drawing.Printing;
using Printing_and_BitMap;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Configuration;
using Printers_Form;

namespace HOCC_JIGs_Printing_Application
{
    public partial class ApplicationForm : Form
    {
        internal long Serial;
        internal bool Blinking = true;
        internal string Receivedserialdata;
        internal string Description;
        internal string ItemNumber;
        internal string[] ports;
        internal string[] CheckedLabelData = new string[0];
        internal List<string> Itemsfiledata = new List<string>();


        public ApplicationForm()
        {
            InitializeComponent();
        }

        public void serialthread()  //Thread Method, recevies the selected COM Port name
        {
            //First the serial keeps waiting to read from the buffer & saves the recevied data in the Receivedserialdata variable
            while (true)
            {
                try
                {
                    serial.DiscardInBuffer(); serial.DiscardOutBuffer();
                    if (serial.IsOpen is true)
                    {
                        Receivedserialdata = serial.ReadLine(); serial.DiscardInBuffer(); serial.DiscardOutBuffer();
                        //Then it searches for the recevied data in the Itemsfiledata list that contains the data of the items file
                        //If a match was found it; it saves it in the Description variable & show it on the RecveiedItemLbl
                        //then creates a new object of the class PrintingData & finally it saves the image generated from the
                        //EncryptionImage Method to bitmap variable Label, then executes the printing process for the Label
                        for (int i_itemsfiledataloop = 0; i_itemsfiledataloop < Itemsfiledata.Count; i_itemsfiledataloop++)
                        {
                            if (Itemsfiledata[i_itemsfiledataloop].Substring(0, Itemsfiledata[i_itemsfiledataloop].IndexOf(',')) == Receivedserialdata)
                            {
                                ItemNumber = Itemsfiledata[i_itemsfiledataloop].Substring(0, Itemsfiledata[i_itemsfiledataloop].IndexOf(','));
                                Description = Itemsfiledata[i_itemsfiledataloop].Substring(Itemsfiledata[i_itemsfiledataloop].IndexOf(',') + 1);
                                RecveiedItemLbl.Invoke(new Action(() =>
                                {
                                    RecveiedItemLbl.Text = Receivedserialdata; RecveiedItemLbl.Visible = true;
                                }));
                                Thread.Sleep(25);
                                //Sends "r" to check the testing result of the harness & then reads the serial buffer
                                serial.WriteLine("r"); Receivedserialdata = serial.ReadLine(); serial.DiscardInBuffer(); serial.DiscardOutBuffer();
                                if (Receivedserialdata == "p" || Receivedserialdata == "f")
                                {

                                    LogAndSerial LogAndSerialConstructor = new LogAndSerial(RecveiedItemLbl.Text, Receivedserialdata,
                                        Properties.Settings.Default.logfolderlocation + $"/{DateTime.Today.Date.ToShortDateString()}.txt",
                                        Properties.Settings.Default.serialsfilelocation, new GregorianCalendar(GregorianCalendarTypes.Localized).GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday));
                                    ImagesPreview ImagesPreviewConstructor = new ImagesPreview();
                                    if (Receivedserialdata == "p" && CheckedLabelData.Length == 5)
                                    {
                                        Thread.Sleep(25);
                                        serial.WriteLine("d");
                                        Invoke(new Action(() =>
                                        {
                                            try
                                            {
                                                Serial = LogAndSerialConstructor.SerialNumber;
                                                EncryptionLabelPreviewBox.Image = ImagesPreviewConstructor.EncryptionImagePreview(RecveiedItemLbl.Text, Description, Serial);
                                                EncryptionLabelPreviewBox.Visible = true;
                                                CheckedLabelPreviewBox.Image = ImagesPreviewConstructor.CheckedImagePreview(CheckedLabelData);
                                                CheckedLabelPreviewBox.Visible = true;
                                                if (ItemNumber == "NA")
                                                {
                                                    CCDocument.DefaultPageSettings.PaperSize = new PaperSize("CC Label", 168, 35);
                                                    CCDocument.DocumentName = "CC Label";
                                                    CCDocument.PrinterSettings.PrinterName = Properties.Settings.Default.PrinterName;
                                                    CCDocument.Print();
                                                }
                                                else
                                                {
                                                    EncryptionDocument.DefaultPageSettings.PaperSize = new PaperSize("Encryption Label", 168, 35);
                                                    EncryptionDocument.DocumentName = "Encryption Label";
                                                    EncryptionDocument.PrinterSettings.PrinterName = Properties.Settings.Default.PrinterName;
                                                    CheckedDocument.DefaultPageSettings.PaperSize = new PaperSize("Checked Label", 168, 35);
                                                    CheckedDocument.DocumentName = "Checked Label";
                                                    CheckedDocument.PrinterSettings.PrinterName = Properties.Settings.Default.PrinterName;
                                                    EncryptionDocument.Print(); CheckedDocument.Print();
                                                }
                                            }
                                            catch(Exception ex) { MessageBox.Show(ex.Message, "Exception Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                        })); break;
                                    }
                                    else if (Receivedserialdata == "f")
                                    {
                                        Invoke(new Action(() =>
                                        {
                                            RecveiedItemLbl.Visible = false; EncryptionLabelPreviewBox.Visible = false; CheckedLabelPreviewBox.Visible = false;
                                        })); break;
                                    }
                                }
                            }
                            else if (Itemsfiledata[i_itemsfiledataloop] == "*") { break; }
                        }
                    }

                    Thread.Sleep(25);
                }
                catch (Exception e4) { MessageBox.Show(e4.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }


        private void ApplicationForm_Load(object sender, EventArgs e)
        {
            //On Form load the combobox is loaded with the available COM Port names, sets the icon & text is updated with the current version
            this.Text = "Label Printing v" + Application.ProductVersion.Substring(0, Application.ProductVersion.LastIndexOf("."));
            this.Icon = Icon.ExtractAssociatedIcon(AppDomain.CurrentDomain.FriendlyName);
            ports = SerialPort.GetPortNames();
            for (int i_PortsFillLoop = 0; i_PortsFillLoop < ports.Length; i_PortsFillLoop++)
            { ComPortList.Items.Add(ports[i_PortsFillLoop]); }
            Properties.Settings.Default.LoginStatus = false;
        }

        private void comportrefresh_Click(object sender, EventArgs e)   //COM Refresh Button Event
        {
            //The combobox is cleared & then reloaded with the avilable COM Port names
            ComPortList.Items.Clear();
            ports = SerialPort.GetPortNames();
            for (int i_PortsFillLoop = 0; i_PortsFillLoop < ports.Length; i_PortsFillLoop++)
            { ComPortList.Items.Add(ports[i_PortsFillLoop]); }
        }

        private void comportopen_Click(object sender, EventArgs e)  //COM Open Button Event
        {
            //When the button is clicked it reads the contents of the items file & save it to the Itemsfiledata list
            //then opens a new thread for serial & sends to it the selected COM Port name
            if (serial.IsOpen is true)
            { MessageBox.Show($"{serial.PortName} is already opened" + Environment.NewLine + $"مفتوح مسبقا {serial.PortName}", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            else if (ComPortList.Text != "" && CheckedLabelData.Length is 5)
            {
                try { Itemsfiledata.AddRange(File.ReadAllLines(Properties.Settings.Default.itemsfilelocation)); }
                catch (Exception e2) { MessageBox.Show(e2.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                try { serial.PortName = ComPortList.Text; serial.BaudRate = 9600; serial.Open(); }
                catch (Exception e3) { MessageBox.Show(e3.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                Thread serialThread = new Thread(() => serialthread());
                serialThread.Start(); serial.DiscardInBuffer();
                serialThread.IsBackground = true; ComPortGreenTimr.Enabled = true;
                ComPortList.Enabled = false; ComPortOpenBtn.Enabled = false;
                this.WindowState = FormWindowState.Minimized;
            }
            else if (CheckedLabelData.Length < 5)
            { MessageBox.Show("Please Fill Label Data First" + Environment.NewLine + " من فضلك قم بملء البيانات اولا", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            else
            { MessageBox.Show("Please select COM Port first" + Environment.NewLine + "اولا COM من فضلك قم بأختيار ال", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        }

        private void SaveBtn_Click(object sender, EventArgs e)  //Save Button Event
        {
            //First it checks if the entered letters in all textboxes contain 2 characters then saves all the textboxes data
            //in the CheckedLabelData array
            if (C1txt.Text.Length is 2 && C2txt.Text.Length is 2 && Atxt.Text.Length is 2 && Testtxt.Text.Length is 2
                && Checkedtxt.Text.Length is 2)
            {
                if (MessageBox.Show("Are you sure?" + Environment.NewLine + "هل انت متأكد؟",
                "Confirmation Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CheckedLabelData = new string[5];
                    CheckedLabelData[0] = C1txt.Text;
                    CheckedLabelData[1] = C2txt.Text;
                    CheckedLabelData[2] = Atxt.Text;
                    CheckedLabelData[3] = Testtxt.Text;
                    CheckedLabelData[4] = Checkedtxt.Text;
                    SaveBtn.Enabled = false;
                }
            }
            else { MessageBox.Show("Please Enter Data Correctly" + Environment.NewLine + "من فضلك قم بأدخل البيانات بشكل صحيح", "Error Message"); }
        }

        private void changeLogFileLocationToolStripMenuItem_Click(object sender, EventArgs e)   //Change Log Location Strip Button Event
        {
            //First you are required to login then select the folder location to save the log files
            CommonOpenFileDialog LogFolder = new CommonOpenFileDialog(); LogFolder.IsFolderPicker = true;
            if (Properties.Settings.Default.LoginStatus is false)
            {
                LoginForm form = new LoginForm(); form.ShowDialog();
                if (Properties.Settings.Default.LoginStatus is true && LogFolder.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    Properties.Settings.Default.logfolderlocation = LogFolder.FileName;
                    Properties.Settings.Default.Save();
                }
            }
            else if (Properties.Settings.Default.LoginStatus is true && LogFolder.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Properties.Settings.Default.logfolderlocation = LogFolder.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void changeItemsFileLocationToolStripMenuItem_Click(object sender, EventArgs e) //Change Items File Location Strip Button Event
        {
            //First you are required to login then select the file containing the itemnumbers & their description
            if (Properties.Settings.Default.LoginStatus is false)
            {
                LoginForm form = new LoginForm(); form.ShowDialog();
                if (Properties.Settings.Default.LoginStatus is true && ItemsFileLocation.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.itemsfilelocation = ItemsFileLocation.FileName;
                    Properties.Settings.Default.Save();
                }
            }
            else if (Properties.Settings.Default.LoginStatus is true && ItemsFileLocation.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.itemsfilelocation = ItemsFileLocation.FileName;
                Properties.Settings.Default.Save();
            }

        }

        private void changeSerialsFileLocationToolStripMenuItem_Click(object sender, EventArgs e)   //Change Serials File Location Strip Button
        {
            //First you are required to login then select the file containing the serials saved for the items
            if (Properties.Settings.Default.LoginStatus is false)
            {
                LoginForm form = new LoginForm(); form.ShowDialog();
                if (Properties.Settings.Default.LoginStatus is true && ItemsFileLocation.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.serialsfilelocation = ItemsFileLocation.FileName;
                    Properties.Settings.Default.Save();
                }
            }
            else if (Properties.Settings.Default.LoginStatus is true && ItemsFileLocation.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.serialsfilelocation = ItemsFileLocation.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void ComPortGreenTimr_Tick(object sender, EventArgs e)  //Blinking Timer Event
        {
            if (Blinking == true) { ComPortOpenIndicator.BackColor = Color.Yellow; Blinking = false; }
            else if (Blinking == false) { ComPortOpenIndicator.BackColor = Color.Black; Blinking = true; }
        }

        private void EncryptionDocument_PrintPage(object sender, PrintPageEventArgs e)  //Encryption Label Printing Event
        {

            //Creates a new font object to standardize the font preferences, a new brush object to standardize the brush preferences
            //& finally a new stringformat object to be used for the serial number entry only to set the drawing to be aligned
            //at the far right area of the label
            Font EncryptionFont = new Font("Times New Roman", 5.2F, FontStyle.Bold);
            Brush EncryptionBrush = Brushes.Black;
            StringFormat EncryptionFormat = new StringFormat(); EncryptionFormat.Alignment = StringAlignment.Far;

            //Draws the itemnumber, serial, description, YY/WW & fixed number on the event to be printed on the label
            e.Graphics.DrawString(ItemNumber, EncryptionFont, EncryptionBrush, 3, 8);
            e.Graphics.DrawString("(73267)", EncryptionFont, EncryptionBrush, 66, 8);
            e.Graphics.DrawString("HS", EncryptionFont, EncryptionBrush, 65 + e.Graphics.MeasureString("(73267)", EncryptionFont).Width, 8);
            e.Graphics.DrawString(DateTime.Now.ToString("yy") + "/" + Convert.ToString(new GregorianCalendar(GregorianCalendarTypes.Localized).GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday)),
                EncryptionFont, EncryptionBrush, 63 + e.Graphics.MeasureString("(73267)", EncryptionFont).Width +
                e.Graphics.MeasureString("HS", EncryptionFont).Width, 8);
            e.Graphics.DrawString(Convert.ToString(Serial), EncryptionFont, EncryptionBrush, 153, 8, EncryptionFormat);
            e.Graphics.DrawString(Description, EncryptionFont, EncryptionBrush, 3, 22);
        }

        private void CheckedDocument_PrintPage(object sender, PrintPageEventArgs e) //Checked Label Printing Event
        {
            //Creates a new font object to standardize the font preferences, a new brush object to standardize the brush preferences
            //& finally a new stringformat object to be used for the serial number entry only to set the drawing to be aligned
            //at the far right area of the label
            Font CheckedFont = new Font("Times New Roman", 5.2F, FontStyle.Bold);
            Brush CheckedBrush = Brushes.Black;
            StringFormat CheckedFormat = new StringFormat(); CheckedFormat.Alignment = StringAlignment.Far;

            //Draws the data entered by the user on th event to be printed on the label
            e.Graphics.DrawString($"C:{CheckedLabelData[0]}", CheckedFont, CheckedBrush, 3, 8);
            e.Graphics.DrawString($"C:{CheckedLabelData[1]}", CheckedFont, CheckedBrush, 66, 8);
            e.Graphics.DrawString($"A:{CheckedLabelData[2]}", CheckedFont, CheckedBrush, 153, 8, CheckedFormat);
            e.Graphics.DrawString($"Test:{CheckedLabelData[3]}", CheckedFont, CheckedBrush, 3, 22);
            e.Graphics.DrawString($"Checked By:{CheckedLabelData[4]}", CheckedFont, CheckedBrush, 70, 22);
        }

        private void CCDocument_PrintPage(object sender, PrintPageEventArgs e) //For itemnumber 1051510020 only
        {

            //Creates a new font object to standardize the font preferences, a new brush object to standardize the brush preferences
            //& finally a new stringformat object to be used for the serial number entry only to set the drawing to be aligned
            //at the far right area of the label
            Font CCFont = new Font("Times New Roman", 8, FontStyle.Bold);
            Brush CCBrush = Brushes.Black;

            //Draws the data entered by the user on th event to be printed on the label
            e.Graphics.DrawString(DateTime.Now.ToString("yy") + Convert.ToString(new GregorianCalendar(GregorianCalendarTypes.Localized).GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday))
               + "-" + Convert.ToString(Serial), CCFont,
                CCBrush, 60, 15);
        }

        private void changeDefaultPrinterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PrintersForm PrntFrm = new PrintersForm())
            {
                if (PrntFrm.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.PrinterName = PrntFrm.PrinterName;
                    Properties.Settings.Default.Save();
                }
            }
        }
    }
}
