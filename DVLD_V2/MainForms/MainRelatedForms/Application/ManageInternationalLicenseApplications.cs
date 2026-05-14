using System;
using System.Windows.Forms;
using BusinessLayer;
using DVLD.MainForms.MainRelatedForms.Drivers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.MainForms.MainRelatedForms.Application
{
    public partial class ManageInternationalLicenseApplications : Form
    {
        public ManageInternationalLicenseApplications(clsUserBusinessLayer user)
        {
            InitializeComponent();
            dgvManageLicenseApplications.ReadOnly = true;
            dgvManageLicenseApplications.AllowUserToAddRows = false;
            dgvManageLicenseApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvManageLicenseApplications.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvManageLicenseApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _RefreshLicenseApplications();
            cbxFilter.SelectedIndex = 0;

            _user = user;
           
        }

        clsUserBusinessLayer _user;


        private void _RefreshLicenseApplications()
        {
            dgvManageLicenseApplications.DataSource =
               clsInternationalLicensesBusinessLayer.GetAllInternationalLicenses();
            lbRecordNumbers.Text = dgvManageLicenseApplications.RowCount.ToString();

        }

        enum ComboboxItems
        {
            None = 0,
            IntLicenseID = 1,
            AplicationID = 2,
            DriverID = 3,
            Status = 4
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            InternationalLicenseApplicaitonForm internationalapp
                = new InternationalLicenseApplicaitonForm(_user);
            internationalapp.StartPosition = FormStartPosition.CenterScreen;
            internationalapp.ShowDialog();
            _RefreshLicenseApplications();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID =
                Convert.ToInt32(dgvManageLicenseApplications.SelectedRows[0].
                Cells["Application ID"].Value);
            clsPeopleBusinessLayer person = clsPeopleBusinessLayer
                .GetPersonByApplicationID(ApplicationID);
            PersonInformation personInformation = new PersonInformation();
            personInformation.LoadPesronInfoByOBJ(person);
            personInformation.StartPosition = FormStartPosition.CenterScreen;
            personInformation.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID =
                Convert.ToInt32(dgvManageLicenseApplications.SelectedRows[0].
                Cells["Application ID"].Value);
            InternationalLicenseInfoForm internationalLicenseInfo = new InternationalLicenseInfoForm();
            internationalLicenseInfo.LoadInfoByApplicationID(ApplicationID);
            internationalLicenseInfo.StartPosition = FormStartPosition.CenterScreen;
            internationalLicenseInfo.ShowDialog();
        }

        private void showPersonLIcenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID =
               Convert.ToInt32(dgvManageLicenseApplications.SelectedRows[0].
               Cells["Application ID"].Value);
            clsPeopleBusinessLayer person = clsPeopleBusinessLayer
                .GetPersonByApplicationID(ApplicationID);
            DriverLicensesHistoryForm licensesHistoryForm = new DriverLicensesHistoryForm();
            licensesHistoryForm.LoadInfo(person.NationalNumber);
            licensesHistoryForm.StartPosition = FormStartPosition.CenterScreen;
            licensesHistoryForm.ShowDialog();
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

            if (cbxFilter.SelectedIndex == (int)ComboboxItems.Status)
            {

                textBox1.Visible = false;
                cbxStatus.Visible = true;
                _RefreshLicenseApplications();
                textBox1.Clear();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (cbxFilter.SelectedIndex == (int)ComboboxItems.None)
                return;


            switch ((ComboboxItems)cbxFilter.SelectedIndex)
            {
                case ComboboxItems.IntLicenseID:

                    if (int.TryParse(textBox1.Text, out int intlicenseid))
                        dgvManageLicenseApplications.DataSource =
                    clsInternationalLicensesBusinessLayer.
                    GetAllInternationalLicensesByIntLicenseID(intlicenseid);
                    break;
                case ComboboxItems.AplicationID:

                    if (int.TryParse(textBox1.Text, out int applicationid))
                        dgvManageLicenseApplications.DataSource =
                    clsInternationalLicensesBusinessLayer.
                    GetAllInternationalLicensesByApplicationID(applicationid);
                    break;
                case ComboboxItems.DriverID:

                    if (int.TryParse(textBox1.Text, out int driverid))
                        dgvManageLicenseApplications.DataSource =
                    clsInternationalLicensesBusinessLayer.
                    GetAllInternationalLicensesByDriverID(driverid);
                    break;
               

                default:
                    break;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbxFilter.SelectedIndex == (int)ComboboxItems.IntLicenseID
              || cbxFilter.SelectedIndex == (int)ComboboxItems.AplicationID
              || cbxFilter.SelectedIndex == (int)ComboboxItems.DriverID)
            {
                if (!char.IsDigit(e.KeyChar) &&
                    e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }

            }
            else
            {
                e.Handled = false;
            }
        }

        private void cbxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxStatus.SelectedIndex == 0)
            {  
                dgvManageLicenseApplications.DataSource =
                clsInternationalLicensesBusinessLayer.
                GetAllInternationalLicensesByStatus(true);

            }
            else
            {
                dgvManageLicenseApplications.DataSource =
                clsInternationalLicensesBusinessLayer.
                GetAllInternationalLicensesByStatus(false);
            }

        }






    }
}
