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

        public PersonInformation()
        {
            InitializeComponent();
        }

        public void LoadPesronInfoByOBJ(clsPeopleBusinessLayer person)
        {
            personDetails1.setinfo(person);
        }

        

    }
}
