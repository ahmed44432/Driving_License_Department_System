
using System;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms.Application
{
    public partial class VisionTestAppointment : Form
    {
        public VisionTestAppointment()
        {
            InitializeComponent();
            dgvAppontments.ReadOnly = true;
            dgvAppontments.AllowUserToAddRows = false;
            dgvAppontments.SelectionMode = 
                DataGridViewSelectionMode.FullRowSelect;
            dgvAppontments.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            //dgvAppontments.AutoSize = true;
            dgvAppontments.AutoSizeColumnsMode = 
                DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvAppontments.Rows.Count > 0)
            {
                dgvAppontments.Columns[0].FillWeight = 40;
                dgvAppontments.Columns[1].FillWeight = 100;
                dgvAppontments.Columns[2].FillWeight = 200;
                dgvAppontments.Columns[3].FillWeight = 40;
            }


        }

        int _ldlappid;

        public void setLdlAppInfo(int ldlappid)
        {
            _ldlappid = ldlappid;
            localLicenseApplicationDetails1.setAppInfo(ldlappid);
            dgvAppontments.DataSource =
               clsTestAppointmentsBusinessLayer.
               GetALLVisionTestAppointmentsByLDLAppID(_ldlappid);
        }

        private void _RefreshdgvAPP()
        {
            dgvAppontments.DataSource =
                clsTestAppointmentsBusinessLayer.
                GetALLVisionTestAppointmentsByLDLAppID(_ldlappid);
           
        }

        private void btnADD_Click(object sender, System.EventArgs e)
        {
            if (!clsTestAppointmentsBusinessLayer.
                isVisionTestAppointmentsNotLockedExisted(_ldlappid)) {
                ScheduleTestForm scheduleTestForm = new ScheduleTestForm();
                scheduleTestForm.setTestInfo(_ldlappid);
                scheduleTestForm.StartPosition = FormStartPosition.CenterScreen;
                scheduleTestForm.ShowDialog();
                _RefreshdgvAPP();
            }
            else
            {
                MessageBox.Show(@"An appointment has 
                already been scheduled for this person", "Message",
                MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void editToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            int AppointmentID =
                Convert.ToInt32(dgvAppontments.SelectedRows[0].
                Cells["AppointmentID"].Value);
            ScheduleTestForm scheduleTestForm = new ScheduleTestForm();
            scheduleTestForm.setTestInfo(_ldlappid);
            scheduleTestForm.StartPosition = FormStartPosition.CenterScreen;
            scheduleTestForm.ShowDialog();
            _RefreshdgvAPP();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID =
               Convert.ToInt32(dgvAppontments.SelectedRows[0].
               Cells["AppointmentID"].Value);
            
            clsTestAppointmentsBusinessLayer
                TestApp = clsTestAppointmentsBusinessLayer.
                GetTestAppointmentByTestAppID(AppointmentID);
            if (!TestApp.IsLocked)
            {
                TakeTest takeTest = new TakeTest();
                takeTest.setTestInfo(TestApp.LDLApplicationID);
                takeTest.StartPosition = FormStartPosition.CenterScreen;
                takeTest.ShowDialog();
                _RefreshdgvAPP();
            }
            else
            {
                MessageBox.Show(@"This Appointment is Locked", "Info",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
