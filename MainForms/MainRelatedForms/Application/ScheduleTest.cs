
using System;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms.Application
{
    public partial class ScheduleTest : UserControl
    {
        public ScheduleTest()
        {
            InitializeComponent();
        }

        public delegate void TestInfo(clsTestAppointmentsBusinessLayer testapp);
        public event TestInfo OnTestInfoBack;
        public event EventHandler CloseRequested;

        clsTestAppointmentsBusinessLayer _TestApp;
        //clsApplicationBusinessLayer _app;
        clsLDLBasicInfoBusinessLayer _ldlinfo;
        byte _trial = 0;

        public void setTestInfo(int ldlappid)
        {
            _ldlinfo = clsLDLBasicInfoBusinessLayer.
                    GetLDLBasicInfoByLDLAppID(ldlappid);
            _TestApp = new clsTestAppointmentsBusinessLayer();
            _trial = Convert.ToByte(clsTestAppointmentsBusinessLayer.
                GetVisionTestCountByLDLAppID(ldlappid));

            if (clsTestAppointmentsBusinessLayer.
                isVisionTestAppointmentsNotLockedExisted(ldlappid)) {
                _TestApp = clsTestAppointmentsBusinessLayer.
                    GetVisionTestAppointmentByLDLappID(ldlappid);
            }else if (clsTestAppointmentsBusinessLayer.
                isVisionTestAppointmentsLockedExisted(ldlappid))
            {
                lbInfo.Visible = true;
                dtpDate.Enabled = false;
                btnSave.Enabled = false;
            }
            
                _RefreshApplicationInfo(_ldlinfo);
        }

        private void _RefreshApplicationInfo(clsLDLBasicInfoBusinessLayer ldlinfo)
        {
            if(_TestApp != null && _TestApp.TestAppointmentID != -1)
            {
                _trial = Convert.ToByte(clsTestAppointmentsBusinessLayer.
               GetVisionTestCountByLDLAppID(ldlinfo.LDLApplicationID));

                lbDLAppID.Text = ldlinfo.LDLApplicationID.ToString();
                lbDClass.Text = ldlinfo.ClassName;
                lbName.Text = ldlinfo.FullName;
                lbTrial.Text = _trial.ToString();
                lbFees.Text = ldlinfo.PaidFees.ToString();
                dtpDate.Value = _TestApp.AppointmentDate;


                return;
            }

            else if (ldlinfo != null)
            {

                _trial = Convert.ToByte(clsTestAppointmentsBusinessLayer.
               GetVisionTestCountByLDLAppID(ldlinfo.LDLApplicationID));

                lbDLAppID.Text  = ldlinfo.LDLApplicationID.ToString();
                lbDClass.Text = ldlinfo.ClassName;
                lbName.Text = ldlinfo.FullName;
                lbTrial.Text = _trial.ToString();
                lbFees.Text = ldlinfo.PaidFees.ToString();

                ////

                _TestApp.LDLApplicationID = _ldlinfo.LDLApplicationID;
                _TestApp.TestTypeID = 1; // vision test
                _TestApp.PaidFees = _ldlinfo.PaidFees;
                _TestApp.AppointmentDate = dtpDate.Value;
                clsUserBusinessLayer user =
                    clsUserBusinessLayer.GetUserByUserName(_ldlinfo.UserName);
                _TestApp.CreatedByUserID = user.UserID;
                _TestApp.IsLocked = false;

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
            lbDLAppID.Text   = "[???]";
            lbDClass.Text    = "[???]";
            lbName.Text      = "[???]";
            lbTrial.Text     = "[???]";
            lbFees.Text      = "[???]";
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if(_TestApp != null)
            {
                _TestApp.AppointmentDate = dtpDate.Value;

                if(_TestApp.Save()){
                    
                    MessageBox.Show("Saved :)");
                    CloseRequested?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Cant Save !!");
                }

            }
            else
            {
                MessageBox.Show("Cant Save !!");
            }
        }






    }













}
