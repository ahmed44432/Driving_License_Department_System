using System;
using System.IO;
using System.Data;
using System.Drawing;
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

        public delegate void SendPersonDelegate(clsPeopleBusinessLayer person,int mode);

        int _Mode = 0; // add = 0, edit = 1;

        public event SendPersonDelegate OnPersonSaved;

        public void SetAddMode()
        {
            _Mode = 0;
            person = new clsPeopleBusinessLayer();
            
        }

        public void SetEditMode(clsPeopleBusinessLayer p)
        {
            _Mode = 1;
            person = p;
            LoadPersonToEdit(p.ID);
            
        }
        private void AddingPerson_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                // Minimal safe initialization for designer
                if (cbxCountry.Items.Count == 0)
                {
                    cbxCountry.Items.Add("--- Design Mode ---");
                    cbxCountry.SelectedIndex = 0;
                }
                dtpDATEOFBIRTH.MaxDate = DateTime.Now;
                if (rbMALE.Checked == false && rbFemale.Checked == false)
                    rbMALE.Checked = true;
                return;
            }

            // === Real runtime code ===
            DataTable dtCountries = clsCountriesBusinessLayer.GetAllCoutries();
            cbxCountry.DataSource = dtCountries;
            cbxCountry.DisplayMember = "CountryName";
            cbxCountry.ValueMember = "CountryID";
            cbxCountry.SelectedIndex = 2;

            dtpDATEOFBIRTH.MaxDate = DateTime.Now;

            IICH._destinationPath = person.ImagePath;
            IICH._sourcePath = person.ImagePath;
            IICH._oldPath = person.ImagePath;

            if (_Mode == 0)
                rbMALE.Checked = true;

            IsValidForSave();
        }

        string ImageFilePath = @"C:\Users\Ahmed\Desktop\DVLD\DVLD_People_Images";

        
         
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
                    if (_Mode == 1)
                    {
                        if(txbNNO.Text == person.NationalNumber)
                            result = true;
                    }
                    else
                    {
                        errorProvider1.SetError(txbNNO, "this number existes");
                        return false;
                    }
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


            if (string.IsNullOrWhiteSpace(txbPHONE.Text)
                || (!int.TryParse(txbPHONE.Text,out int tp)) 
                || (txbPHONE.Text.Length > 10))
            {
                errorProvider1.SetError(txbPHONE, "Empty Value OR Not a Number OR Bigger Than 10 Chars");
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

        public void LoadPersonToEdit(int personID)
        {
            _Mode = 1;  

            clsPeopleBusinessLayer personToEdit = 
                clsPeopleBusinessLayer.GetPersonByID(personID);

            if (personToEdit == null)
            {
                MessageBox.Show("Person Not Found");
                return;
            }

            // Fill the textboxes
            txbFN.Text = personToEdit.FirstName;
            txbLN.Text = personToEdit.LastName;
            txbTH.Text = personToEdit.ThirdName;
            txbSD.Text = personToEdit.SecondName;
            txbNNO.Text = personToEdit.NationalNumber;
            txbADDRESS.Text = personToEdit.Address;
            txbEMAIL.Text = personToEdit.Email;
            txbPHONE.Text = personToEdit.Phone;
            dtpDATEOFBIRTH.Value = personToEdit.DateOfBirth;

            //rbMALE.Checked = personToEdit.Gender == 'M';
            //rbFemale.Checked = personToEdit.Gender == 'F';

            if (personToEdit.Gender == 'M')
            {
                rbMALE.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;    
            }


                cbxCountry.SelectedValue = personToEdit.NationalityCountryID;

            // Load image
            if (!string.IsNullOrWhiteSpace(personToEdit.ImagePath) && File.Exists(personToEdit.ImagePath))
            {
                pictureBox1.ImageLocation = personToEdit.ImagePath;
                lkbRemoveImage.Visible = true;
            }
            else
            {
                lkbRemoveImage.Visible = false;
            }

           
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
           if (!IsValidForSave())
            {
                MessageBox.Show("FILL the Box ","gg",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

             _Mode = 1;

           
             if (string.IsNullOrWhiteSpace(IICH._sourcePath)) { pictureBox1.ImageLocation = ""; }
             else if (IICH._sourcePath != IICH._destinationPath)
            { File.Copy(IICH._sourcePath, IICH._destinationPath, true); }


            pictureBox1.ImageLocation = IICH._destinationPath == null ? "" : IICH._destinationPath;  
            person.ImagePath = pictureBox1.ImageLocation;
            person.NationalityCountryID = (int)cbxCountry.SelectedValue;


            if (!(string.IsNullOrEmpty(IICH._oldPath)))
            {

                string tmp = "";


                if (!string.IsNullOrEmpty(IICH._destinationPath))
                {
                   tmp = Path.GetDirectoryName(IICH._destinationPath);
                }

                tmp = Path.GetDirectoryName(IICH._oldPath);

                if (tmp == ImageFilePath)
                {

                    if (IICH._oldPath != IICH._destinationPath)
                    {
                        File.Delete(IICH._oldPath);
                        person.ImagePath =
                            IICH._destinationPath == "" ? "" : pictureBox1.ImageLocation; 
                    }

                }

            }

            //OnPersonAdded?.Invoke(person,_Mode);

            if (_Mode == 0)
                OnPersonSaved?.Invoke(person, 0);
            else
                OnPersonSaved?.Invoke(person, 1);

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

        private struct st_info_image_chaine
        {
            public string _oldPath;
            public string _sourcePath;
            public string _destinationPath;
        }

        st_info_image_chaine IICH;

        private void lkbSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            openFileDialog1.Title = "Smile :)";
            openFileDialog1.FileName = "Picture";
            openFileDialog1.Filter =
                @"Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)
                    |*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            //string ImageFilePath = @"C:\Users\DELL\source\repos\DVLD\DVLD_People_Images";

            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                string sourcePath = openFileDialog1.FileName;
                string guid = Guid.NewGuid().ToString();
                string ext = Path.GetExtension(sourcePath).ToLower();

                if (ext != ".jpg" && ext != ".png" && ext != ".jpeg" && ext != ".jpg")
                {
                    MessageBox.Show("Only JPG or PNG or jpg or jpeg images are supported. Please select a valid image.",
                                    "Invalid File Type",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
               
                Directory.CreateDirectory(ImageFilePath);
                string newFileName = guid + ext;
                string destinationPath = Path.Combine(ImageFilePath, newFileName);
                IICH._sourcePath = sourcePath;
                IICH._destinationPath = destinationPath;

                pictureBox1.Image = Image.FromFile(sourcePath);
                lkbRemoveImage.Visible = true;
                
                
            }
        }

        private void rbMALE_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(person.ImagePath)
                || (lkbRemoveImage.Visible == false))
            {

                pictureBox1.Image = Properties.Resources.person_man;
                
            }
            
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(person.ImagePath) 
                || (lkbRemoveImage.Visible == false))
            {

                pictureBox1.Image = Properties.Resources.person_woman;
               
            }
        }

        private void lkbRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (rbMALE.Checked)
            {
                pictureBox1.Image = Properties.Resources.person_man;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.person_woman;
            }

            lkbRemoveImage.Visible = false;
            pictureBox1.ImageLocation = "";
            IICH._sourcePath = "";
            IICH._destinationPath = "";

        }


    }


}
