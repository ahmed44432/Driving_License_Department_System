
using System;
using System.Windows.Forms;
using BusinessLayer;
using DVLD.Properties;

namespace DVLD.MainForms.MainRelatedForms.Application
{
    public partial class TakeTest : Form
    {
        public TakeTest()
        {
            InitializeComponent();
        }

        clsTestsBusinessLayer _Test;
        clsTestAppointmentsBusinessLayer _TestApp;
        clsLDLBasicInfoBusinessLayer _ldlinfo;
        byte _trial = 0;
        enum enTestType {VisionTest = 1,WrittenTest = 2, PraticalTest = 3 }
        private enTestType _test_type;

        public void UI_ByType()
        {
            if (_test_type == enTestType.VisionTest)
            {
                picboxMain.Image = Resources.eye72;
            }
            else if (_test_type == enTestType.WrittenTest)
            {
                picboxMain.Image = Resources.Written_test72;
            }
            else if (_test_type == enTestType.PraticalTest)
            {
                picboxMain.Image = Resources.car_test72;
            }
        }

        public void setTestInfo(int testappid, byte typeid)
        {
            _test_type = (enTestType)typeid;
            UI_ByType();

            _ldlinfo = clsLDLBasicInfoBusinessLayer.
                    GetLDLBasicInfoByTestAppID(testappid);
            _TestApp = new clsTestAppointmentsBusinessLayer();
            _trial = Convert.ToByte(clsTestAppointmentsBusinessLayer.
                GetTestCountByLDLAppID(_ldlinfo.LDLApplicationID, typeid));

            if (clsTestAppointmentsBusinessLayer.
                isTestAppointmentsNotLockedExisted(testappid,typeid))
            {
                _TestApp = clsTestAppointmentsBusinessLayer.
                    GetTestAppointmentByTestAppID(testappid);
            }

            _RefreshApplicationInfo(_ldlinfo);
        }

        private void _RefreshApplicationInfo(clsLDLBasicInfoBusinessLayer ldlinfo)
        {
            if (_TestApp != null && _TestApp.TestAppointmentID != -1)
            {
                _trial = Convert.ToByte(clsTestAppointmentsBusinessLayer.
                GetTestCountByLDLAppID(_ldlinfo.LDLApplicationID,(byte) _test_type));

                lbDLAppID.Text = ldlinfo.LDLApplicationID.ToString();
                lbDClass.Text = ldlinfo.ClassName;
                lbName.Text = ldlinfo.FullName;
                lbTrial.Text = _trial.ToString();
                lbFees.Text = ldlinfo.PaidFees.ToString();
                lbDate.Text = _TestApp.AppointmentDate.ToString();


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
            lbDLAppID.Text = "[???]";
            lbDClass.Text = "[???]";
            lbName.Text = "[???]";
            lbTrial.Text = "[???]";
            lbFees.Text = "[???]";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(@"Are you sure you want to save , 
            you cant change it after this", "Confirm",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
            DialogResult.Yes)
            {

                if (clsTestsBusinessLayer.IsTestPassed(_TestApp.TestAppointmentID,(byte)_TestApp.TestTypeID))
                {
                    MessageBox.Show("alredy passed the test !!");
                    //CloseRequested?.Invoke(this, EventArgs.Empty);
                    return;
                }


                _Test = new clsTestsBusinessLayer();
                _Test.Notes = txbNotes.Text;
                _Test.TestAppointmentID = _TestApp.TestAppointmentID;
                _Test.CreatedByUserID = _TestApp.CreatedByUserID;


                if (rdbFail.Checked)
                {

                   _Test.TestResult = false;//fail
                   _TestApp.IsLocked = true;
                    if (_TestApp.Save()&& _Test.Save())
                    {
                        MessageBox.Show(@"Data Saved successfully", "Result",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(@"The data was not saved ", "Result",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    }

                }else if (rdbPass.Checked)
                {
                    _Test.TestResult = true;// pass
                    _TestApp.IsLocked = true;
                    if (_TestApp.Save() && _Test.Save())
                    {
                        MessageBox.Show(@"Data Saved successfully", "Result",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(@"The data was not saved ", "Result",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    }
                }
                this.Close();
            }
        }





    }




}
