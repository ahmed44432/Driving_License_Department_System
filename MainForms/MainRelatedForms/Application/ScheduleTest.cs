using System;
using System.Windows.Forms;
using BusinessLayer;
using DVLD.Properties;



namespace DVLD.MainForms.MainRelatedForms.Application
{
    public partial class ScheduleTest : UserControl
    {
        public ScheduleTest()
        {
            InitializeComponent();
            _mode = enMode.Add;
            _creation_mode = enCreationMode.New;
            _test_type = enTestType.VisionTest;
            
        }

        public event EventHandler CloseRequested;

        private clsTestAppointmentsBusinessLayer _testApp;
        private clsLDLBasicInfoBusinessLayer _ldlInfo;
        private clsApplicationBusinessLayer _retakeApp;
        private clsTestAppointmentsBusinessLayer _retakeTestApp;
        private clsApplicationBusinessLayer _oldApp;
        private clsUserBusinessLayer _currentUser;

        private byte _trial;

        enum enMode
        {
            Add,
            Update
        }

        enum enCreationMode
        {
            New,
            Retake
        }

        enum enTestType
        {
            VisionTest = 1,
            WrittenTest = 2,
            PraticalTest = 3
        }

        private enMode _mode;
        private enCreationMode _creation_mode;
        private enTestType _test_type;

        public void LoadCurrentUserInfo(clsUserBusinessLayer user)
        { _currentUser = user; }

        //---------------------------------------------------
        // LOAD
        //---------------------------------------------------

        public void UI_ByType()
        {
            if (_test_type == enTestType.VisionTest)
            {
                picboxMain.Image = Resources.eye72;
            }
            else if (_test_type == enTestType.WrittenTest)
            {
                picboxMain.Image = Resources.Written_test72;
                
            }else if (_test_type == enTestType.PraticalTest)
            {
                picboxMain.Image = Resources.car_test72;
            }
        }

        public void LoadTest(int ldlAppID,byte typeid,int appointmentid = -1)
        {
            _test_type = (enTestType)typeid;
            UI_ByType(); 
           

            if (appointmentid == -1)
            {
                _mode = enMode.Add;
                _creation_mode = enCreationMode.New;


                _ldlInfo =
               clsLDLBasicInfoBusinessLayer
               .GetLDLBasicInfoByLDLAppID(ldlAppID);

                _testApp =
                    clsTestAppointmentsBusinessLayer
                    .GetTestAppointmentByLdlAppid(ldlAppID,(byte)_test_type);

                _trial = Convert.ToByte(
                    clsTestAppointmentsBusinessLayer
                    .GetTestCountByLDLAppID(ldlAppID, (byte)_test_type));
            }
            else
            {
                _mode = enMode.Update;
           

                _ldlInfo =
               clsLDLBasicInfoBusinessLayer
               .GetLDLBasicInfoByLDLAppID(ldlAppID);

                _testApp =
                    clsTestAppointmentsBusinessLayer
                    .GetTestAppointmentByTestAppID(appointmentid);

                _trial = Convert.ToByte(
                     clsTestAppointmentsBusinessLayer
                     .GetTestCountByLDLAppID(ldlAppID, (byte)_test_type));

                if (_trial > 1)
                {
                    //if (!_testApp.IsLocked){
                        retakeTestInfo1.Enabled = true;
                        retakeTestInfo1.setRtktestinfo(_testApp);
                    //}
                }
                    
            }

      

            HandleState();
            RefreshUI();
        }

        //---------------------------------------------------
        // STATE LOGIC
        //---------------------------------------------------
        private void HandleState()
        {
            if (_ldlInfo == null)
                return;

            if (_testApp == null ||
                _testApp.TestAppointmentID == -1)
            {
                CreateNewAppointment();
                return;
            }

            bool passed =
                clsTestsBusinessLayer
                .IsTestPassed(_testApp.TestAppointmentID,(byte)_testApp.TestTypeID);

            bool failed =
                clsTestsBusinessLayer
                .IsTestFailed(_testApp.TestAppointmentID, (byte)_testApp.TestTypeID);

            bool locked =
                clsTestAppointmentsBusinessLayer
                .isTestAppointmentsLockedExisted(
                   _testApp.TestAppointmentID, (byte)_testApp.TestTypeID);


            if(failed && !passed) { _creation_mode = enCreationMode.Retake; }

            if (_mode == enMode.Add)
            {
                if (passed)
                {
                    lbInfo.Visible = true;
                    dtpDate.Enabled = false;
                    btnSave.Enabled = false;
                    return;
                }

                if (_creation_mode == enCreationMode.Retake)
                {
                    PrepareRetake();
                    return;
                }
                return;
            }

            if (_mode == enMode.Update)
            {

                if (passed || locked)
                {
                    lbInfo.Visible = true;
                    dtpDate.Enabled = false;
                    btnSave.Enabled = false;
                    return;
                }
            }

            


            
        }

        //---------------------------------------------------
        // CREATE NEW
        //---------------------------------------------------
        private void CreateNewAppointment()
        {
            _creation_mode = enCreationMode.New;
            _mode = enMode.Add;

            _testApp = new clsTestAppointmentsBusinessLayer();

            _testApp.LDLApplicationID = _ldlInfo.LDLApplicationID;
            _testApp.TestTypeID = (byte)_test_type; 
            _testApp.PaidFees = _ldlInfo.PaidFees;
            _testApp.AppointmentDate = dtpDate.Value;
            _testApp.IsLocked = false;
            _testApp.CreatedByUserID = _currentUser.UserID;
                
        }

