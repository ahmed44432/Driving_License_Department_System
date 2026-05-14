using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms.Drivers
{
    public partial class DriverLicenseInfo : UserControl
    {
        public DriverLicenseInfo()
        {
            InitializeComponent();
        }

        private clsLicensesBusinessLayer _license;
        private clsPeopleBusinessLayer _person;
        private enIssueReason _issue_reason;

        public enum enIssueReason : byte
        {
            [Description("First Time")]
            FirstTime = 1,

            [Description("Renewal")]
            Renewal = 2,

            [Description("Lost License")]
            Replacement = 3,

            [Description("Damaged License")]
            Damaged = 4
        }

        public static string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            var attribute = (System.ComponentModel.DescriptionAttribute)
                Attribute.GetCustomAttribute(field,
                typeof(System.ComponentModel.DescriptionAttribute));

            return attribute != null ? attribute.Description : value.ToString();
        }

        public void LoadInfo(int ldlappid)
        {
            _license = clsLicensesBusinessLayer.GetLicenseByLDLAppID(ldlappid);
            if( _license == null || _license.LicenseID == -1)
            {
                _DefLabels();
            }
            else
            {
                _person = clsPeopleBusinessLayer
                    .GetPersonByApplicationID(_license.ApplicationID);
                lbClassName.Text = clsLicenseClassesbusinessLayer
                    .GetLicenseClassNameByID(_license.LicenseClass);

                string fullname = _person.FirstName + " " + _person.SecondName
                    + " " + _person.ThirdName + " " + _person.LastName;

                lbName.Text = fullname;
                lbLicenseID.Text = _license.LicenseID.ToString();
                lbNNO.Text = _person.NationalNumber;
                lbGender.Text = _person.Gender == 'M' ? "Male" : "Female";
                lbIssueDate.Text = _license.IssueDate.ToString("yyyy/MM/dd");
                _issue_reason = (enIssueReason)_license.IssueReasonID;
                lbIssueReason.Text = GetEnumDescription(_issue_reason);
                lbNote.Text = _license.Notes;
                lbIsActive.Text = _license.IsActive == true ? "Yes" : "No";
                lbDateOfBirth.Text = _person.DateOfBirth.ToString("yyyy/MM/dd");
                lbDriverID.Text = _license.DriverID.ToString();
                lbExperationDate.Text = _license.ExpirationDate.ToString("yyyy/MM/dd");
                lbIsDetained.Text = 
                    clsDetainedLicenseBusinessLayer.
                    IsLicenseDetainedByLicenseID(_license.LicenseID) ? "Yes" : "No";

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

        public void LoadInfoByObj(clsLicensesBusinessLayer license)
        {
            _license = license;
            if (_license == null || _license.LicenseID == -1)
            {
                _DefLabels();
            }
            else
            {
                _person = clsPeopleBusinessLayer
                    .GetPersonByApplicationID(_license.ApplicationID);
                lbClassName.Text = clsLicenseClassesbusinessLayer
                    .GetLicenseClassNameByID(_license.LicenseClass);

                string fullname = _person.FirstName + " " + _person.SecondName
                    + " " + _person.ThirdName + " " + _person.LastName;

                lbName.Text = fullname;
                lbLicenseID.Text = _license.LicenseID.ToString();
                lbNNO.Text = _person.NationalNumber;
                lbGender.Text = _person.Gender == 'M' ? "Male" : "Female";
                lbIssueDate.Text = _license.IssueDate.ToString("yyyy/MM/dd");
                _issue_reason = (enIssueReason)_license.IssueReasonID;
                lbIssueReason.Text = GetEnumDescription(_issue_reason);
                lbNote.Text = _license.Notes;
                lbIsActive.Text = _license.IsActive == true ? "Yes" : "No";
                lbDateOfBirth.Text = _person.DateOfBirth.ToString("yyyy/MM/dd");
                lbDriverID.Text = _license.DriverID.ToString();
                lbExperationDate.Text = _license.ExpirationDate.ToString("yyyy/MM/dd");
                lbIsDetained.Text = "No";
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

            lbClassName.Text = "[###]";
            lbName.Text = "[###]";
            lbLicenseID.Text = "[###]";
            lbNNO.Text = "[###]";
            lbGender.Text = "[###]";
            lbIssueDate.Text = "[###]";
            lbIssueReason.Text = "[###]";
            lbNote.Text = "[###]";
            lbIsActive.Text = "[###]";
            lbDateOfBirth.Text = "[###]";
            lbDriverID.Text = "[###]";
            lbExperationDate.Text = "[###]";
            pictureBox1.Image = Properties.Resources.person_man;


        }



    }
}
