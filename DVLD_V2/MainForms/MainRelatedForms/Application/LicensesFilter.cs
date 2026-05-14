using System;
using System.Windows.Forms;
using BusinessLayer;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.MainForms.MainRelatedForms.Application
{
    public partial class LicensesFilter : UserControl
    {
        public LicensesFilter()
        {
            InitializeComponent();
        }

        public delegate void FilterTextHandler(clsLicensesBusinessLayer license);
        public event FilterTextHandler FilterDataBack;
        private clsLicensesBusinessLayer _license;

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int licenseid)) {
                _license =
                    clsLicensesBusinessLayer.GetLicenseByLicenseID(licenseid);
                if (_license != null)
                    driverLicenseInfo1.LoadInfoByObj(_license);
                else
                {
                    MessageBox.Show("Not Found !!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    driverLicenseInfo1.LoadInfoByObj(_license);
                }
            }
            FilterDataBack?.Invoke(_license);
        }








    }
}
