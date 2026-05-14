using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms
{
    public partial class ChangePassword : Form
    {
        public ChangePassword(clsUserBusinessLayer user)
        {
            InitializeComponent();
            userDetails1.setUserInfo(user);
            _user = user;
        }

        clsUserBusinessLayer _user = new clsUserBusinessLayer();

        private bool _ConfirmingPassword()
        {
            if (_user == null || _user.UserID == -1) { return false; }


            if (string.IsNullOrWhiteSpace(txbCurrentPassword.Text) ||
                txbCurrentPassword.Text != _user.Password)
            {
                errorProvider1.SetError(txbCurrentPassword, "Password is incorrect!");
                return false;
            }
            else
            {
                errorProvider1.SetError(txbCurrentPassword, "");
            }

            
            if (string.IsNullOrWhiteSpace(txbConfirmPassword.Text) ||
                txbNewPassword.Text != txbConfirmPassword.Text)
            {
                errorProvider1.SetError(txbConfirmPassword, "Password Unmatched Or Empty");
                return false;
            }
            else
            {
                errorProvider1.SetError(txbConfirmPassword, "");
            }

           
            return true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_user == null || _user.UserID == -1) { return ; }
            if (_ConfirmingPassword())
            {
                _user.Password = txbNewPassword.Text;
                if (_user.Save())
                {
                    MessageBox.Show("User Saved successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("User Saved Failed", "", MessageBoxButtons.OK
                        , MessageBoxIcon.Error);

                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
