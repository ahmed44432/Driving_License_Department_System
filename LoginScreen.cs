using System;
using System.IO;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {

        }

        private void lnbMoreInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Browser browser = new Browser();
            browser.Show();
        }

        string path = @"C:\Users\DELL\source\repos\DVLD\UsersFastLogin";
        string line;

        private void 

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {

                if (clsUserBusinessLayer.IsUserExistes(txbUN.Text, txbPS.Text))
                {
                    MessageBox.Show("welcome :)");
                    if(chkRM.Checked)
                    {

                        line = txbUN.Text + "##" + txbPS.Text;    
                        File.AppendAllText(path,line);
                          

                    }

                }
                else
                {
                    MessageBox.Show("Fuck of");
                }
            }


        }

        private bool IsValid()
        {
            bool isvalid = true;

            if (string.IsNullOrWhiteSpace(txbUN.Text))
            {
               
                isvalid= false;
                errorProvider1.SetError(txbUN, "User Name is Empty");
            }
            else
            {
                errorProvider1.SetError(txbUN, "");
            }

            if (string.IsNullOrWhiteSpace(txbPS.Text))
            {
                isvalid= false;
                errorProvider1.SetError(txbPS, "Password is Empty");
            }
            else
            {
                errorProvider1.SetError(txbPS, "");
            }

            if (!isvalid) { System.Media.SystemSounds.Exclamation.Play(); }

            return isvalid;
        }
    }
}
