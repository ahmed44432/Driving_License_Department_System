
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms.Application
{
    public partial class ApplicationBasicInfo : UserControl
    {
        public ApplicationBasicInfo()
        {
            InitializeComponent();
            _DefLabels();
        }

        clsPeopleBusinessLayer _person = new clsPeopleBusinessLayer();
        clsApplicationBusinessLayer _application = new clsApplicationBusinessLayer();
        clsLDLBasicInfoBusinessLayer _LDLBasicInfo = new clsLDLBasicInfoBusinessLayer();


        public void setApplicationInfo(clsApplicationBusinessLayer app)
        {
            _application = app;
            if (app != null)
            {
                _LDLBasicInfo = clsLDLBasicInfoBusinessLayer.
                    GetLDLBasicInfoByAppID(app.ApplicationID);
            }
            else
            {
                _DefLabels();
                return;
            }

            //_RefreshApplicationInfo(_LDLBasicInfo);
            if (_application != null && _LDLBasicInfo != null)
            {
                lbID.Text = _application.ApplicationID.ToString();
                lbFees.Text = _application.PaidFees.ToString();
                lbType.Text = _application.ApplicationTypeID.ToString();
                lbDate.Text = _application.ApplicationDate.ToString();
                lbStatusDate.Text = _application.LastStatusDate.ToString();
                lbFees.Text = _LDLBasicInfo.PaidFees.ToString();
                lbApplicant.Text = _LDLBasicInfo.FullName.ToString();
                lbStatus.Text = _LDLBasicInfo.Status.ToString();
                lbCreatedBy.Text = _LDLBasicInfo.UserName;

                return;
            }
            else
            {
                _DefLabels();
                return;
            }
            
        }

        private void _RefreshApplicationInfo()
        {
            if (_application != null && _LDLBasicInfo != null)
            {
                lbID.Text = _application.ApplicationID.ToString();
                lbFees.Text = _application.PaidFees.ToString();
                lbType.Text = _application.ApplicationTypeID.ToString();
                lbDate.Text = _application.ApplicationDate.ToString();
                lbStatusDate.Text = _application.LastStatusDate.ToString();
                lbFees.Text = _LDLBasicInfo.PaidFees.ToString();
                lbApplicant.Text = _LDLBasicInfo.FullName.ToString();
                lbStatus.Text = _LDLBasicInfo.Status.ToString();
                lbCreatedBy.Text = _LDLBasicInfo.UserName;

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

        private void lkbViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_application != null)
            {
                PersonInformation personInformation = new PersonInformation(_application.ApplicationPersonID);
                personInformation.StartPosition = FormStartPosition.CenterScreen;                
                personInformation.ShowDialog();
            }
            else
            {
                MessageBox.Show("This application does not exist");
            }
            _RefreshApplicationInfo();

        }
    }
}
