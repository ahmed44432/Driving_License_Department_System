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
            dgvPeopleList.DataSource = clsPeapleBusinessLayer.GetAllPeople();
        }

    }
}
