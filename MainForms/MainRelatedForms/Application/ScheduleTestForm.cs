
using System;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms.Application
{
    public partial class ScheduleTestForm : Form
    {
        public ScheduleTestForm(clsUserBusinessLayer user,byte typeid)
        {
            InitializeComponent();
            scheduleTest1.CloseRequested += CloseForm;
            _user = user;
            _typeid = typeid;
        }

        private clsUserBusinessLayer _user;
        private byte _typeid;

        public void LoadTest(int ldlAppID, int appointmentid = -1)
        {
            scheduleTest1.LoadCurrentUserInfo(_user);
            scheduleTest1.LoadTest(ldlAppID,_typeid,appointmentid);
        }


      


        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
