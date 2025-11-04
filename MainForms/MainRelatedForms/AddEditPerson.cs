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
            addingPerson1.OnPersonAdded += Person_DataBack;
        }

        clsPeopleBusinessLayer Person_info;

        private void Person_DataBack(clsPeopleBusinessLayer person)
        {
            Person_info = person;

            if (Person_info.Save())
                MessageBox.Show("Person saved successfully!");
            else
                MessageBox.Show("Failed to save person!");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEditPerson_Load(object sender, EventArgs e)
        {

           
        }
    }
}
