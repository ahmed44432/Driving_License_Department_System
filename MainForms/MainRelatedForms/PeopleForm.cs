using System;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainRelatedForms
{
    public partial class PeopleForm : Form
    {
        public PeopleForm()
        {
            InitializeComponent();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != 0) {
                if (int.TryParse(textBox1.Text, out int id))
                {
                    if (comboBox1.SelectedIndex == 1)
                    {
                        dgvPeopleList.DataSource = clsPeopleBusinessLayer.GetAllPeopleBYID(id);
                    }
                
                }
                if (comboBox1.SelectedIndex == 2) {

                    dgvPeopleList.DataSource = 
                        clsPeopleBusinessLayer.GetAllPeopleByNationalNO(textBox1.Text);
                
                }
            }
           
        }
    }
}
