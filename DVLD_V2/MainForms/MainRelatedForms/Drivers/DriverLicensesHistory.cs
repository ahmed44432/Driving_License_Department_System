using System;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms.Drivers
{
    public partial class DriverLicensesHistory : UserControl
    {
        public DriverLicensesHistory()
        {
            InitializeComponent();
            dgvLocalLH.ReadOnly = true;
            dgvLocalLH.AllowUserToAddRows = false;
            dgvLocalLH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLocalLH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            dgvInternationalLH.ReadOnly = true;
            dgvInternationalLH.AllowUserToAddRows = false;
            dgvInternationalLH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInternationalLH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        public void LoadInfo(string nno)
        {
            dgvLocalLH.DataSource = 
                clsLicensesBusinessLayer.GetAllLocalLicensesByNNO(nno);
            lb_LLH_RecordNumbers.Text = 
                dgvLocalLH.RowCount.ToString();
            dgvInternationalLH.DataSource =
                clsLicensesBusinessLayer.GetAllInternationalLicensesByNNO(nno);
            lb_ILH_RecordNumbers.Text =
                dgvInternationalLH.RowCount.ToString();

        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tbpInternational)
            {
                if (dgvInternationalLH.CurrentRow != null)
                {
                    int ApplicationID = Convert.ToInt32(
                        dgvInternationalLH.CurrentRow.Cells["ApplicationID"].Value);

                    InternationalLicenseInfoForm form = new InternationalLicenseInfoForm();
                    form.LoadInfoByApplicationID(ApplicationID);
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please select a row.");
                }
            }
            else if (tabControl1.SelectedTab == tbpLocal)
            {
                if (dgvLocalLH.CurrentRow != null)
                {
                    int licenseid = Convert.ToInt32(
                        dgvLocalLH.CurrentRow.Cells["LicenseID"].Value);

                    clsLicensesBusinessLayer license =
                        clsLicensesBusinessLayer.GetLicenseByLicenseID(licenseid);

                    if (license != null)
                    {
                        DriverLicenseInfoForm form = new DriverLicenseInfoForm();
                        form.LoadInfoByObj(license);
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("License not found.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row.");
                }
            }

        }



    }
}
