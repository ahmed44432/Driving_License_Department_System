using System;
using System.Windows.Forms;
using BusinessLayer;


namespace DVLD.MainForms.MainRelatedForms.Application
{
    public partial class ManageLocalLicenseApplications : Form
    {
        public ManageLocalLicenseApplications(clsUserBusinessLayer user)
        {
            InitializeComponent();


            dgvManageLicenseApplications.ReadOnly = true;
            dgvManageLicenseApplications.AllowUserToAddRows = false;
            dgvManageLicenseApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _RefreshLicenseApplications();

            _user = user;
            dgvManageLicenseApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        clsUserBusinessLayer _user;

        public void user_data(clsUserBusinessLayer user)
        {
            _user = user;
        } 

        private void _RefreshLicenseApplications()
        {
            dgvManageLicenseApplications.DataSource =
               clsLocalLicenseApplicationBusinnessLayer.GetLocalLicenseApplication();  
            lbRecordNumbers.Text = dgvManageLicenseApplications.RowCount.ToString();

        }

        private void ManageLocalLicenseApplications_Load(object sender, EventArgs e)
        {

        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            NewLocalDrivingLicenseApplication newLocalDrivingLicense =
                new NewLocalDrivingLicenseApplication(_user);
            newLocalDrivingLicense.StartPosition = FormStartPosition.CenterScreen;
            newLocalDrivingLicense.ShowDialog();
            _RefreshLicenseApplications();
        }

        enum ComboboxItemsNumber
        {
            None = 0, 
            LDLAppID = 1,
            NationalNo = 2,
            FullName = 3,
            Status = 4
        }

        enum StatusComboboxItemsNumber
        {
           New = 0,
           Cancelled = 1,
           Completed = 2 

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (cbxFilter.SelectedIndex == (int)ComboboxItemsNumber.None)
                return;


            switch ((ComboboxItemsNumber)cbxFilter.SelectedIndex)
            {
                case ComboboxItemsNumber.LDLAppID:

                    if (int.TryParse(textBox1.Text, out int appid))
                        dgvManageLicenseApplications.DataSource =
                            clsLocalLicenseApplicationBusinnessLayer.
                            GetAllLocalLicenseApplicationsByAppID(appid);
                    break;
                case ComboboxItemsNumber.NationalNo:

                    dgvManageLicenseApplications.DataSource =
                           clsLocalLicenseApplicationBusinnessLayer.
                            GetAllLocalLicenseApplicationsByNNO(textBox1.Text);
                    break;
                case ComboboxItemsNumber.FullName:

                    dgvManageLicenseApplications.DataSource =
                          clsLocalLicenseApplicationBusinnessLayer.
                          GetAllLocalLicenseApplicationsByFullName(textBox1.Text);
                    break;

                default:
                    break;
            }


        }

        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxFilter.SelectedIndex == 0)
            {
                _RefreshLicenseApplications();
                textBox1.Clear();
                textBox1.Visible = false;
                cbxStatus.Visible = false;
            }
            else
            {
                cbxStatus.Visible = false;
                textBox1.Visible = true;
            }

            if (cbxFilter.SelectedIndex == (int)ComboboxItemsNumber.Status)
            {

                textBox1.Visible = false;
                cbxStatus.Visible = true;
                _RefreshLicenseApplications();
                textBox1.Clear();

            }
        }

        private void cbxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxStatus.SelectedIndex == (int) StatusComboboxItemsNumber.New)
            {
                dgvManageLicenseApplications.DataSource =
                        clsLocalLicenseApplicationBusinnessLayer.
                        GetAllLocalLicenseApplicationsByStatus("New");
            }
            else if (cbxStatus.SelectedIndex == (int)StatusComboboxItemsNumber.Cancelled)
            {
                dgvManageLicenseApplications.DataSource =
                      clsLocalLicenseApplicationBusinnessLayer.
                        GetAllLocalLicenseApplicationsByStatus("Cancelled");
            }
            else if (cbxStatus.SelectedIndex == (int)StatusComboboxItemsNumber.Completed)
            {
                dgvManageLicenseApplications.DataSource =
                     clsLocalLicenseApplicationBusinnessLayer.
                        GetAllLocalLicenseApplicationsByStatus("Completed");
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplicationID =
                 Convert.ToInt32(dgvManageLicenseApplications.SelectedRows[0].
                 Cells["L.D.L.ApplicationID"].Value);
            clsApplicationBusinessLayer.
                DeleteApplicationByLDLAppID(LDLApplicationID);
            _RefreshLicenseApplications();
        }

        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplicationID =
                Convert.ToInt32(dgvManageLicenseApplications.SelectedRows[0].
                Cells["L.D.L.ApplicationID"].Value);
            clsApplicationBusinessLayer app = clsApplicationBusinessLayer.
                    GetApplicationByLDLAppID(LDLApplicationID);
            app.ApplicationStatus = 2;
            app.Save();
            _RefreshLicenseApplications();

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplicationID =
                Convert.ToInt32(dgvManageLicenseApplications.SelectedRows[0].
                Cells["L.D.L.ApplicationID"].Value);
            LDLApplicationInformation lDLApplication = new
                LDLApplicationInformation(LDLApplicationID);
            lDLApplication.StartPosition = FormStartPosition.CenterScreen;
            lDLApplication.ShowDialog();
            _RefreshLicenseApplications();

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int LDLApplicationID =
                Convert.ToInt32(dgvManageLicenseApplications.SelectedRows[0].
                Cells["L.D.L.ApplicationID"].Value);
            clsLDLBasicInfoBusinessLayer LdlAppInfo =
                clsLDLBasicInfoBusinessLayer.GetLDLBasicInfoByLDLAppID(LDLApplicationID);
            switch (LdlAppInfo.Status)
            {
                case "New":
                    IssueDrivingToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = false;
                    sechduleStreetTestsToolStripMenuItem.Enabled = false;
                    sechduleWrittenTestToolStripMenuItem.Enabled = false;
                    CancelToolStripMenuItem.Enabled = true;
                    DeleteToolStripMenuItem.Enabled = true;
                    EditApplicationToolStripMenuItem.Enabled = true;
                    SechduleTestsToolStripMenuItem.Enabled = true;
                    break;

                case "Cancelled":

                    break;


                case "Completed":

                    showLicenseToolStripMenuItem.Enabled = true;
                    IssueDrivingToolStripMenuItem.Enabled = false;
                    CancelToolStripMenuItem.Enabled = false;
                    DeleteToolStripMenuItem.Enabled = false;
                    EditApplicationToolStripMenuItem.Enabled = false;
                    SechduleTestsToolStripMenuItem.Enabled = false;
                    showPersonLicenseHistoryToolStripMenuItem.Enabled = true;

                    break;

            }
            
        }

        private void sechduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplicationID =
                Convert.ToInt32(dgvManageLicenseApplications.SelectedRows[0].
                Cells["L.D.L.ApplicationID"].Value);
            //clsApplicationBusinessLayer app = clsApplicationBusinessLayer.
            //        GetApplicationByLDLAppID(LDLApplicationID);
            VisionTestAppointment appointment = new VisionTestAppointment();
            appointment.setLdlAppInfo(LDLApplicationID);
            appointment.StartPosition = FormStartPosition.CenterScreen;
            appointment.ShowDialog();
            _RefreshLicenseApplications(); 
        }
    }
}
