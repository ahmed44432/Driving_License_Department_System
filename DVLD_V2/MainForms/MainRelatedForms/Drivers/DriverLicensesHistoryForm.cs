using System;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms.Drivers
{
    public partial class DriverLicensesHistoryForm : Form
    {
        public DriverLicensesHistoryForm()
        {
            InitializeComponent();

        }

        clsPeopleBusinessLayer _person;

        public void LoadInfo(string nno)
        {
            _person = clsPeopleBusinessLayer.GetPersonByNationalNO(nno);
            personDetails1.setinfo(_person);
            driverLicensesHistory1.LoadInfo(nno);
        }


    }
}
