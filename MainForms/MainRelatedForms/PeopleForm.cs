using System;
using System.IO;
using System.Windows.Forms;
using BusinessLayer;
using DVLD.MainForms.MainRelatedForms;

namespace DVLD.MainRelatedForms
{
    public partial class PeopleForm : Form
    {
        public PeopleForm()
        {
            InitializeComponent();
            dgvPeopleList.ReadOnly = true;
            dgvPeopleList.AllowUserToAddRows = false;
            _RefreshPeopleList();
            dgvPeopleList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            comboBox1.SelectedIndex = 0;
        }

        private void _RefreshPeopleList()
        {
            dgvPeopleList.DataSource = clsPeopleBusinessLayer.GetAllPeople();
       
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            AddEditPerson addEditPerson = new AddEditPerson();
            addEditPerson.StartPosition = FormStartPosition.CenterScreen;
            addEditPerson.AutoScaleMode = AutoScaleMode.None;
            addEditPerson.ShowDialog();
            _RefreshPeopleList();
        }
      

        private void PeopleForm_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            lbRecordNumbers.Text = dgvPeopleList.RowCount.ToString();
        }

        private void dgvPeopleList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (comboBox1.SelectedIndex == 0) {
                _RefreshPeopleList();
                textBox1.Clear();
                textBox1.Visible = false;
            }
            else
            {
                textBox1.Visible = true;
            }
            
        }

        enum ComboboxItemsNumber
        {
            None = 0,PersonID = 1,NationaNO = 2,FirstName = 3,
            SecondName = 4,ThirdName = 5,LastName =6,
            Nationality = 7, Gender =8,Phone = 9, Email = 10,
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == (int)ComboboxItemsNumber.None)
                return;

            string text = textBox1.Text;

            switch ((ComboboxItemsNumber)comboBox1.SelectedIndex)
            {
                case ComboboxItemsNumber.PersonID:
                    if (int.TryParse(text, out int id))
                        dgvPeopleList.DataSource = clsPeopleBusinessLayer.GetAllPeopleBYID(id);
                    break;

                case ComboboxItemsNumber.NationaNO:
                    dgvPeopleList.DataSource = clsPeopleBusinessLayer.GetAllPeopleByNationalNO(text);
                    break;

                case ComboboxItemsNumber.FirstName:
                    dgvPeopleList.DataSource = clsPeopleBusinessLayer.GetAllPeopleByFirstName(text);
                    break;

                case ComboboxItemsNumber.SecondName:
                    dgvPeopleList.DataSource = clsPeopleBusinessLayer.GetAllPeopleBySecondName(text);
                    break;

                case ComboboxItemsNumber.ThirdName:
                    dgvPeopleList.DataSource = clsPeopleBusinessLayer.GetAllPeopleByThirdName(text);
                    break;

                case ComboboxItemsNumber.LastName:
                    dgvPeopleList.DataSource = clsPeopleBusinessLayer.GetAllPeopleByLastName(text);
                    break;

                case ComboboxItemsNumber.Nationality:
                    dgvPeopleList.DataSource = clsPeopleBusinessLayer.GetAllPeopleByNationality(text);
                    break;

                case ComboboxItemsNumber.Gender:
                    textBox1.MaxLength = 1;
                    dgvPeopleList.DataSource = clsPeopleBusinessLayer.GetAllPeopleByGender(text);
                    textBox1.MaxLength = short.MaxValue;
                    break;

                case ComboboxItemsNumber.Phone:
                    dgvPeopleList.DataSource = clsPeopleBusinessLayer.GetAllPeopleByPhone(text);
                    break;

                case ComboboxItemsNumber.Email:
                    dgvPeopleList.DataSource = clsPeopleBusinessLayer.GetAllPeopleByEmail(text);
                    break;
            }

            lbRecordNumbers.Text = dgvPeopleList.RowCount.ToString();

        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditPerson addEditPerson = new AddEditPerson();
            addEditPerson.StartPosition = FormStartPosition.CenterScreen;
            addEditPerson.AutoScaleMode = AutoScaleMode.None;
            addEditPerson.ShowDialog();
            _RefreshPeopleList();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(comboBox1.SelectedIndex == (int)ComboboxItemsNumber.PersonID 
                || comboBox1.SelectedIndex == (int)ComboboxItemsNumber.Phone)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }

            }
            else
            {
                e.Handled= false;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeopleList.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"select the full line from the left arrow");
                return;
            }

            int personID =
                   Convert.ToInt32(dgvPeopleList.SelectedRows[0].Cells["PersonID"].Value);

            if (clsUserBusinessLayer.IsUserLinked(personID))
            {
                MessageBox.Show(
               @"This Person cannot be deleted because it is linked to existing records in the system."
                   ,"special person",MessageBoxButtons.OK , MessageBoxIcon.Information);
    
                return;
            }

            if (
                MessageBox.Show("Are you sure you want to delete this person","Delete",
                MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes
                )
            {
               
                string ImagePath =
                    (dgvPeopleList.SelectedRows[0].Cells["ImagePath"].Value == DBNull.Value) ?
                    "" : (string)dgvPeopleList.SelectedRows[0].Cells["ImagePath"].Value;
                //null
                if (!string.IsNullOrWhiteSpace(ImagePath)) { File.Delete(ImagePath); }
                clsPeopleBusinessLayer.DeletePerson(personID);
                _RefreshPeopleList();
                lbRecordNumbers.Text = dgvPeopleList.RowCount.ToString();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeopleList.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"select the full line from the left arrow");
                return;
            }
            int personID =
                   Convert.ToInt32(dgvPeopleList.SelectedRows[0].Cells["PersonID"].Value);
            AddEditPerson addEditPerson = new AddEditPerson(personID);
            addEditPerson.StartPosition = FormStartPosition.CenterScreen;
            addEditPerson.AutoScaleMode = AutoScaleMode.None;
            addEditPerson.ShowDialog();
            _RefreshPeopleList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeopleList.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"select the full line from the left arrow");
                return;
            }
            int personID =
                   Convert.ToInt32(dgvPeopleList.SelectedRows[0].Cells["PersonID"].Value);
            PersonInformation PersonInfo = new PersonInformation(personID);
            PersonInfo.StartPosition = FormStartPosition.CenterScreen;
            PersonInfo.AutoScaleMode = AutoScaleMode.None;
            
            PersonInfo.ShowDialog();
            _RefreshPeopleList();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
