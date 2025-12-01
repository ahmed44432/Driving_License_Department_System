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
using DVLD.MainRelatedForms;

namespace DVLD
{
    public partial class PersonDetails : UserControl
    {
        public PersonDetails()
        {
            InitializeComponent();
        }

        clsPeopleBusinessLayer _person = new clsPeopleBusinessLayer();
        

        public void setinfo(clsPeopleBusinessLayer p)
        {
            _person = p;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void PersinDetails_Load(object sender, EventArgs e)
        {
            _RefreshPersonInfo(_person);
        }

        private void _RefreshPersonInfo(clsPeopleBusinessLayer person)
        {
            _person = person;
            lbName.Text =
               person.FirstName + " " + person.SecondName + " " + person.ThirdName
               + " " + person.LastName;
            lbNNO.Text = person.NationalNumber;
            lbGender.Text = person.Gender == 'M' ? "Male" : "Female";
            lbEmail.Text = person.Email;
            lbAddress.Text = person.Address;
            lbPersonID.Text = person.ID.ToString();
            lbPhone.Text = person.Phone;
            lbDateOfBirth.Text = person.DateOfBirth.ToString();
            lbCountry.Text =
            clsCountriesBusinessLayer.GetCountryNameByNumber(person.NationalityCountryID);

            if (!string.IsNullOrEmpty(person.ImagePath))
            {
                pictureBox1.Image = Image.FromFile(person.ImagePath);
                pictureBox1.ImageLocation = person.ImagePath;
            }
            else
            {
                if (person.Gender == 'F')
                {
                    string path = @"C:\Users\DELL\Pictures\person_woman.png";
                    pictureBox1.Image = Image.FromFile(path);
                }
                else
                {
                    string path = @"C:\Users\DELL\Pictures\person_man.png";
                    pictureBox1.Image = Image.FromFile(path);
                }
            }

        }

        private void _DefaultImage(clsPeopleBusinessLayer person)
        {
            if (person.Gender == 'F')
            {
                string path = @"C:\Users\DELL\Pictures\person_woman.png";
                pictureBox1.Image = Image.FromFile(path);
                pictureBox1.ImageLocation = path;
            }
            else
            {
                string path = @"C:\Users\DELL\Pictures\person_man.png";
                pictureBox1.Image = Image.FromFile(path);
                pictureBox1.ImageLocation = path;
            }
        }

        private void lkbEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int personID = _person.ID;
                 
            AddEditPerson addEditPerson = new AddEditPerson(personID);
            addEditPerson.OnInfo += _RefreshPersonInfo;
            addEditPerson.StartPosition = FormStartPosition.CenterScreen;
            addEditPerson.AutoScaleMode = AutoScaleMode.None;
            _DefaultImage(_person);
            addEditPerson.ShowDialog();
            _RefreshPersonInfo(_person);
        }
    }
}
