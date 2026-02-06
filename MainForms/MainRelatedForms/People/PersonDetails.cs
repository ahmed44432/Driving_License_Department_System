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
using DVLD.MainForms.MainRelatedForms;
using DVLD.MainRelatedForms;

namespace DVLD
{
    public partial class PersonDetails : UserControl
    {
        public PersonDetails()
        {
            InitializeComponent();
            _DefLabels();
            
        }

        clsPeopleBusinessLayer _person = new clsPeopleBusinessLayer();
        

        public void setinfo(clsPeopleBusinessLayer p)
        {
            _person = p;
            _RefreshPersonInfo(_person);
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void _DefLabels()
        {
          
            lbName.Text = "[????]";
            lbNNO.Text = "[????]";
            lbGender.Text = "[????]";
            lbEmail.Text = "[????]";
            lbAddress.Text = "[????]";
            lbPersonID.Text = "[????]";
            lbPhone.Text = "[????]";
            lbDateOfBirth.Text = "[????]";
            lbCountry.Text = "[????]";
            pictureBox1.Image = Properties.Resources.person_man;
            lkbEditPerson.Enabled = false;
            
            
        }

        private void PersinDetails_Load(object sender, EventArgs e)
        {
            _RefreshPersonInfo(_person);
        }

        private void _RefreshPersonInfo(clsPeopleBusinessLayer person)
        {

            if(person == null || person.ID == -1)
            {
                _DefLabels();
                return;
            }

            // YOU SHOULDNT EDIT THIS TYPE OF USERS BUT I WILL ALLOW IT ;)

            //clsUserBusinessLayer user =
            //    clsUserBusinessLayer.GetUserByPersonID(person.ID);
            //if (user != null && user.UserID != -1)
            //{
            //    if (clsUserBusinessLayer.IsUserLinked(user.UserID))
            //    {
            //        lkbEditPerson.Enabled = false;
            //    }
            //    else
            //    {
            //        lkbEditPerson.Enabled = true;
            //    }
            //}
            //else
            //{
            //    lkbEditPerson.Enabled = true;
            //}

            lkbEditPerson.Enabled = true;

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
                    pictureBox1.Image = Properties.Resources.person_woman;
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.person_man;
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
