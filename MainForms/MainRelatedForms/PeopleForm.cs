using System;
using System.IO;
using System.Windows.Forms;
using BusinessLayer;

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
            if(comboBox1.SelectedIndex != (int) ComboboxItemsNumber.None) {
                if (int.TryParse(textBox1.Text, out int id))
                {
                    if (comboBox1.SelectedIndex == (int)ComboboxItemsNumber.PersonID)
                    {
                        dgvPeopleList.DataSource = 
                            clsPeopleBusinessLayer.GetAllPeopleBYID(id);
                        
                    }
                    lbRecordNumbers.Text = dgvPeopleList.RowCount.ToString();
                    return;
                }
                if (comboBox1.SelectedIndex == (int)ComboboxItemsNumber.NationaNO) {

                    dgvPeopleList.DataSource = 
                        clsPeopleBusinessLayer.GetAllPeopleByNationalNO(textBox1.Text);
                    lbRecordNumbers.Text = dgvPeopleList.RowCount.ToString();
                    return;
                }
                if (comboBox1.SelectedIndex == (int)ComboboxItemsNumber.FirstName)
                {

                    dgvPeopleList.DataSource =
                        clsPeopleBusinessLayer.GetAllPeopleByFirstName(textBox1.Text);
                    lbRecordNumbers.Text = dgvPeopleList.RowCount.ToString();
                    return;
                }
                if (comboBox1.SelectedIndex == (int)ComboboxItemsNumber.SecondName)
                {

                    dgvPeopleList.DataSource =
                        clsPeopleBusinessLayer.GetAllPeopleBySecondName(textBox1.Text);
                    lbRecordNumbers.Text = dgvPeopleList.RowCount.ToString();
                    return;
                }
                if (comboBox1.SelectedIndex == (int)ComboboxItemsNumber.ThirdName)
                {

                    dgvPeopleList.DataSource =
                        clsPeopleBusinessLayer.GetAllPeopleByThirdName(textBox1.Text);
                    lbRecordNumbers.Text = dgvPeopleList.RowCount.ToString();
                    return;
                }
                if (comboBox1.SelectedIndex == (int)ComboboxItemsNumber.LastName)
                {

                    dgvPeopleList.DataSource =
                        clsPeopleBusinessLayer.GetAllPeopleByLastName(textBox1.Text);
                    lbRecordNumbers.Text = dgvPeopleList.RowCount.ToString();
                    return;
                }
                if (comboBox1.SelectedIndex == (int)ComboboxItemsNumber.Nationality)
                {

                    dgvPeopleList.DataSource =
                        clsPeopleBusinessLayer.GetAllPeopleByNationality(textBox1.Text);
                    lbRecordNumbers.Text = dgvPeopleList.RowCount.ToString();   
                    return;
                }
                if (comboBox1.SelectedIndex == (int)ComboboxItemsNumber.Gender)
                {
                    textBox1.MaxLength = 1;
                    dgvPeopleList.DataSource =
                        clsPeopleBusinessLayer.GetAllPeopleByGender(textBox1.Text);
                    textBox1.MaxLength = Int16.MaxValue;
                    lbRecordNumbers.Text = dgvPeopleList.RowCount.ToString();
                    return;
                }
                if (comboBox1.SelectedIndex == (int)ComboboxItemsNumber.Phone)
                {

                    dgvPeopleList.DataSource =
                        clsPeopleBusinessLayer.GetAllPeopleByPhone(textBox1.Text);
                    lbRecordNumbers.Text = dgvPeopleList.RowCount.ToString();
                    return;
                }
                if (comboBox1.SelectedIndex == (int)ComboboxItemsNumber.Email)
                {

                    dgvPeopleList.DataSource =
                        clsPeopleBusinessLayer.GetAllPeopleByEmail(textBox1.Text);
                    lbRecordNumbers.Text = dgvPeopleList.RowCount.ToString();
                    return;
                }

            }
           
        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
                return;
            int personID =
                Convert.ToInt32(dgvPeopleList.SelectedRows[0].Cells["PersonID"].Value);
            string ImagePath =(string)
                dgvPeopleList.SelectedRows[0].Cells["ImagePath"].Value;
            if (!string.IsNullOrWhiteSpace(ImagePath)) { File.Delete(ImagePath); }
            clsPeopleBusinessLayer.DeletePerson(personID);
            _RefreshPeopleList();
            lbRecordNumbers.Text = dgvPeopleList.RowCount.ToString();
        }
    }
}
