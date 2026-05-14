using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Linq;
using BusinessLayer;
using DVLD.MainForms.MainRelatedForms.Drivers;
using static DVLD.MainForms.MainRelatedForms.Drivers.DriverLicenseInfo;

namespace DVLD.MainForms.MainRelatedForms.Application
{
    public partial class InternationalLicenseApplicaitonForm : Form
    {
        public InternationalLicenseApplicaitonForm(clsUserBusinessLayer user)
        {
            InitializeComponent();
            _user = user;
            _DefLabels();
            licensesFilter1.FilterDataBack += _LoadLicenseInfo;
            
        }

        clsUserBusinessLayer _user;
        clsLicensesBusinessLayer _license;
        clsApplicationBusinessLayer _application;
        clsInternationalLicensesBusinessLayer _international_license;

        private void _LoadLicenseInfo(clsLicensesBusinessLayer license)
        {
            _license = license;
            if(_license == null || _license.DriverID == -1) { _DefLabels();return; }
            lbLocalLicenseID.Text = _license.LicenseID.ToString();
            clsInternationalLicensesBusinessLayer
                intlicense =
                clsInternationalLicensesBusinessLayer.
                GetIntLicenseByApplicationID(_license.ApplicationID);
            if(intlicense != null) { lkbShowLicenseInfo.Enabled = true; }
        }

        private void _PrepareApplicationObj()
        {
            clsPeopleBusinessLayer person = clsPeopleBusinessLayer.
                GetPersonByApplicationID(_license.ApplicationID);
            _application = new clsApplicationBusinessLayer();
            _application.ApplicationPersonID = person.ID;
            _application.ApplicationDate = DateTime.Now;
            _application.ApplicationTypeID = 6;
            _application.LastStatusDate = DateTime.Now;
            _application.ApplicationStatus = 1;
            _application.PaidFees = Convert.ToByte(clsApplicationTypesBusinessLayer
                .GetAppTypeFeesByID(6));
            _application.CreatedByUserID = _user.UserID;
        }

        private void _Prepare_ILIcenseObj()
        {
            _PrepareApplicationObj(); 
            if (!_application.Save(_license.LicenseClass))
            {
                return;
            }
            _international_license = new clsInternationalLicensesBusinessLayer();
            _international_license.ApplicationID = _application.ApplicationID;
            _international_license.DriverID = _license.DriverID;
            _international_license.LocalLicenseID = _license.LicenseID;
            _international_license.IssueDate = DateTime.Now;
            _international_license.ExpirationDate = DateTime.Now.AddYears(1);
            _international_license.IsActive = true;
            _international_license.CreatedByUserID = _user.UserID;
        }

        private void _DefLabels()
        {

            lbI_L_ApplicationID.Text = "[###]";
            lbI_L_LicenseID.Text = "[###]";
            lbLocalLicenseID.Text = "[###]";
            lbIssueDate.Text = DateTime.Now.ToString("d");
            lbApplicationDate.Text = DateTime.Now.ToString("d");
            lbExperationDate.Text = (DateTime.Now.AddYears(1)).ToString("d");
            lbFees.Text = clsApplicationTypesBusinessLayer
                .GetAppTypeFeesByID(6).ToString();
            lbCreatedBy.Text = _user.UserName;
           

        }


        private void _LabelsAfterSave()
        {
            lbI_L_ApplicationID.Text =
                _international_license.ApplicationID.ToString();
            lbI_L_LicenseID.Text = _international_license
                .InternationalLicenseID.ToString();
            lkbShowLicenseInfo.Enabled = true;

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

            DriverLicensesHistoryForm historyForm = new DriverLicensesHistoryForm();
            historyForm.LoadInfo(tmp_person.NationalNumber);
            historyForm.StartPosition = FormStartPosition.CenterScreen;
            historyForm.ShowDialog();
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

            }else if (clsInternationalLicensesBusinessLayer.
                IsInternationalLicenseActive(_license.DriverID))
            {
                MessageBox.
                    Show(@"He alredy Has an Active International License !!"
                  , "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



                _Prepare_ILIcenseObj();
            if (_international_license.Save())
            {
                MessageBox.Show("Saved Successfully !!", "Info",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LabelsAfterSave();
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void lkbShowLicenseInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_license == null || _license.DriverID == -1)
            {
                lkbShowLicenseInfo.Enabled = false;
                return;
            }
            InternationalLicenseInfoForm internationalLicense = new InternationalLicenseInfoForm();
            internationalLicense.LoadInfoByApplicationID(_license.ApplicationID);
            internationalLicense.StartPosition = FormStartPosition.CenterScreen;
            internationalLicense.ShowDialog();
        }



    }
}
