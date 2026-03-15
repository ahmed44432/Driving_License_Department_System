
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms.Application
{
    public partial class RetakeTestInfo : UserControl
    {
        public RetakeTestInfo()
        {
            InitializeComponent();
        }

        public void setRtktestinfo(clsTestAppointmentsBusinessLayer app)
        {
            if (app == null) { _DefLabels();return; }

            int retakeappid = clsTestAppointmentsBusinessLayer
                .GetApplicationID_ByTestappointmentID(app.TestAppointmentID);

            int apptypefees = clsApplicationTypesBusinessLayer.
                GetAppTypeFeesByID(8);

            lbTotalFees.Text =
                (app.PaidFees +
                apptypefees.ToString());

            lbRTKFees.Text =
                apptypefees.ToString();
            lbRtAppID.Text = retakeappid.ToString();

        }

        private void _DefLabels()
        {
            lbRtAppID.Text = "[???]";
            lbTotalFees.Text = "[???]";
            lbRTKFees.Text = "[???]";
        }


    }
}
