using System;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms
{
    public partial class PersonFilter : UserControl
    {
        public PersonFilter()
        {
            InitializeComponent();
            filter1.FilterDataBack += DataResever;
        }

        clsPeopleBusinessLayer _person;

        public delegate void ReturnInfo(clsPeopleBusinessLayer person);
        public event ReturnInfo OnPersonReturned;


        public void DataResever(clsPeopleBusinessLayer person)
        {
            personDetails1.setinfo(person);
            _person = person;
            OnPersonReturned?.Invoke(person);
        }

    }
}
