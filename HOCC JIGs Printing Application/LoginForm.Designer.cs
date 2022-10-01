namespace HOCC_JIGs_Printing_Application
{
    partial class LoginForm
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
            this.cancelbtn = new System.Windows.Forms.Button();
            this.enterpasswordbtn = new System.Windows.Forms.Button();
            this.passwordtxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelbtn
            // 
            this.cancelbtn.Location = new System.Drawing.Point(16, 127);
            this.cancelbtn.Margin = new System.Windows.Forms.Padding(4);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(112, 41);
            this.cancelbtn.TabIndex = 7;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // enterpasswordbtn
            // 
            this.enterpasswordbtn.Location = new System.Drawing.Point(195, 127);
            this.enterpasswordbtn.Margin = new System.Windows.Forms.Padding(4);
            this.enterpasswordbtn.Name = "enterpasswordbtn";
            this.enterpasswordbtn.Size = new System.Drawing.Size(112, 41);
            this.enterpasswordbtn.TabIndex = 6;
            this.enterpasswordbtn.Text = "OK";
            this.enterpasswordbtn.UseVisualStyleBackColor = true;
            this.enterpasswordbtn.Click += new System.EventHandler(this.enterpasswordbtn_Click);
            // 
            // passwordtxt
            // 
            this.passwordtxt.Location = new System.Drawing.Point(16, 65);
            this.passwordtxt.Margin = new System.Windows.Forms.Padding(4);
            this.passwordtxt.Name = "passwordtxt";
            this.passwordtxt.Size = new System.Drawing.Size(289, 22);
            this.passwordtxt.TabIndex = 5;
            this.passwordtxt.UseSystemPasswordChar = true;
            this.passwordtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordtxt_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter Password";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(320, 185);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.enterpasswordbtn);
            this.Controls.Add(this.passwordtxt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button enterpasswordbtn;
        private System.Windows.Forms.TextBox passwordtxt;
        private System.Windows.Forms.Label label1;
    }
}