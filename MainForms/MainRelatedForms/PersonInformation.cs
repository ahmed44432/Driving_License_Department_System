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
