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
    public partial class UserInformation : Form
    {
        public UserInformation(int userid)
        {
            InitializeComponent();
            clsUserBusinessLayer user = clsUserBusinessLayer.GetUserByUserID(userid);
            userDetails1.setUserInfo(user);
            
        }
    }
}
