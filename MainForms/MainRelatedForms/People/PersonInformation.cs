using System;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms
{
    public partial class PersonInformation : Form
    {
        public PersonInformation(int PN)
        {
            InitializeComponent();
            clsPeopleBusinessLayer p = clsPeopleBusinessLayer.GetPersonByID(PN);
           personDetails1.setinfo(p);
           
        }

        private void PersonInformation_Load(object sender, EventArgs e)
        {

        }

        

    }
}
