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

            isNameValid();
        }


        private void isNameValid()
        {
            if (string.IsNullOrEmpty(txbFN.Text))
            {
                errorProvider1.SetError(txbFN, "Empty Value");

            }
            else
            {
                errorProvider1.SetError(txbFN, "");
            }

            if (string.IsNullOrEmpty(txbLN.Text))
            {
                errorProvider1.SetError(txbLN, "Empty Value");

            }
            else
            {
                errorProvider1.SetError(txbLN, "");
            }

            if (string.IsNullOrEmpty(txbSD.Text))
            {
                errorProvider1.SetError(txbSD, "Empty Value");

            }
            else
            {
                errorProvider1.SetError(txbSD, "");
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            
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

        private void txbNNO_TextChanged(object sender, EventArgs e)
        {
            isNameValid();
            if (!string.IsNullOrEmpty(txbNNO.Text))
            {
                if (clsPeopleBusinessLayer.IsPersonExist(txbNNO.Text)){
                    errorProvider1.SetError(txbNNO, "this number existes");
                }
                else
                {
                    errorProvider1.SetError(txbNNO, "");
                }
            }
            else
            {
                errorProvider1.SetError(txbNNO, "Empty Value");
            }

        }
    }
}
