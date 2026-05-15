using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using Microsoft.Win32;
using BusinessLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            chkRM.Checked = true;
            txbPS.PasswordChar = '*';

        }

        public delegate void GetUser(clsUserBusinessLayer user);
        public event GetUser GetUserInfo;


        public clsUserBusinessLayer _user;

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            Return_Recourd_from_Registry();
        }

        private void lnbMoreInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Browser browser = new Browser();
            browser.Show();

        }

        //string File_path = @"C:\Users\Ahmed\Desktop\DVLD\DVLD_V2\UsersFastLogin";
        string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD_UsersFastLogin";


        string line;
        string valueName = "UserInfo";
        int key = 5;


        public string EncryptWord(string word, int key)
        {
            string Encrypted_Word = "";

            foreach (char ch in word)
            {
                Encrypted_Word += (char)(ch + key);
            }

            return Encrypted_Word;
        }

        public string DecryptWord(string word, int key)
        {
            string Decrypted_Word = "";

            foreach (char ch in word)
            {
                Decrypted_Word += (char)(ch - key);
            }

            return Decrypted_Word;
        }


        private void AddRecourd_InFile(string path, string UN,string PS)
        {
            UN = EncryptWord(UN, key);
            PS = EncryptWord(PS, key);
            line = UN + "##" + PS;
            //File.Encrypt(path);
            File.AppendAllText(path, line);
            line = string.Empty;
        }

        private void Return_Recourd_from_File(string path)
        {
            //File.Decrypt(path);
            
            line = File.ReadAllText(path);
            if (line == string.Empty) { return; }

            string[] info = new string[2];
            info = line.Split(new string[] { "##" },StringSplitOptions.None);

            txbUN.Text = DecryptWord(info[0],key);
            txbPS.Text = DecryptWord(info[1], key);
        }


        private void AddRecourdToRegistry(string UN, string PS)
        {
            UN = EncryptWord(UN, key);
            PS = EncryptWord(PS, key);
            line = UN + "##" + PS;

            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath, valueName, line, RegistryValueKind.String);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void Return_Recourd_from_Registry()
        {
            

            try
            {
                // Read the value from the Registry
                line = Registry.GetValue(keyPath, valueName, null) as string;

                if (line == string.Empty) { return; }

                string[] info = new string[2];
                info = line.Split(new string[] { "##" }, StringSplitOptions.None);

                txbUN.Text = DecryptWord(info[0], key);
                txbPS.Text = DecryptWord(info[1], key);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {

                if (clsUserBusinessLayer.IsUserExistes(txbUN.Text, txbPS.Text))
                {
                    if (!clsUserBusinessLayer.IsUserActive(txbUN.Text))
                    {
                        MessageBox.Show("User is Inactive","",
                            MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                    clsUserBusinessLayer user =
                        clsUserBusinessLayer.GetUserByUserName(txbUN.Text);
                    _user = user;
                    // عند نجاح تسجيل الدخول
                    
                    GetUserInfo?.Invoke(_user);
                    MessageBox.Show("welcome :)");
                   

                    if (chkRM.Checked)
                    {
                        //File.WriteAllText(File_path, string.Empty);
                        //AddRecourd_InFile(File_path, txbUN.Text, txbPS.Text);
                        AddRecourdToRegistry(txbUN.Text, txbPS.Text);
                    }
                    else
                    {
                        AddRecourdToRegistry("","");
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    //MainForm main = new MainForm();
                    //main.Show();
                    //this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Password or User Name");
                }
            }


        }

        private bool IsValid()
        {
            bool isvalid = true;

            if (string.IsNullOrWhiteSpace(txbUN.Text))
            {
               
                isvalid= false;
                errorProvider1.SetError(txbUN, "User Name is Empty");
            }
            else
            {
                errorProvider1.SetError(txbUN, "");
            }

            if (string.IsNullOrWhiteSpace(txbPS.Text))
            {
                isvalid= false;
                errorProvider1.SetError(txbPS, "Password is Empty");
            }
            else
            {
                errorProvider1.SetError(txbPS, "");
            }

            if (!isvalid) { System.Media.SystemSounds.Exclamation.Play(); }

            return isvalid;
        }
    }
}
