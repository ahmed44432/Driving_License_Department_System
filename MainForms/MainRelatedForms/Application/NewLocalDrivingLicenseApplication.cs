using System;
using System.Data;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms.Application
{
    public partial class NewLocalDrivingLicenseApplication : Form
    {
        public NewLocalDrivingLicenseApplication(clsUserBusinessLayer user)
        {
            InitializeComponent();
            personFilter1.OnPersonReturned += DataResever;
            cbxLicenseClass.DataSource = clsLicenseClassesbusinessLayer.GetLicenseClasses();
            cbxLicenseClass.DisplayMember = "ClassName";
            cbxLicenseClass.ValueMember = "LicenseClassID";
            cbxLicenseClass.SelectedIndex = 0;
            _user = user;
        }

        clsPeopleBusinessLayer _person;
        clsUserBusinessLayer _user;
        clsApplicationBusinessLayer _application;


        bool _lockApplicationTab = true;

        public void setUser(clsUserBusinessLayer user)
        {
            _user = user;
        }
        public void DataResever(clsPeopleBusinessLayer person)
        {
           

            if (person == null || person.ID == -1)
            {
                MessageBox.Show("Person Not Found");
                _lockApplicationTab = true;
            }
            _person = person;

        }


        private void btnNext_Click(object sender, EventArgs e)
        {

            if (_person == null || _person.ID == -1)
            {
                AllTabs.SelectedTab = tpPersonalInfo;
                _lockApplicationTab = true;
               
                //onGivingUserObj?.Invoke(false);

                return;
            }
            else
            {
                lbApplicationDate.Text = DateTime.Now.ToString();
                lbCreatedBy.Text = _user.UserName;
                _lockApplicationTab = false;
                AllTabs.SelectedTab = tpApplicationInfo;
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tpApplicationInfo && _lockApplicationTab)
            {
                e.Cancel = true; // يمنع الانتقال
            }
        }

        private void cbxLicenseClass_SelectedValueChanged(object sender, EventArgs e)
        {

            if (cbxLicenseClass.SelectedItem == null)
                return;

            // استرجاع الصف الحالي
            DataRowView row = cbxLicenseClass.SelectedItem as DataRowView;

            if (row == null)
                return;

            int classID = Convert.ToInt32(row["LicenseClassID"]);

            lbApllicationFees.Text = "15";
                //clsLicenseClassesbusinessLayer
                //.GetLicenseClassesFeesByID(classID)
                //.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!_lockApplicationTab && _person != null)
            {
                if (_application == null)
                { _application = new clsApplicationBusinessLayer(); }
                

                _application.ApplicationPersonID = _person.ID;
                _application.ApplicationDate = Convert.ToDateTime(lbApplicationDate.Text);
                _application.PaidFees = Convert.ToInt16(lbApllicationFees.Text);
                _application.CreatedByUserID = _user.UserID;
                int classapp = cbxLicenseClass.SelectedIndex + 1;
                _application.ApplicationTypeID = 1;
                _application.ApplicationStatus = 1;
                _application.LastStatusDate = Convert.ToDateTime(lbApplicationDate.Text);
                var row = cbxLicenseClass.SelectedItem as DataRowView;
                string className = row["ClassName"].ToString();



                if (!clsLocalLicenseApplicationBusinnessLayer
                    .isLDLApplicationExisted(_person.NationalNumber,
                      className))
                {

                    if (_application.Save(classapp))
                    {

                        MessageBox.Show("Application Saved successfully");
                        lbLDApplictionID.Text = _application
                            .ApplicationID.ToString();
                        //onGivingUserObj?.Invoke(true);
                    }
                    else
                    {
                        MessageBox.Show("Application Saved Failed", "", MessageBoxButtons.OK
                            , MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show(@"Application Saved Failed (Existed)
                      the person alredy has app in this class"
                        , "", MessageBoxButtons.OK
                        , MessageBoxIcon.Error);

                }



            }
        }



    }
    
}
