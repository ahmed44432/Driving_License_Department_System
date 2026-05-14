using System;
using System.Windows.Forms;

namespace DVLD.MainForms.MainRelatedForms.Drivers
{
    public partial class InternationalLicenseInfoForm : Form
    {
        public InternationalLicenseInfoForm()
        {
            InitializeComponent();
        }


        public void LoadInfoByApplicationID(int appid)
        {
            internationalLicenseInfo1.LoadInfoByApplicationID(appid);
        }



    }

}
