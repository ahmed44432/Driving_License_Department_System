using System;
using System.Windows.Forms;
using BusinessLayer;
using DVLD.MainForms.MainRelatedForms.Drivers;

namespace DVLD.MainForms.MainRelatedForms.Application
{
    public partial class RenewLocalDrivingLicenseForm : Form
    {
        public RenewLocalDrivingLicenseForm(clsUserBusinessLayer user)
        {
            InitializeComponent();
            _user = user;
            _DefLabels();
            licensesFilter1.FilterDataBack += _LoadLicenseInfo;
        }

        clsUserBusinessLayer _user;
        clsLicensesBusinessLayer _license;
        clsLicensesBusinessLayer _New_license;
        clsApplicationBusinessLayer _application;
        int total_fees = 0;


        private void _LoadLicenseInfo(clsLicensesBusinessLayer license)
        {
            _license = license;
            if (_license == null || _license.DriverID == -1) { _DefLabels(); return; }
            if (_license.IsActive == false)
            {
                MessageBox.Show(@"The license is  inactive !! EX : " + _license.ExpirationDate.ToString("d")
                    , "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            else if (_license.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show(@"The license is still active untill " + _license.ExpirationDate.ToString("d")
                    , "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            else
            { btnSave.Enabled = true; }
            lbOldLicenseID.Text = _license.LicenseID.ToString();
            lbLicenseFees.Text = _license.PaidFees.ToString();
            lbExperationDate.Text = _license.ExpirationDate.ToString("d");
            int appFees = 0; int licenseFees = 0;
            int.TryParse(lbApplicationFees.Text, out appFees);
            int.TryParse(lbLicenseFees.Text, out licenseFees);
            total_fees = (appFees + licenseFees);
            lbTotalFees.Text = total_fees.ToString();

        }

        private void _DefLabels()
        {

            lbR_L_ApplicationID.Text = "[###]";
            lbRenewedLicenseID.Text = "[###]";
            lbOldLicenseID.Text = "[###]";
            lbIssueDate.Text = DateTime.Now.ToString("d");
            lbApplicationDate.Text = DateTime.Now.ToString("d");
            lbExperationDate.Text = "[###]";
            lbApplicationFees.Text = clsApplicationTypesBusinessLayer
                .GetAppTypeFeesByID(2).ToString();
            lbLicenseFees.Text = "[$$$]";
            lbTotalFees.Text = "[$$$]";
            lbCreatedBy.Text = _user.UserName;


        }

        private void _PrepareApplicationObj()
        {
            clsPeopleBusinessLayer ?person = clsPeopleBusinessLayer.
                GetPersonByApplicationID(_license.ApplicationID);
            _application = new clsApplicationBusinessLayer();
            _application.ApplicationPersonID = person.ID;
            _application.ApplicationDate = DateTime.Now;
            _application.ApplicationTypeID = 2;
            _application.LastStatusDate = DateTime.Now;
            _application.ApplicationStatus = 1;
            _application.PaidFees = Convert.ToByte(clsApplicationTypesBusinessLayer
                .GetAppTypeFeesByID(2));
            _application.CreatedByUserID = _user.UserID;
        }


        private void _LabelsAfterSave()
        {
            lbR_L_ApplicationID.Text =
                _New_license.ApplicationID.ToString();
            lbRenewedLicenseID.Text = _New_license
                .LicenseID.ToString();
            lkbShowNewLicenseInfo.Enabled = true;

        }


        private void _Prepare_NewLicenseObj()
        {
            _PrepareApplicationObj();
            if (!_application.Save(_license.LicenseClass))
            {
                return;
            }
            _New_license = new clsLicensesBusinessLayer();
            _New_license.ApplicationID = _application.ApplicationID;
            _New_license.DriverID = _license.DriverID;
            _New_license.LicenseClass = _license.LicenseClass;
            _New_license.IssueDate = DateTime.Now;
            _New_license.ExpirationDate = DateTime.Now.AddYears(clsLicenseClassesbusinessLayer.
                GetLicenseValidityLength(_license.LicenseClass));
            _New_license.Notes = txbNotes.Text;
            _New_license.PaidFees = total_fees;
            _New_license.IssueReasonID = 2;
            _New_license.IsActive = true;
            _New_license.CreatedByUserID = _user.UserID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_license == null || _license.DriverID == -1)
            {
                MessageBox.Show("Not Found !!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (_license.IsActive)
            {
                MessageBox.Show("This License is Still Active !!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            _license.IsActive = false;
            if (_license.Save())
            {
                _Prepare_NewLicenseObj();
                if (_New_license.Save())
                {
                    MessageBox.Show("Saved Successfully !!", "Info",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LabelsAfterSave();
                    btnSave.Enabled = false;
                }
                else
                {
                    MessageBox.Show("New License was not saved.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("New License was not saved.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lkbShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_license == null || _license.DriverID == -1)
            {
                MessageBox.Show("Not Found !!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsPeopleBusinessLayer ?tmp_person =
                clsPeopleBusinessLayer.
                GetPersonByApplicationID(_license.ApplicationID);

            using (DriverLicensesHistoryForm historyForm = new DriverLicensesHistoryForm())
            {
                historyForm.LoadInfo(tmp_person.NationalNumber);
                historyForm.StartPosition = FormStartPosition.CenterScreen;
                historyForm.ShowDialog();
            }
        }

        private void lkbShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_New_license == null || _New_license.DriverID == -1)
            {
                lkbShowNewLicenseInfo.Enabled = false;
                return;
            }
            using (DriverLicenseInfoForm driverLicenseInfo = new DriverLicenseInfoForm())
            {
                driverLicenseInfo.LoadInfoByObj(_New_license);
                driverLicenseInfo.StartPosition = FormStartPosition.CenterScreen;
                driverLicenseInfo.ShowDialog();
            }
        }

      
    }


}
