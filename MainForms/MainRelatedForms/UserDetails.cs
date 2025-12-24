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
    public partial class UserDetails : UserControl
    {
        public UserDetails()
        {
            InitializeComponent();
            _DefLabels();
        }

        clsUserBusinessLayer _user = new clsUserBusinessLayer();
        clsPeopleBusinessLayer person = new clsPeopleBusinessLayer();
        public void setUserInfo(clsUserBusinessLayer user)
        {
            _user = user;
            _RefreshUserInfo(user);
            if (user == null)
            {
                personDetails1.setinfo(person);
                return;
            }
            person = clsPeopleBusinessLayer.GetPersonByID(user.PersonID);
            personDetails1.setinfo(person);
        } 

        private void _RefreshUserInfo(clsUserBusinessLayer user)
        {
            if (user == null || user.UserID == -1) {

                _DefLabels();
                return;
            }

            lbUserID.Text = user.UserID.ToString();
            lbUserName.Text = user.UserName;
            lbIsActive.Text = user.IsActive == true ? "YES" : "NO"; 

        }

        private void _DefLabels()
        {
            lbUserID.Text = "[????]";
            lbUserName.Text = "[????]";
            lbIsActive.Text = "[????]";
        }




    }
}
