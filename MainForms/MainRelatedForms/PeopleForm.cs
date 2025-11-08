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
            switch (comboBox1.SelectedIndex)
            {
                case 0 :
                    _RefreshPeopleList();
                    textBox1.Clear();
                    textBox1.Visible = false; break;
                case 1 :
                    textBox1.Visible = true; break;

            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int id))
            {
                dgvPeopleList.DataSource = clsPeopleBusinessLayer.GetAllPeopleBYID(id);
            }
        }
    }
}
