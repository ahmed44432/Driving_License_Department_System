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
    public partial class AddUpdateUser : Form
    {
        public AddUpdateUser()
        {
            InitializeComponent();
            addingUser1.onGivingUserObj += setInfo;
        }

        public AddUpdateUser(clsUserBusinessLayer user)
        {
            InitializeComponent();
            lbAddUpdateUser.Text = "Updating User";
            addingUser1.setInfo(user);
            addingUser1.onGivingUserObj += setInfo;
        }

        private void setInfo(bool type)
        {
            if(!type)
            {
                lbAddUpdateUser.Text = "Add New User";
            }
            else
            {
                lbAddUpdateUser.Text = "Updating User";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
