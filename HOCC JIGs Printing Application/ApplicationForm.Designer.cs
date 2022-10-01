namespace HOCC_JIGs_Printing_Application
{
    partial class ApplicationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationForm));
            this.ComPortList = new System.Windows.Forms.ComboBox();
            this.ComPortRefreshBtn = new System.Windows.Forms.Button();
            this.ComPortOpenBtn = new System.Windows.Forms.Button();
            this.serial = new System.IO.Ports.SerialPort(this.components);
            this.RecveiedItemLbl = new System.Windows.Forms.Label();
            this.EncryptionDocument = new System.Drawing.Printing.PrintDocument();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SettingsBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.changeItemsFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLogFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeSerialsFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeDefaultPrinterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogFolderLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.ItemsFileLocation = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.C1txt = new System.Windows.Forms.TextBox();
            this.C2txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Atxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Testtxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Checkedtxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.EncryptionLabelPreviewBox = new System.Windows.Forms.PictureBox();
            this.ComPortOpenIndicator = new System.Windows.Forms.PictureBox();
            this.ComPortGreenTimr = new System.Windows.Forms.Timer(this.components);
            this.CheckedLabelPreviewBox = new System.Windows.Forms.PictureBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CheckedDocument = new System.Drawing.Printing.PrintDocument();
            this.CCDocument = new System.Drawing.Printing.PrintDocument();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EncryptionLabelPreviewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComPortOpenIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckedLabelPreviewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ComPortList
            // 
            this.ComPortList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComPortList.FormattingEnabled = true;
            this.ComPortList.Location = new System.Drawing.Point(298, 67);
            this.ComPortList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ComPortList.Name = "ComPortList";
            this.ComPortList.Size = new System.Drawing.Size(125, 25);
            this.ComPortList.TabIndex = 7;
            // 
            // ComPortRefreshBtn
            // 
            this.ComPortRefreshBtn.BackColor = System.Drawing.Color.Maroon;
            this.ComPortRefreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComPortRefreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComPortRefreshBtn.ForeColor = System.Drawing.Color.White;
            this.ComPortRefreshBtn.Location = new System.Drawing.Point(298, 110);
            this.ComPortRefreshBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ComPortRefreshBtn.Name = "ComPortRefreshBtn";
            this.ComPortRefreshBtn.Size = new System.Drawing.Size(68, 32);
            this.ComPortRefreshBtn.TabIndex = 8;
            this.ComPortRefreshBtn.Text = "Refresh";
            this.ComPortRefreshBtn.UseVisualStyleBackColor = false;
            this.ComPortRefreshBtn.Click += new System.EventHandler(this.comportrefresh_Click);
            // 
            // ComPortOpenBtn
            // 
            this.ComPortOpenBtn.BackColor = System.Drawing.Color.Maroon;
            this.ComPortOpenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComPortOpenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComPortOpenBtn.ForeColor = System.Drawing.Color.White;
            this.ComPortOpenBtn.Location = new System.Drawing.Point(385, 110);
            this.ComPortOpenBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ComPortOpenBtn.Name = "ComPortOpenBtn";
            this.ComPortOpenBtn.Size = new System.Drawing.Size(85, 32);
            this.ComPortOpenBtn.TabIndex = 9;
            this.ComPortOpenBtn.Text = "Open Port";
            this.ComPortOpenBtn.UseVisualStyleBackColor = false;
            this.ComPortOpenBtn.Click += new System.EventHandler(this.comportopen_Click);
            // 
            // RecveiedItemLbl
            // 
            this.RecveiedItemLbl.AutoSize = true;
            this.RecveiedItemLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecveiedItemLbl.ForeColor = System.Drawing.Color.White;
            this.RecveiedItemLbl.Location = new System.Drawing.Point(113, 33);
            this.RecveiedItemLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RecveiedItemLbl.Name = "RecveiedItemLbl";
            this.RecveiedItemLbl.Size = new System.Drawing.Size(136, 17);
            this.RecveiedItemLbl.TabIndex = 4;
            this.RecveiedItemLbl.Text = "Recevied Item Label";
            this.RecveiedItemLbl.Visible = false;
            // 
            // EncryptionDocument
            // 
            this.EncryptionDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.EncryptionDocument_PrintPage);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(482, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SettingsBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeItemsFileLocationToolStripMenuItem,
            this.changeLogFileLocationToolStripMenuItem,
            this.changeSerialsFileLocationToolStripMenuItem,
            this.changeDefaultPrinterToolStripMenuItem});
            this.SettingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("SettingsBtn.Image")));
            this.SettingsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(62, 22);
            this.SettingsBtn.Text = "Settings";
            // 
            // changeItemsFileLocationToolStripMenuItem
            // 
            this.changeItemsFileLocationToolStripMenuItem.Name = "changeItemsFileLocationToolStripMenuItem";
            this.changeItemsFileLocationToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.changeItemsFileLocationToolStripMenuItem.Text = "Change Items File Location";
            this.changeItemsFileLocationToolStripMenuItem.Click += new System.EventHandler(this.changeItemsFileLocationToolStripMenuItem_Click);
            // 
            // changeLogFileLocationToolStripMenuItem
            // 
            this.changeLogFileLocationToolStripMenuItem.Name = "changeLogFileLocationToolStripMenuItem";
            this.changeLogFileLocationToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.changeLogFileLocationToolStripMenuItem.Text = "Change Log File Location";
            this.changeLogFileLocationToolStripMenuItem.Click += new System.EventHandler(this.changeLogFileLocationToolStripMenuItem_Click);
            // 
            // changeSerialsFileLocationToolStripMenuItem
            // 
            this.changeSerialsFileLocationToolStripMenuItem.Name = "changeSerialsFileLocationToolStripMenuItem";
            this.changeSerialsFileLocationToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.changeSerialsFileLocationToolStripMenuItem.Text = "Change Serials File Location";
            this.changeSerialsFileLocationToolStripMenuItem.Click += new System.EventHandler(this.changeSerialsFileLocationToolStripMenuItem_Click);
            // 
            // changeDefaultPrinterToolStripMenuItem
            // 
            this.changeDefaultPrinterToolStripMenuItem.Name = "changeDefaultPrinterToolStripMenuItem";
            this.changeDefaultPrinterToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.changeDefaultPrinterToolStripMenuItem.Text = "Change Default Printer";
            this.changeDefaultPrinterToolStripMenuItem.Click += new System.EventHandler(this.changeDefaultPrinterToolStripMenuItem_Click);
            // 
            // ItemsFileLocation
            // 
            this.ItemsFileLocation.DefaultExt = "txt";
            this.ItemsFileLocation.Filter = "Text files (*.txt)|*.txt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(45, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Item No.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "C:";
            // 
            // C1txt
            // 
            this.C1txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.C1txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C1txt.Location = new System.Drawing.Point(31, 67);
            this.C1txt.MaxLength = 2;
            this.C1txt.Name = "C1txt";
            this.C1txt.Size = new System.Drawing.Size(44, 22);
            this.C1txt.TabIndex = 1;
            // 
            // C2txt
            // 
            this.C2txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.C2txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C2txt.Location = new System.Drawing.Point(128, 67);
            this.C2txt.MaxLength = 2;
            this.C2txt.Name = "C2txt";
            this.C2txt.Size = new System.Drawing.Size(44, 22);
            this.C2txt.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(105, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "C:";
            // 
            // Atxt
            // 
            this.Atxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Atxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Atxt.Location = new System.Drawing.Point(226, 68);
            this.Atxt.MaxLength = 2;
            this.Atxt.Name = "Atxt";
            this.Atxt.Size = new System.Drawing.Size(44, 22);
            this.Atxt.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(204, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "A:";
            // 
            // Testtxt
            // 
            this.Testtxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Testtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Testtxt.Location = new System.Drawing.Point(47, 113);
            this.Testtxt.MaxLength = 2;
            this.Testtxt.Name = "Testtxt";
            this.Testtxt.Size = new System.Drawing.Size(44, 22);
            this.Testtxt.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 116);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Test:";
            // 
            // Checkedtxt
            // 
            this.Checkedtxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Checkedtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Checkedtxt.Location = new System.Drawing.Point(226, 114);
            this.Checkedtxt.MaxLength = 2;
            this.Checkedtxt.Name = "Checkedtxt";
            this.Checkedtxt.Size = new System.Drawing.Size(44, 22);
            this.Checkedtxt.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(129, 117);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Checked By:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.InitialImage = null;
            this.pictureBox3.Location = new System.Drawing.Point(268, 189);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(214, 115);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(337, 34);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "COM Port";
            // 
            // EncryptionLabelPreviewBox
            // 
            this.EncryptionLabelPreviewBox.BackColor = System.Drawing.Color.White;
            this.EncryptionLabelPreviewBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EncryptionLabelPreviewBox.Location = new System.Drawing.Point(7, 198);
            this.EncryptionLabelPreviewBox.Name = "EncryptionLabelPreviewBox";
            this.EncryptionLabelPreviewBox.Size = new System.Drawing.Size(256, 42);
            this.EncryptionLabelPreviewBox.TabIndex = 22;
            this.EncryptionLabelPreviewBox.TabStop = false;
            this.EncryptionLabelPreviewBox.Visible = false;
            // 
            // ComPortOpenIndicator
            // 
            this.ComPortOpenIndicator.Location = new System.Drawing.Point(435, 68);
            this.ComPortOpenIndicator.Name = "ComPortOpenIndicator";
            this.ComPortOpenIndicator.Size = new System.Drawing.Size(34, 25);
            this.ComPortOpenIndicator.TabIndex = 23;
            this.ComPortOpenIndicator.TabStop = false;
            // 
            // ComPortGreenTimr
            // 
            this.ComPortGreenTimr.Tick += new System.EventHandler(this.ComPortGreenTimr_Tick);
            // 
            // CheckedLabelPreviewBox
            // 
            this.CheckedLabelPreviewBox.BackColor = System.Drawing.Color.White;
            this.CheckedLabelPreviewBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CheckedLabelPreviewBox.Location = new System.Drawing.Point(7, 262);
            this.CheckedLabelPreviewBox.Name = "CheckedLabelPreviewBox";
            this.CheckedLabelPreviewBox.Size = new System.Drawing.Size(256, 42);
            this.CheckedLabelPreviewBox.TabIndex = 24;
            this.CheckedLabelPreviewBox.TabStop = false;
            this.CheckedLabelPreviewBox.Visible = false;
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.DarkOrange;
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.Color.White;
            this.SaveBtn.Location = new System.Drawing.Point(103, 144);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(68, 25);
            this.SaveBtn.TabIndex = 6;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(44, 179);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "Encryption Label Preview";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(51, 243);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(171, 16);
            this.label9.TabIndex = 26;
            this.label9.Text = "Checked Label Preview";
            // 
            // CheckedDocument
            // 
            this.CheckedDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.CheckedDocument_PrintPage);
            // 
            // CCDocument
            // 
            this.CCDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.CCDocument_PrintPage);
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(482, 308);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.CheckedLabelPreviewBox);
            this.Controls.Add(this.ComPortOpenIndicator);
            this.Controls.Add(this.EncryptionLabelPreviewBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Checkedtxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Testtxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Atxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.C2txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.C1txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.RecveiedItemLbl);
            this.Controls.Add(this.ComPortOpenBtn);
            this.Controls.Add(this.ComPortRefreshBtn);
            this.Controls.Add(this.ComPortList);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "ApplicationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Label Printing";
            this.Load += new System.EventHandler(this.ApplicationForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EncryptionLabelPreviewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComPortOpenIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckedLabelPreviewBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox ComPortList;
        private System.Windows.Forms.Button ComPortRefreshBtn;
        private System.Windows.Forms.Button ComPortOpenBtn;
        private System.IO.Ports.SerialPort serial;
        private System.Windows.Forms.Label RecveiedItemLbl;
        private System.Drawing.Printing.PrintDocument EncryptionDocument;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton SettingsBtn;
        private System.Windows.Forms.ToolStripMenuItem changeItemsFileLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeLogFileLocationToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog LogFolderLocation;
        private System.Windows.Forms.OpenFileDialog ItemsFileLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox C1txt;
        private System.Windows.Forms.TextBox C2txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Atxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Testtxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Checkedtxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox EncryptionLabelPreviewBox;
        private System.Windows.Forms.PictureBox ComPortOpenIndicator;
        private System.Windows.Forms.Timer ComPortGreenTimr;
        private System.Windows.Forms.PictureBox CheckedLabelPreviewBox;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Drawing.Printing.PrintDocument CheckedDocument;
        private System.Windows.Forms.ToolStripMenuItem changeSerialsFileLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeDefaultPrinterToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument CCDocument;
    }
}

