using System;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
            dgvUsers.ReadOnly = true;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            comboBox1.SelectedIndex = 0;
            cbxIsActive.SelectedIndex = 0;
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            AddUpdateUser addUpdateUser = new AddUpdateUser();
            addUpdateUser.StartPosition = FormStartPosition.CenterScreen;
            addUpdateUser.ShowDialog();
            _RefreshUsersList();
        }

        private void _RefreshUsersList()
        {
            dgvUsers.DataSource = clsUserBusinessLayer.GetAllUsers();
            lbRecordNumbers.Text = dgvUsers.RowCount.ToString();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            _RefreshUsersList();
        }

        enum ComboboxItemsNumber
        {
            None = 0, UserID = 1, UserName = 2, PersonID = 3,
            FullName = 4, IsActive = 5
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == (int)ComboboxItemsNumber.None)
                return;
        

            switch ((ComboboxItemsNumber)comboBox1.SelectedIndex)
            {
                case ComboboxItemsNumber.UserID:
                   
                    if (int.TryParse(textBox1.Text, out int userid))
                        dgvUsers.DataSource =
                            clsUserBusinessLayer.GetAllUsersByUserID(userid);
                    break;
                case ComboboxItemsNumber.UserName :
                    
                    dgvUsers.DataSource =
                            clsUserBusinessLayer.GetAllUsersByUserName(textBox1.Text);
                    break;

                case ComboboxItemsNumber.PersonID :
                    
                    if (int.TryParse(textBox1.Text, out int personid))
                        dgvUsers.DataSource =
                            clsUserBusinessLayer.GetAllUsersByPersonID(personid);
                    break;
                case ComboboxItemsNumber.FullName :
                
                    dgvUsers.DataSource =
                           clsUserBusinessLayer.GetAllUsersByFullName(textBox1.Text);
                    break;
                case ComboboxItemsNumber.IsActive :

                    
                        break;

                        default : 
                    break;

                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                _RefreshUsersList();
                textBox1.Clear();
                textBox1.Visible = false;
                cbxIsActive.Visible = false;
            }
            else
            {
                cbxIsActive.Visible = false;
                textBox1.Visible = true;
            }

            if (comboBox1.SelectedIndex == (int)ComboboxItemsNumber.IsActive)
            {

                textBox1.Visible = false;
                cbxIsActive.Visible = true;
                _RefreshUsersList();
                textBox1.Clear();
               
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedIndex == (int)ComboboxItemsNumber.PersonID
               || comboBox1.SelectedIndex == (int)ComboboxItemsNumber.UserID)
            {
                if (!char.IsDigit(e.KeyChar) &&
                    e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }

            }
            else
            {
                e.Handled = false;
            }
        }

        private void cbxIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxIsActive.SelectedIndex == 0)
            {
                dgvUsers.DataSource =
                       clsUserBusinessLayer.
                       GetAllUsers();
            }
            else if (cbxIsActive.SelectedIndex == 1)
            {
                dgvUsers.DataSource =
                      clsUserBusinessLayer.
                      GetUsersByActivationStatus(true);
            }
            else
            {
                dgvUsers.DataSource =
                      clsUserBusinessLayer.
                      GetUsersByActivationStatus(false);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userid =
                  Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["User ID"].Value);
            UserInformation userInformation = new UserInformation(userid);
            userInformation.StartPosition = FormStartPosition.CenterScreen;
            userInformation.AutoScaleMode = AutoScaleMode.None;
            userInformation.ShowDialog();
            _RefreshUsersList();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateUser addinguser = new AddUpdateUser();
            addinguser.StartPosition = FormStartPosition.CenterScreen;
            addinguser.AutoScaleMode = AutoScaleMode.None;
            addinguser.ShowDialog();
            _RefreshUsersList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userid =
                  Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["User ID"].Value);
            clsUserBusinessLayer user = clsUserBusinessLayer.GetUserByUserID(userid);
            AddUpdateUser addUpdateUser = new AddUpdateUser(user);
            addUpdateUser.StartPosition = FormStartPosition.CenterScreen;
            addUpdateUser.AutoScaleMode = AutoScaleMode.None;
            addUpdateUser.ShowDialog();
            _RefreshUsersList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int userid =
                   Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["User ID"].Value);

            if (clsUserBusinessLayer.IsUserLinked(userid))
            {
                MessageBox.Show(
               @"This User cannot be deleted because it is linked to existing records in the system."
                   , "special person", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (
                MessageBox.Show("Are you sure you want to delete this User", "Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes
                )
            {

                clsUserBusinessLayer.DeleteUser(userid);
                _RefreshUsersList();
                lbRecordNumbers.Text = dgvUsers.RowCount.ToString();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userid =
                  Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["User ID"].Value);
            clsUserBusinessLayer user = clsUserBusinessLayer.GetUserByUserID(userid);
            ChangePassword changePassword = new ChangePassword(user);
            changePassword.StartPosition = FormStartPosition.CenterScreen;
            changePassword.AutoScaleMode = AutoScaleMode.None;
            changePassword.ShowDialog();
            _RefreshUsersList();
        }
    }
}
