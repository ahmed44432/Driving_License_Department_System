
using System.Windows.Forms;
using BusinessLayer;


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
       

        public void setAppInfo(int ldlappid)
        {
            _app = clsApplicationBusinessLayer.
            GetApplicationByLDLAppID(ldlappid);
            _ldlinfo = clsLDLBasicInfoBusinessLayer.
                GetLDLBasicInfoByLDLAppID(ldlappid);

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
        }

    }
}
