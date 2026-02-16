
using System;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms.Application
{
    public partial class ScheduleTestForm : Form
    {
        public ScheduleTestForm()
        {
            InitializeComponent();
            scheduleTest1.CloseRequested += CloseForm;

        }

        public void setTestInfo(int ldlappid)
        {
           scheduleTest1.setTestInfo(ldlappid);
        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
