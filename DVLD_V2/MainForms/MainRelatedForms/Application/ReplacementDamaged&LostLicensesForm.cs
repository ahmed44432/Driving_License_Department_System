using BusinessLayer;
using DVLD.MainForms.MainRelatedForms.Drivers;
using System;
using System.Windows.Forms;

namespace DVLD.MainForms.MainRelatedForms.Application
{
    public partial class ReplacementDamaged_LostLicensesForm : Form
    {
        public ReplacementDamaged_LostLicensesForm(clsUserBusinessLayer user)
        {
            InitializeComponent();
            _user = user;
            _DefLabels();
            licensesFilter1.FilterDataBack += _LoadLicenseInfo;
            rbtnDamegedLicense.Checked = true;
            _replacementType = ReplacementType.Damaged;
        }

        clsUserBusinessLayer _user;
        clsLicensesBusinessLayer _license;
        clsLicensesBusinessLayer _New_license;
        clsApplicationBusinessLayer _application;
        ReplacementType _replacementType;

        enum ReplacementType
        {
            Damaged = 4,
            Lost = 3
        }


        private void RadioButton_ChKChng()
        {
            if (rbtnDamegedLicense.Checked)
            {
                lbHeader.Text = "Replacement of Damaged License";
                this.Text = "Replacement of Damaged License";
                _replacementType = ReplacementType.Damaged;
            }
            else
            {
                lbHeader.Text = "Replacement of Lost License";
                this.Text = "Replacement of Lost License";
                _replacementType = ReplacementType.Lost;
            }
            lbApplicationFees.Text = clsApplicationTypesBusinessLayer
                .GetAppTypeFeesByID((int)_replacementType).ToString();
        }

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
            else
            { btnSave.Enabled = true; }
            lbOldLicenseID.Text = _license.LicenseID.ToString();
          

        }

        private void _DefLabels()
        {

            lbR_L_ApplicationID.Text = "[###]";
            lbReplacedLicenseID.Text = "[###]";
            lbOldLicenseID.Text = "[###]";
            lbApplicationDate.Text = DateTime.Now.ToString("d");
            lbApplicationFees.Text = clsApplicationTypesBusinessLayer
                .GetAppTypeFeesByID((int)_replacementType).ToString();
            lbCreatedBy.Text = _user.UserName;

        }

        private void _PrepareApplicationObj()
        {
            clsPeopleBusinessLayer person = clsPeopleBusinessLayer.
                GetPersonByApplicationID(_license.ApplicationID);
            _application = new clsApplicationBusinessLayer();
            _application.ApplicationPersonID = person.ID;
            _application.ApplicationDate = DateTime.Now;
            _application.ApplicationTypeID = (int)_replacementType;
            _application.LastStatusDate = DateTime.Now;
            _application.ApplicationStatus = 1;
            _application.PaidFees = Convert.ToByte(clsApplicationTypesBusinessLayer
                .GetAppTypeFeesByID((int)_replacementType));
            _application.CreatedByUserID = _user.UserID;
        }


        private void _LabelsAfterSave()
        {
            lbR_L_ApplicationID.Text =
                _New_license.ApplicationID.ToString();
            lbReplacedLicenseID.Text = _New_license
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
            _New_license.Notes = _license.Notes;
            _New_license.PaidFees = _license.PaidFees + Convert.ToByte(clsApplicationTypesBusinessLayer
                .GetAppTypeFeesByID((int)_replacementType));
            _New_license.IssueReasonID = (byte)_replacementType;
            _New_license.IsActive = true;
            _New_license.CreatedByUserID = _user.UserID;
        }

        private void rbtnDamegedLicense_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton_ChKChng();
        }

        private void rbtnLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton_ChKChng();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_license == null || _license.DriverID == -1)
            {
                MessageBox.Show("Not Found !!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!_license.IsActive)
            {
                MessageBox.Show("This License is Not Active !!", "Info",
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
            clsPeopleBusinessLayer tmp_person =
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
