using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using static DVLD.MainForms.MainRelatedForms.Drivers.DriverLicenseInfo;

namespace DVLD.MainForms.MainRelatedForms.Drivers
{
    public partial class InternationalLicenseInfo : UserControl
    {
        public InternationalLicenseInfo()
        {
            InitializeComponent();
        }

        private clsInternationalLicensesBusinessLayer _intlicense;
        private clsPeopleBusinessLayer _person;

        public void LoadInfoByApplicationID(int appid)
        {
            _intlicense = clsInternationalLicensesBusinessLayer
                .GetIntLicenseByApplicationID(appid);
            if( _intlicense == null || _intlicense.InternationalLicenseID == -1)
            {
                _DefLabels();
            }
            else
            {
                _person = clsPeopleBusinessLayer
                    .GetPersonByApplicationID(_intlicense.ApplicationID);

                string fullname = _person.FirstName + " " + _person.SecondName
                    + " " + _person.ThirdName + " " + _person.LastName;

                lbName.Text = fullname;
                lbIntLicenseID.Text = _intlicense.InternationalLicenseID.ToString();
                lbLicenseID.Text = _intlicense.LocalLicenseID.ToString();
                lbNNO.Text = _person.NationalNumber;
                lbGender.Text = _person.Gender == 'M' ? "Male" : "Female";
                lbIssueDate.Text = _intlicense.IssueDate.ToString("d");
                lbApplicationID.Text = _intlicense.ApplicationID.ToString();
                lbIsActive.Text = _intlicense.IsActive == true ? "Yes" : "No";
                lbDateOfBirth.Text = _person.DateOfBirth.ToString("d");
                lbDriverID.Text = _intlicense.DriverID.ToString();
                lbExperationDate.Text = _intlicense.ExpirationDate.ToString("d");
                if (!string.IsNullOrEmpty(_person.ImagePath))
                {
                    pictureBox1.Image = Image.FromFile(_person.ImagePath);
                    pictureBox1.ImageLocation = _person.ImagePath;
                }
                else
                {
                    if (_person.Gender == 'F')
                    {
                        pictureBox1.Image = Properties.Resources.person_woman;
                    }
                    else
                    {
                        pictureBox1.Image = Properties.Resources.person_man;
                    }
                }
            }


        }

        private void _DefLabels()
        {


            lbApplicationID.Text = "[###]";
            lbIntLicenseID.Text = "[###]";
            lbName.Text = "[###]";
            lbLicenseID.Text = "[###]";
            lbNNO.Text = "[###]";
            lbGender.Text = "[###]";
            lbIssueDate.Text = "[###]";
            lbNote.Text = "[###]";
            lbIsActive.Text = "[###]";
            lbDateOfBirth.Text = "[###]";
            lbDriverID.Text = "[###]";
            lbExperationDate.Text = "[###]";
            pictureBox1.Image = Properties.Resources.person_man;


        }



    }
}
