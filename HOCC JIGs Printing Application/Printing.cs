using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;
using System.Drawing.Imaging;
using System.CodeDom.Compiler;
using HOCC_JIGs_Printing_Application;

namespace Printing_and_BitMap
{
    class LogAndSerial
    {
        //internal string temp;
        public long SerialNumber;

        //Class constructor, receives Item number from serial, the result based on data received from serial & the Log file location
        public LogAndSerial(string Itemnumber, string Result, string LogFileLocation, string SerialsFileLocation, int weeknumber)
        {
            SerialNumber = 0;
            List<string> SerialFileData = new List<string>();
            List<string> LogFileData = new List<string>();

            //Saves contents of txt file containing last serial for each item number to SerialFileData List
            if (Result == "p")
            {
                try { SerialFileData.AddRange(File.ReadAllLines(SerialsFileLocation)); }
                catch (Exception e1) { MessageBox.Show(e1.Message,"Exception Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                for (int i_SerialFileLoop = 0; i_SerialFileLoop < SerialFileData.Count; i_SerialFileLoop++)
                {
                    if (SerialFileData[i_SerialFileLoop].Contains(Itemnumber) == true)
                    {
                        //Splits the found result to extract the last serial number then converts it to long int, then adds 1 
                        //to the found serial number
                        
                        string[] m_splitserial = SerialFileData[i_SerialFileLoop].Split(';');
                        if (Itemnumber == "NA")
                        {
                            SerialNumber = Convert.ToInt32(m_splitserial[1]) + 1;
                            //Saves the modified found line in the list (item no.;new serial no.), then saves the whole list in txt file
                            SerialFileData[i_SerialFileLoop] = m_splitserial[0] + ";" + Convert.ToString(SerialNumber) + ";" + Convert.ToString(weeknumber);
                            File.WriteAllLines(SerialsFileLocation, SerialFileData); break;
                        }
                        else if (HOCC_JIGs_Printing_Application.Properties.Settings.Default.currentweek == Convert.ToInt32(m_splitserial[2]) && Itemnumber!="NA")
                        {
                            SerialNumber = Convert.ToInt32(m_splitserial[1]) + 1;
                            //Saves the modified found line in the list (item no.;new serial no.), then saves the whole list in txt file
                            SerialFileData[i_SerialFileLoop] = m_splitserial[0] + ";" + Convert.ToString(SerialNumber) + ";" + Convert.ToString(weeknumber);
                            File.WriteAllLines(SerialsFileLocation, SerialFileData); break;
                        }
                        else if (HOCC_JIGs_Printing_Application.Properties.Settings.Default.currentweek != Convert.ToInt32(m_splitserial[2]) && Itemnumber != "NA")
                        {
                            HOCC_JIGs_Printing_Application.Properties.Settings.Default.currentweek = weeknumber;
                            HOCC_JIGs_Printing_Application.Properties.Settings.Default.Save();
                            SerialNumber = 1;
                            //Saves the modified found line in the list (item no.;new serial no.), then saves the whole list in txt file
                            SerialFileData[i_SerialFileLoop] = m_splitserial[0] + ";" + Convert.ToString(SerialNumber) + ";" + Convert.ToString(weeknumber);
                            File.WriteAllLines(SerialsFileLocation, SerialFileData); break;
                        }
                    }
                    //If the item no. was not found in the serials file
                    else if (SerialFileData[i_SerialFileLoop] == "*")
                    {
                        HOCC_JIGs_Printing_Application.Properties.Settings.Default.currentweek = weeknumber;
                        HOCC_JIGs_Printing_Application.Properties.Settings.Default.Save();
                        //A new line is created in the list (item no.;new serial "1"), adds "*" as the last symbol in the file
                        //& then saves the whole list in txt file
                        if(Itemnumber == "NA") { SerialNumber = 100000; }
                        else { SerialNumber = 1; }
                        SerialFileData[i_SerialFileLoop] = Itemnumber + ";" + Convert.ToString(SerialNumber) + ";" + Convert.ToString(weeknumber);
                        SerialFileData.Add("*");
                        File.WriteAllLines(SerialsFileLocation, SerialFileData); break;
                    }
                }
                SerialFileData.Clear(); //Clears the whole list after the process to reduce resources
            }

            //Check first wether the Log file is already created 
            if (File.Exists(LogFileLocation) is true)
            {
                //Saves contents of txt file containing last serial for each item number to SerialFileData List
                LogFileData.AddRange(File.ReadAllLines(LogFileLocation));
                for (int i_LogFileLoop = 0; i_LogFileLoop < LogFileData.Count; i_LogFileLoop++)
                {
                    if (LogFileData[i_LogFileLoop].Contains(Itemnumber) is true)
                    {
                        //Splits the found result to extract the pass & fail values that was recorded during the present day
                        string[] m_spiltLog = LogFileData[i_LogFileLoop].Split(';');
                        int Passvalue = Convert.ToInt32(m_spiltLog[2].Substring(m_spiltLog[2].IndexOf(':') + 1));
                        int Failvalue = Convert.ToInt32(m_spiltLog[3].Substring(m_spiltLog[3].IndexOf(':') + 1));
                        //Adds to present number depending on the received result character
                        if (Result == "p") { Passvalue++; } else if (Result == "f") { Failvalue++; }
                        //Modifies the list member to add the new result, then saves the whole list in txt file
                        LogFileData[i_LogFileLoop] = $"{Itemnumber};Total:{Passvalue + Failvalue};Pass:{Passvalue};Fail:{Failvalue}";
                        if (Result == "p") { LogFileData.Insert(++i_LogFileLoop, $"Serial:{SerialNumber};{DateTime.Now}"); }
                        File.WriteAllLines(LogFileLocation, LogFileData); break;
                    }
                    //If the item no. was not found in the Log file
                    else if (LogFileData[i_LogFileLoop] == "*")
                    {
                        //A new line is created in the list depending on the found result recevied, adds "*" as the last  
                        //symbol in the file & then saves the whole list in txt file
                        if (Result == "p")
                        {
                            LogFileData.Insert(LogFileData.IndexOf("*"), $"{Itemnumber};Total:{1};Pass:{1};Fail:{0}");
                            LogFileData.Insert(LogFileData.IndexOf("*"), $"Serial:{SerialNumber};{DateTime.Now}");
                            LogFileData.Insert(LogFileData.IndexOf("*"), "-------------------------------");
                        }
                        else if (Result == "f")
                        {
                            LogFileData.Insert(LogFileData.IndexOf("*"), $"{Itemnumber};Total:{1};Pass:{0};Fail:{1}");
                            LogFileData.Insert(LogFileData.IndexOf("*"), "-------------------------------");
                        }
                        File.WriteAllLines(LogFileLocation, LogFileData); break;
                    }
                }
                LogFileData.Clear();
            }
            //If the file was not found, it creates one with the present date, then A new line is created in the list   
            //depending on the found result recevied, adds "*" as the last symbol in the file & then saves the whole list to file
            else if (File.Exists(LogFileLocation) is false)
            {
                StreamWriter sr_LogFile = new StreamWriter(LogFileLocation); sr_LogFile.Close();
                if (Result == "p")
                {
                    LogFileData.Add($"{Itemnumber};Total:{1};Pass:{1};Fail:{0}");
                    LogFileData.Add($"Serial:{SerialNumber};{DateTime.Now}");
                    LogFileData.Add("-------------------------------"); LogFileData.Add("*");
                }
                else if (Result == "f")
                {
                    LogFileData.Add($"{Itemnumber};Total:{1};Pass:{0};Fail:{1}");
                    LogFileData.Add("-------------------------------"); LogFileData.Add("*");
                }
                File.WriteAllLines(LogFileLocation, LogFileData);
                LogFileData.Clear();
            }
        }
    }


    class ImagesPreview
    {

        //Method that creates & returns the bitmap image of the Encryption Label to be printed, the Method receives
        //the item number & the description
        public Bitmap EncryptionImagePreview(string ItemNumber, string Description, long SerialNumber)
        {
            
            //Creates a new bitmap object with the label dimensions, a new font object to standardize the font preferences,
            //a new brush object to standardize the brush preferences & finally a new stringformat object to be used for the 
            //serial number entry only to set the drawing to be aligned at the far right area of the label
            Bitmap EncryptionPreviewLabel = new Bitmap(250, 38);
            Font PreviewFont = new Font("Calibri", 10, FontStyle.Bold);
            Brush PreviewBrush = Brushes.Black;
            StringFormat PreviewFormat = new StringFormat(); PreviewFormat.Alignment = StringAlignment.Far;

            //Create a new Graphics object to start drawing on the created bitmap image using drawstring
            using (Graphics ImageCreator = Graphics.FromImage(EncryptionPreviewLabel))
            {
                ImageCreator.DrawString(ItemNumber, PreviewFont, PreviewBrush, 5, 5); //Draw Item Number on bitmap
                ImageCreator.DrawString("(73267)", PreviewFont, PreviewBrush, 105, 5);
                ImageCreator.DrawString("HS", PreviewFont, PreviewBrush, Convert.ToInt32(ImageCreator.MeasureString("(73267)", PreviewFont).Width) + 100, 5);
                //Draw the YY/WW  numbers on the bitmap, with respect to the measuredstring for (HS & (73267))
                ImageCreator.DrawString(DateTime.Now.ToString("yy") + "/" + new GregorianCalendar(GregorianCalendarTypes.Localized).GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday),
                    PreviewFont, PreviewBrush,
                    Convert.ToInt32(ImageCreator.MeasureString("(73267)", PreviewFont).Width) + Convert.ToInt32(ImageCreator.MeasureString("HS", PreviewFont).Width) + 95, 5);
                //Draw the Serial Number on the far right corner of the label
                ImageCreator.DrawString(Convert.ToString(SerialNumber), PreviewFont, PreviewBrush, 250, 5, PreviewFormat);
                ImageCreator.DrawString(Description, PreviewFont, PreviewBrush, 5, 18);   //Draw  Description on the bitmap
            }
            return EncryptionPreviewLabel;
        }

        public Bitmap CheckedImagePreview(string[] CheckedLabelData)
        {
            //Creates a new bitmap object with the label dimensions, a new font object to standardize the font preferences,
            //a new brush object to standardize the brush preferences & finally a new stringformat object to be used for the 
            //serial number entry only to set the drawing to be aligned at the far right area of the label
            Bitmap CheckedPreviewLabel = new Bitmap(250, 38);
            Font PreviewFont = new Font("Calibri", 10, FontStyle.Bold);
            Brush PreviewBrush = Brushes.Black;
            StringFormat PreviewFormat = new StringFormat(); PreviewFormat.Alignment = StringAlignment.Far;

            //Create a new Graphics object to start drawing on the created bitmap image using drawstring
            using (Graphics ImageCreator = Graphics.FromImage(CheckedPreviewLabel))
            {
                ImageCreator.DrawString("C :" + CheckedLabelData[0], PreviewFont, PreviewBrush, 5, 5);
                ImageCreator.DrawString("C :" + CheckedLabelData[1], PreviewFont, PreviewBrush, 110, 5);
                ImageCreator.DrawString("A :" + CheckedLabelData[2], PreviewFont, PreviewBrush, 250, 5, PreviewFormat);
                ImageCreator.DrawString("Test :" + CheckedLabelData[3], PreviewFont, PreviewBrush, 5, 18);
                ImageCreator.DrawString("Checked By :" + CheckedLabelData[4], PreviewFont, PreviewBrush, 250, 18, PreviewFormat);
            }
            return CheckedPreviewLabel;
        }
    }
}