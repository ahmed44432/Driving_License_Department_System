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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.MainForms.MainRelatedForms
{
    public partial class AddingUser : UserControl
    {
        public AddingUser()
        {
            InitializeComponent();
            filter1.FilterDataBack += DataResever;
            Alltabs.Selecting += tabControl1_Selecting;

        }

        public delegate void ReturnType(bool type);
        public event ReturnType onGivingUserObj;
        clsUserBusinessLayer _user = new clsUserBusinessLayer();
        clsPeopleBusinessLayer _person;
        bool _lockLoginTab = true;
        bool Type = false; //false = Add Mode; True = Update Mode;

        public void DataResever (clsPeopleBusinessLayer person)
        {
            personDetails1.setinfo(person);
            lbUserID.Text = "???";
            txbUserName.Text = "";
            txbPassword.Text = "";
            txbConfirmPassword.Text = "";

            if (person== null || person.ID == -1)
            {
                MessageBox.Show("Person Not Found");
                _lockLoginTab = true;
            }
           _person = person;
            
        }

        private bool _CheckingUserName()
        {
            if (_user != null) {
                if (txbUserName.Text == _user.UserName)
                {
                    errorProvider1.SetError(txbUserName, "");
                    return true;
                }
            }
            if (string.IsNullOrWhiteSpace(txbUserName.Text) || 
                clsUserBusinessLayer.IsUserExistes(txbUserName.Text))
            {
                errorProvider1
                    .SetError(txbUserName, "user name is empty or alredy used");
                return false;
            }
            else
            {
                errorProvider1.SetError(txbUserName, "");
                return true;
            }
        }

        private bool _ConfirmingPassword()
        {
            if (string.IsNullOrWhiteSpace(txbConfirmPassword.Text) || 
                (txbPassword.Text != txbConfirmPassword.Text))
            {
                errorProvider1
                    .SetError(txbConfirmPassword, "Password Unmatched Or Empty");
                return false;
            }
            else
            {
                errorProvider1.SetError(txbConfirmPassword, "");
                return true;
            }
        }


        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabLoginInfo && _lockLoginTab)
            {
                e.Cancel = true; // يمنع الانتقال
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (clsUserBusinessLayer.IsUserLinked(_person.ID))
            {
                Alltabs.SelectedTab = tabPersonalInfo;
                _lockLoginTab = true;
                lbUserID.Text = "???";
                MessageBox.Show(
               @"This user cannot be Updated because it is linked to existing records in the system."
                   , "special user", MessageBoxButtons.OK, MessageBoxIcon.Information);
                onGivingUserObj?.Invoke(false);

                return;
            }

            if (clsUserBusinessLayer.IsUserExistes(_person.ID))
            {
                _user = clsUserBusinessLayer.GetUserByPersonID(_person.ID);
                _lockLoginTab = false;
                lbUserID.Text = _user.PersonID.ToString();
                txbUserName.Text = _user.UserName;
                txbPassword.Text = _user.Password;
                txbConfirmPassword.Text = _user.Password;
                chkbIsActive.Checked = _user.IsActive;
                Alltabs.SelectedTab = tabLoginInfo;
                onGivingUserObj?.Invoke(true);

                return;
            }

            if (_person == null || _person.ID == -1)
            {
                Alltabs.SelectedTab = tabPersonalInfo;
                _lockLoginTab = true;
                lbUserID.Text = "???";
                onGivingUserObj?.Invoke(false);
                return;
            }

            if (_person.ID != -1) {

                _lockLoginTab = false;
                Alltabs.SelectedTab = tabLoginInfo;
                lbUserID.Text = _person.ID.ToString();
                onGivingUserObj?.Invoke(false);

                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (!_lockLoginTab && _person!= null)
            {
               if(_user == null) { _user = new clsUserBusinessLayer(); }
                _user.PersonID = _person.ID;
                _user.UserName = txbUserName.Text;
                _user.Password = txbPassword.Text;
                _user.IsActive = chkbIsActive.Checked;
                if (_CheckingUserName() && _ConfirmingPassword())
                {
                    if (_user.Save())
                    {

                        MessageBox.Show("User Saved successfully");
                        onGivingUserObj?.Invoke(true);
                    }
                    else
                    {
                        MessageBox.Show("User Saved Failed", "", MessageBoxButtons.OK
                            , MessageBoxIcon.Error);
                        
                    }
                    
                }

            }
        }

     
    }
}
