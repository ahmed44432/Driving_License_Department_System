
using System.Windows.Forms;

namespace DVLD.MainForms.MainRelatedForms.Application
{
    public partial class LDLApplicationInformation : Form
    {
        public LDLApplicationInformation(int ldlappid)
        {
            InitializeComponent();
            localLicenseApplicationDetails1.setAppInfo(ldlappid);
        }
    }
}
