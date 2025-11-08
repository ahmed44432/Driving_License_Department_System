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

namespace DVLD
{
    public partial class AddingPerson : UserControl
    {
        public AddingPerson()
        {
            InitializeComponent();
        }

        clsPeopleBusinessLayer person = new clsPeopleBusinessLayer();

        public delegate void SendPersonDelegate(clsPeopleBusinessLayer person);

        public event SendPersonDelegate OnPersonAdded;
        private void AddingPerson_Load(object sender, EventArgs e)
        {
            DataTable dtCountries = clsCountriesBusinessLayer.GetAllCoutries();

            cbxCountry.DataSource = dtCountries;             // ربط الجدول بالكومبوبوكس
            cbxCountry.DisplayMember = "CountryName";        // العمود الذي سيظهر للمستخدم
            cbxCountry.ValueMember = "CountryID";            // العمود الذي يُستخدم داخليًا
            cbxCountry.SelectedIndex = 2;
            dtpDATEOFBIRTH.MaxDate = DateTime.Now;
            rbMALE.Checked = true;

            IsValidForSave();
        }


        private bool IsValidForSave()
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(txbFN.Text))
            {
                errorProvider1.SetError(txbFN, "Empty Value");
                result = false;
            }
            else
            {
                errorProvider1.SetError(txbFN, "");
                result = true;
            }

            if (string.IsNullOrWhiteSpace(txbLN.Text))
            {
                errorProvider1.SetError(txbLN, "Empty Value");
                result = false;
            }
            else
            {
                errorProvider1.SetError(txbLN, "");
                result = true;
            }

            if (string.IsNullOrWhiteSpace(txbSD.Text))
            {
                errorProvider1.SetError(txbSD, "Empty Value");
                result = false;
            }
            else
            {
                errorProvider1.SetError(txbSD, "");
                result = true;
            }

            if (!string.IsNullOrWhiteSpace(txbNNO.Text))
            {
                if (clsPeopleBusinessLayer.IsPersonExist(txbNNO.Text))
                {
                    errorProvider1.SetError(txbNNO, "this number existes");
                    result = false;
                }
                else
                {
                    errorProvider1.SetError(txbNNO, "");
                    result = true;
                }
            }
            else
            {
                errorProvider1.SetError(txbNNO, "Empty Value");
                result = false;
            }

            if (string.IsNullOrWhiteSpace(txbADDRESS.Text))
            {
                errorProvider1.SetError(txbADDRESS, "Empty Value");
                result = false;
            }
            else
            {
                errorProvider1.SetError(txbADDRESS, "");
                result = true;
            }


            if (string.IsNullOrWhiteSpace(txbPHONE.Text))
            {
                errorProvider1.SetError(txbPHONE, "Empty Value");
                result = false;
            }
            else
            {
                errorProvider1.SetError(txbPHONE, "");
                result = true;
            }

            if (!string.IsNullOrWhiteSpace(txbEMAIL.Text))
            {
                if (!CheckEmail(txbEMAIL.Text))
                {
                    errorProvider1.SetError(txbEMAIL, "Invalid Email");
                    result = false;
                }
                else
                {
                    errorProvider1.SetError(txbEMAIL, "");
                    result = true;
                }
            }

            return result;
        }
    

        private void btnSave_Click(object sender, EventArgs e)
        {
           
           if (!IsValidForSave())
            {
                MessageBox.Show("FILL the TANck ","gg",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            } 
            
          
            
            person.FirstName = txbFN.Text;
            person.LastName = txbLN.Text;
            person.ThirdName = txbTH.Text;
            person.SecondName = txbSD.Text;
            person.NationalNumber = txbNNO.Text;
            person.Gender = rbMALE.Checked ? 'M' : 'F';
            person.Address = txbADDRESS.Text;
            person.Email = txbEMAIL.Text;
            person.Phone = txbPHONE.Text;
            person.DateOfBirth = dtpDATEOFBIRTH.Value;
            person.ImagePath = "";
            person.NationalityCountryID = (int)cbxCountry.SelectedValue;

            OnPersonAdded?.Invoke(person);

        }
        private void dtpDATEOFBIRTH_ValueChanged(object sender, EventArgs e)
        {
            //dtpDATEOFBIRTH.MaxDate = DateTime.Now;
        }

        private bool CheckEmail(string Email)
        {
          
            int atIndex = Email.IndexOf("@");
            int LastIndexOF = Email.LastIndexOf("@");

            if (atIndex <= 0 || atIndex != LastIndexOF){ return false; }

            int dotIndex = Email.IndexOf(".");

            if (dotIndex < atIndex) {  return false; }

            if (dotIndex == Email.Length - 1) { return false; }

            return true;
        }

        private void lkbSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                MessageBox.Show(openFileDialog1.FileName);
            }
        }
    }


}
