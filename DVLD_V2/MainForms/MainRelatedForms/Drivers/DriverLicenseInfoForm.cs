using System;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms.Drivers
{
    public partial class DriverLicenseInfoForm : Form
    {
        public DriverLicenseInfoForm()
        {
            InitializeComponent();
        }

        public void LoadInfoByObj(clsLicensesBusinessLayer license)
        {
            driverLicenseInfo1.LoadInfoByObj(license);
        }

        public void LoadInfo(int ldlappid)
        {
            driverLicenseInfo1.LoadInfo(ldlappid);
        }


    }
}
