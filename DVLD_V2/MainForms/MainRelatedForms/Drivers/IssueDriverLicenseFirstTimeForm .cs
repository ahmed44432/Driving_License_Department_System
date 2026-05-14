using System;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms.Application
{
    public partial class IssueDriverLicenseFirstTimeForm : Form
    {
        public IssueDriverLicenseFirstTimeForm(clsUserBusinessLayer user)
        {
            InitializeComponent();
            _userid = user.UserID;
        }

        private int _userid;
        private clsLDLBasicInfoBusinessLayer _ldlinfo;
        private clsLicensesBusinessLayer _license;
        private clsDriversBusinessLayer _driver;
        private clsApplicationBusinessLayer _application;


        public void Load_Info(int ldlappid)
        {
            localLicenseApplicationDetails1.setAppInfo(ldlappid);
            _ldlinfo = clsLDLBasicInfoBusinessLayer.
                GetLDLBasicInfoByLDLAppID(ldlappid);
            _application = clsApplicationBusinessLayer.
                GetApplicationByLDLAppID(ldlappid);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (clsLicensesBusinessLayer.IsLicenseExist(_application.ApplicationID))
            { return; }
            _driver = clsDriversBusinessLayer.GetDriverByPersonID(_application.ApplicationPersonID);
            if (_driver == null)
            {
                _driver = new clsDriversBusinessLayer();
                _driver.PersonID = _application.ApplicationPersonID;
                _driver.CreatedByUserID = _userid;
                _driver.CreationDate = DateTime.Now;
                _driver.Save();
            }

            int licensclassid = clsLicenseClassesbusinessLayer
                .GetLicenseClassIDByName(_ldlinfo.ClassName);

            _license = new clsLicensesBusinessLayer();
            _license.ApplicationID = _application.ApplicationID;
            _license.DriverID = _driver.DriverID;
            _license.LicenseClass = Convert.ToByte(licensclassid);
            _license.IssueDate = DateTime.Now;
            _license.ExpirationDate = DateTime.Now.AddYears(clsLicenseClassesbusinessLayer.
                GetLicenseValidityLength(licensclassid));
            _license.Notes = tbNote.Text;
            _license.PaidFees = _ldlinfo.PaidFees;
            _license.IsActive = true;
            _license.IssueReasonID = 1;
            _license.CreatedByUserID = _userid;

            if (_license.Save())
            {
                MessageBox.Show("Saved Succesfuly", "Saving"
                    , MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                this.Close();
            }



        }


    }



}
