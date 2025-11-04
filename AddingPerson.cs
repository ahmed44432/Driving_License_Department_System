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
    }
}
