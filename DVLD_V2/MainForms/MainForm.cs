using System;
using System.Windows.Forms;
using BusinessLayer;
using DVLD.MainForms.MainRelatedForms;
using DVLD.MainForms.MainRelatedForms.Application;
using DVLD.MainForms.MainRelatedForms.Drivers;
using DVLD.MainRelatedForms;

namespace DVLD
{
    public partial class MainForm : Form
    {
        public MainForm(clsUserBusinessLayer user)
        {
            InitializeComponent();
            _user = user;
            dataSend?.Invoke(_user);
        }

        public delegate void UserData(clsUserBusinessLayer user);
        public event UserData dataSend;

        public bool LogoutRequested = false;
        clsUserBusinessLayer _user;

        public void setUser(clsUserBusinessLayer user)
        {
            _user = user;
        }

        private void tspmiPeople_Click(object sender, EventArgs e)
        {
            PeopleForm peopleForm = new PeopleForm();
            peopleForm.StartPosition = FormStartPosition.CenterScreen;
            peopleForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            CenterPictureBox();
            
        }

        private void CenterPictureBox()
        {
            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = (this.ClientSize.Height - pictureBox1.Height) / 2;
        }

        private void tsmiSignOut_Click(object sender, EventArgs e)
        {
            this.Hide(); // إخفاء MainForm الحالي

            using (LoginScreen loginScreen = new LoginScreen())
            {
                LogoutRequested = true;
                this.Close();

            }

        }

        private void tspmiUsers_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm();
            usersForm.StartPosition = FormStartPosition.CenterScreen;
            usersForm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInformation userInformation = new UserInformation(_user);
            userInformation.StartPosition = FormStartPosition.CenterScreen;
            userInformation.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(_user);
            changePassword.StartPosition = FormStartPosition.CenterScreen;
            changePassword.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageApplicationTypesForm appTypes = new ManageApplicationTypesForm();
            appTypes.StartPosition = FormStartPosition.CenterScreen;
            appTypes.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageTestTypes manageTestTypes = new ManageTestTypes();
            manageTestTypes.StartPosition = FormStartPosition.CenterScreen;
            manageTestTypes.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLocalDrivingLicenseApplication newLocalDrivingLicenseApplication = new NewLocalDrivingLicenseApplication(_user);
            newLocalDrivingLicenseApplication.StartPosition = FormStartPosition.CenterScreen;
            newLocalDrivingLicenseApplication.ShowDialog();
        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageLocalLicenseApplications licenseApplications = new ManageLocalLicenseApplications(_user);
            licenseApplications.StartPosition = FormStartPosition.CenterScreen;
            licenseApplications.ShowDialog();
        }

        private void tspmiDrivers_Click(object sender, EventArgs e)
        {
            ManageDriversForm manageDrivers = new ManageDriversForm();
            manageDrivers.StartPosition = FormStartPosition.CenterScreen;
            manageDrivers.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternationalLicenseApplicaitonForm internationalLicense = new InternationalLicenseApplicaitonForm(_user);
            internationalLicense.StartPosition = FormStartPosition.CenterScreen;
            internationalLicense.ShowDialog();
        }

        private void internationalLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageInternationalLicenseApplications manageInternationalapp
                = new ManageInternationalLicenseApplications(_user);
            manageInternationalapp.StartPosition = FormStartPosition.CenterScreen;
            manageInternationalapp.ShowDialog();
        }

        private void renewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenewLocalDrivingLicenseForm renewLocalDrivingLicense = new RenewLocalDrivingLicenseForm(_user);
            renewLocalDrivingLicense.StartPosition = FormStartPosition.CenterScreen;
            renewLocalDrivingLicense.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplacementDamaged_LostLicensesForm replacementForm = new ReplacementDamaged_LostLicensesForm(_user);
            replacementForm.StartPosition = FormStartPosition.CenterScreen;
            replacementForm.ShowDialog();
        }





    }
    
}
