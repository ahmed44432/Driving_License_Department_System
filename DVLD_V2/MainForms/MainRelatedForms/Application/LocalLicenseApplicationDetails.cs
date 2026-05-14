
using System.Windows.Forms;
using BusinessLayer;
using DVLD.MainForms.MainRelatedForms.Drivers;


namespace DVLD.MainForms.MainRelatedForms.Application
{
    public partial class LocalLicenseApplicationDetails : UserControl
    {
        public LocalLicenseApplicationDetails()
        {
            InitializeComponent();
            
        }

        clsApplicationBusinessLayer _app;
        clsLDLBasicInfoBusinessLayer _ldlinfo;
        clsLicensesBusinessLayer _license;



        public void setAppInfo(int ldlappid)
        {
            _app = clsApplicationBusinessLayer.
            GetApplicationByLDLAppID(ldlappid);
            _ldlinfo = clsLDLBasicInfoBusinessLayer.
                GetLDLBasicInfoByLDLAppID(ldlappid);
            _license =
            clsLicensesBusinessLayer.
            GetLicenseByLDLAppID(ldlappid);

            applicationBasicInfo1.setApplicationInfo(_app);
            _RefreshApplicationInfo(_ldlinfo);

        
        }

        private void _RefreshApplicationInfo(clsLDLBasicInfoBusinessLayer ldlinfo)
        {
            if (ldlinfo != null)
            {
                lbAppliedForLicense.Text = ldlinfo.ClassName;
                lbDLAppID.Text = ldlinfo.LDLApplicationID.ToString();
                lbPassedTest.Text = "3/"+ldlinfo.PassedTestCount.ToString();
                if(_license != null) { lkbShowLicenseInfo.Enabled = true; }
                return;
            }
            else
            {
                _DefLabels();
                return;
            }

        }

        private void _DefLabels()
        {
            foreach (Control cr in this.Controls)
            {

                if (cr is Label lbl && lbl.Text[1] == 'b')
                {

                    lbl.Text = "[???]";
                }


            }
            lkbShowLicenseInfo.Enabled = false;
        }

        private void lkbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_ldlinfo == null)
            {
                lkbShowLicenseInfo.Enabled = false;
                return;
            }
            _license =
                clsLicensesBusinessLayer.GetLicenseByLDLAppID(_ldlinfo.LDLApplicationID);
            if (_license != null && _license.DriverID != -1)
            {
                
                DriverLicenseInfoForm licenseInfoForm = new DriverLicenseInfoForm();
                licenseInfoForm.LoadInfo(_ldlinfo.LDLApplicationID);
                licenseInfoForm.StartPosition = FormStartPosition.CenterScreen;
                licenseInfoForm.ShowDialog();
            }


        }




    }
}
