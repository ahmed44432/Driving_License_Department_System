using System;
using System.IO;
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

        string ImageFilePath = @"C:\Users\DELL\source\repos\DVLD\DVLD_People_Images";
         
        private bool IsValidForSave()
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(txbFN.Text))
            {
                errorProvider1.SetError(txbFN, "Empty Value");
                return  false;
            }
            else
            {
                errorProvider1.SetError(txbFN, "");
                result = true;
            }

            if (string.IsNullOrWhiteSpace(txbLN.Text))
            {
                errorProvider1.SetError(txbLN, "Empty Value");
                return false;
            }
            else
            {
                errorProvider1.SetError(txbLN, "");
                result = true;
            }

            if (string.IsNullOrWhiteSpace(txbSD.Text))
            {
                errorProvider1.SetError(txbSD, "Empty Value");
                 return  false;
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
                    return false;
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
                return false;
            }

            if (string.IsNullOrWhiteSpace(txbADDRESS.Text))
            {
                errorProvider1.SetError(txbADDRESS, "Empty Value");
                return false;
            }
            else
            {
                errorProvider1.SetError(txbADDRESS, "");
                result = true;
            }


            if (string.IsNullOrWhiteSpace(txbPHONE.Text))
            {
                errorProvider1.SetError(txbPHONE, "Empty Value");
                return false;
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
                    return false;
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
            if (string.IsNullOrWhiteSpace(pictureBox1.ImageLocation)) {  pictureBox1.ImageLocation = ""; }
            person.ImagePath = pictureBox1.ImageLocation;
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

            openFileDialog1.Title = "Smile :)";
            string guid = Guid.NewGuid().ToString();
            openFileDialog1.FileName = "Picture";
            openFileDialog1.Filter =
                @"Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)
                    |*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            //string ImageFilePath = @"C:\Users\DELL\source\repos\DVLD\DVLD_People_Images";

            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                string sourcePath = openFileDialog1.FileName;
                string ext = Path.GetExtension(sourcePath).ToLower();

                if (ext != ".jpg" && ext != ".png")
                {
                    MessageBox.Show("Only JPG or PNG images are supported. Please select a valid image.",
                                    "Invalid File Type",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
               
                Directory.CreateDirectory(ImageFilePath);
                string newFileName = guid + ext;
                string destinationPath = Path.Combine(ImageFilePath, newFileName);
                File.Copy(sourcePath, destinationPath, true);

                pictureBox1.Image = Image.FromFile(destinationPath);
                pictureBox1.ImageLocation = destinationPath;
                
            }
        }

        private void rbMALE_CheckedChanged(object sender, EventArgs e)
        {
            string path = @"C:\Users\DELL\Pictures\person_man.png";
            pictureBox1.Image = Image.FromFile(path);
            //pictureBox1.ImageLocation = path;  
            
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            string path = @"C:\Users\DELL\Pictures\person_woman.png";
            pictureBox1.Image = Image.FromFile(path);
            //pictureBox1.ImageLocation = path;  
            
        }
    }


}
