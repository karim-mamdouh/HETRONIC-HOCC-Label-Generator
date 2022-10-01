using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOCC_JIGs_Printing_Application
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void enterpasswordbtn_Click(object sender, EventArgs e)
        {
            if (passwordtxt.Text == Properties.Settings.Default.Password)
            { Properties.Settings.Default.LoginStatus = true; this.Close(); }
            else { MessageBox.Show("Please Enter Correct Password"); }
        }

        private void passwordtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (passwordtxt.Text == Properties.Settings.Default.Password)
                { Properties.Settings.Default.LoginStatus = true; this.Close(); }
                else { MessageBox.Show("Please Enter Correct Password"); }
            }
        }
    }
}
