
using System;
using System.Windows.Forms;
using BusinessLayer;
using DVLD.Properties;

namespace DVLD.MainForms.MainRelatedForms.Application
{
    public partial class TestsAppointmentForm : Form
    {
        public TestsAppointmentForm(clsUserBusinessLayer user , byte testtype)
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

            _test_type = (TestType)testtype;

            if(_test_type == TestType.VisionTest)
            {
                picboxMain.Image = Resources.eye72;
                lbTitel.Text = @"Vision Test Appointments";
            }
            else if (_test_type == TestType.WrittingTest)
            {
                picboxMain.Image = Resources.Written_test72;
                lbTitel.Text = @"Written Test Appointments";
            }
            else if (_test_type == TestType.StreetTest)
            {
                picboxMain.Image = Resources.car_test72;
                lbTitel.Text = @"Street Test Appointments";
            }

            _user = user;
            
        }

        int _ldlappid;
        private clsUserBusinessLayer _user;
        enum TestType { VisionTest = 1, WrittingTest = 2, StreetTest = 3 };
        TestType _test_type;


        public void setLdlAppInfo(int ldlappid)
        {
            _ldlappid = ldlappid;
            localLicenseApplicationDetails1.setAppInfo(ldlappid);
            _RefreshdgvAPP();
        }

        private void _RefreshdgvAPP()
        {
            dgvAppontments.DataSource =
                clsTestAppointmentsBusinessLayer.
                GetALLTestAppointmentsByLDLAppID_ByType(_ldlappid,(byte)_test_type);
            lbRecordNumbers.Text =
                dgvAppontments.RowCount.ToString();

            if (dgvAppontments.DataSource != null &&
                 dgvAppontments.Rows.Count > 0 &&
                 dgvAppontments.Columns.Contains("AppointmentID"))
            {
                dgvAppontments.Sort(
                    dgvAppontments.Columns["AppointmentID"],
                    System.ComponentModel.ListSortDirection.Descending);
            }

        }

        private void btnADD_Click(object sender, System.EventArgs e)
        {
           

            if(clsTestAppointmentsBusinessLayer.
               isTestAppointmentsNotLockedExistedByLDLAppID(_ldlappid,
               (byte) _test_type)){

                MessageBox.Show(@"This person has already an Active Appoinment
                ", "Message",
              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            clsTestAppointmentsBusinessLayer
               testapp = clsTestAppointmentsBusinessLayer
               .GetTestAppointmentByLdlAppid(_ldlappid,(byte)_test_type);

            if ( testapp == null
                || clsTestsBusinessLayer.IsTestFailed(testapp.TestAppointmentID, (byte)testapp.TestTypeID)) {

                ScheduleTestForm scheduleTestForm = new ScheduleTestForm(_user, (byte)_test_type);
                scheduleTestForm.LoadTest(_ldlappid);
                scheduleTestForm.StartPosition = FormStartPosition.CenterScreen;
                scheduleTestForm.ShowDialog();
                _RefreshdgvAPP();
            }
            else if (clsTestsBusinessLayer.IsTestPassed(testapp.TestAppointmentID,(byte)testapp.TestTypeID))
            {

                MessageBox.Show(@"This person has already passed the test
                ", "Message",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            ScheduleTestForm scheduleTestForm = new ScheduleTestForm(_user, (byte)_test_type);
            scheduleTestForm.LoadTest(_ldlappid,AppointmentID);
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
                takeTest.setTestInfo(TestApp.TestAppointmentID,(byte) _test_type);
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
