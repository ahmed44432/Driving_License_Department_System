using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainRelatedForms
{
    public partial class AddEditPerson : Form
    {
        public AddEditPerson()
        {
            InitializeComponent();
            addingPerson1.OnPersonSaved += Person_DataBack;
            addingPerson1.SetAddMode();
        }
        public AddEditPerson(int personid)
        {
            InitializeComponent();
            addingPerson1.OnPersonSaved += Person_DataBack;
            clsPeopleBusinessLayer p = clsPeopleBusinessLayer.GetPersonByID(personid);
            lbID.Text = p.ID.ToString();
            lbTitel.Text = "  Edit Person";
            _Mode = PersonMode.edit;
            addingPerson1.SetEditMode(p);
        }

        private clsPeopleBusinessLayer _Person_info;
        public enum PersonMode  {add = 0, edit = 1}

        PersonMode _Mode;

        private void Person_DataBack(clsPeopleBusinessLayer person, int mode)
        {
            _Person_info = person;
            _Mode = (PersonMode)mode;

            if (_Person_info.Save())
            {
                MessageBox.Show("Person saved successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save person!");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addingPerson1_Load(object sender, EventArgs e)
        {
            
            
        }
    }
}