        //---------------------------------------------------
        // RETAKE
        //---------------------------------------------------
        private void PrepareRetake()
        {
            if (_mode == enMode.Update)
            {
                return;
            }

            
            retakeTestInfo1.Enabled = true;

            _oldApp = clsApplicationBusinessLayer
                .GetApplicationByLDLAppID(_ldlInfo.LDLApplicationID);
            _oldApp.ApplicationStatus = 2;

            _retakeApp =
                new clsApplicationBusinessLayer
                {
                    ApplicationPersonID = _oldApp.ApplicationPersonID,
                    ApplicationStatus = 1,
                    ApplicationDate = _oldApp.ApplicationDate,
                    LastStatusDate = _oldApp.LastStatusDate,
                    ApplicationTypeID = 8,
                    PaidFees = _testApp.PaidFees,
                    CreatedByUserID = _currentUser.UserID,

                };

            _retakeTestApp =
                new clsTestAppointmentsBusinessLayer
                {
                    LDLApplicationID = _ldlInfo.LDLApplicationID,
                    TestTypeID = _testApp.TestTypeID,
                    CreatedByUserID = _currentUser.UserID,
                    IsLocked = false,
                    AppointmentDate = dtpDate.Value,
                    PaidFees = _testApp.PaidFees
                };

            retakeTestInfo1
                .setRtktestinfo(_retakeTestApp);
        }

        //---------------------------------------------------
        // UI REFRESH
        //---------------------------------------------------
        private void RefreshUI()
        {
            if (_ldlInfo == null)
            {
                SetDefaultLabels();
                return;
            }

            lbDLAppID.Text =
                _ldlInfo.LDLApplicationID.ToString();

            lbDClass.Text = _ldlInfo.ClassName;
            lbName.Text = _ldlInfo.FullName;
            lbFees.Text = _ldlInfo.PaidFees.ToString();
            lbTrial.Text = _trial.ToString();

            if (_testApp != null &&
                _testApp.TestAppointmentID != -1)
            {
                dtpDate.Value =
                    _testApp.AppointmentDate;
            }
        }

        private void SetDefaultLabels()
        {
            lbDLAppID.Text = "[???]";
            lbDClass.Text = "[???]";
            lbName.Text = "[???]";
            lbTrial.Text = "[???]";
            lbFees.Text = "[???]";
        }

        //---------------------------------------------------
        // SAVE
        //---------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_ldlInfo == null)
                return;

            if (AlreadyPassed())
                return;

            if (_creation_mode == enCreationMode.Retake)
            {
                HandleRetake();
                SaveAppointment();
                return;
            }

            if (_mode == enMode.Add)
                CreateNewAppointment();


            SaveAppointment();
        }

        //---------------------------------------------------
        private bool AlreadyPassed()
        {
            if (clsTestsBusinessLayer
                .IsTestPassed(
                _testApp.TestAppointmentID, (byte)_testApp.TestTypeID))
            {
                MessageBox.Show("Already passed!");

                CloseRequested?.Invoke(
                    this,
                    EventArgs.Empty);

                return true;
            }

            return false;
        }

     
        private void HandleRetake()
        {

            int classid = clsLicenseClassesbusinessLayer
               .GetLicenseClassIDByName(
                   _ldlInfo.ClassName);

            _retakeApp.Save(classid);

            var LDLAppToUpdate =
                clsLocalLicenseApplicationBusinnessLayer
                .GetLDLApplicationByAppID(
                    _oldApp.ApplicationID);



            LDLAppToUpdate.UpdateLocalLicesenseApplication
                (_retakeApp.ApplicationID, classid);


            _retakeTestApp.TestAppointmentID = -1;
        }

        private void PrepareAppointmentObject(clsTestAppointmentsBusinessLayer testapp)
        {
            // DO NOT touch app.LDLApplicationID here
            // it was already correctly set before calling this method

            if (_mode == enMode.Update)
                testapp.TestAppointmentID = _testApp.TestAppointmentID;

            testapp.TestTypeID = (byte)_test_type;

            testapp.PaidFees =
                _ldlInfo.PaidFees;

            testapp.AppointmentDate =
                dtpDate.Value;

            testapp.IsLocked = false;

            var user =
                clsUserBusinessLayer
                .GetUserByUserName(_ldlInfo.UserName);

            testapp.CreatedByUserID =
                user.UserID;
        }

        private void SaveAppointment()
        {
            clsTestAppointmentsBusinessLayer appToSave =
                (_creation_mode == enCreationMode.Retake)
                ? _retakeTestApp
                : _testApp;

            if (appToSave == null)
            {
                MessageBox.Show("No appointment to save!");
                return;
            }

            PrepareAppointmentObject(appToSave);

            if (appToSave.Save())
            {
                MessageBox.Show("Saved :)");
                if (_creation_mode == enCreationMode.Retake)
                {
                    retakeTestInfo1
                        .setRtktestinfo(appToSave);
                }
                CloseRequested?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Cant Save !!");
            }


        }


    }





}