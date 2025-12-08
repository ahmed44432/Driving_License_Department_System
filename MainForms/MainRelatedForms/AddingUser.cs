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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.MainForms.MainRelatedForms
{
    public partial class AddingUser : UserControl
    {
        public AddingUser()
        {
            InitializeComponent();
            filter1.FilterDataBack += DataResever;
        }


        public void DataResever (clsPeopleBusinessLayer person)
        {
            personDetails1.setinfo(person);
        }

        private void filter1_Load(object sender, EventArgs e)
        {

        }
    }
}
