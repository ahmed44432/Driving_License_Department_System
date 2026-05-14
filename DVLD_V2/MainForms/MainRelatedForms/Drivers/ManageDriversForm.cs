
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms.Drivers
{
    public partial class ManageDriversForm : Form
    {
        public ManageDriversForm()
        {
            InitializeComponent();

            dgvDrivers.ReadOnly = true;
            dgvDrivers.AllowUserToAddRows = false;

            dgvDrivers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDrivers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            _RefreshDgvDrivers();

        }


        private void _RefreshDgvDrivers()
        {
            dgvDrivers.DataSource =
              clsDriversBusinessLayer.GetAllDrivers();
            lbRecordNumbers.Text = dgvDrivers.RowCount.ToString();

        }


        enum ComboboxItemsNumber
        {
            None = 0, DriverID = 1, PersonID = 2, NationalNo = 3 ,
            FullName = 4
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            if (comboBox1.SelectedIndex == (int)ComboboxItemsNumber.None)
                return;


            switch ((ComboboxItemsNumber)comboBox1.SelectedIndex)
            {
                case ComboboxItemsNumber.DriverID:

                    if (int.TryParse(textBox1.Text, out int driverid))
                        dgvDrivers.DataSource =
                            clsDriversBusinessLayer.GetAllDriversByDriverID(driverid);
                    break;

                case ComboboxItemsNumber.PersonID:

                    if (int.TryParse(textBox1.Text, out int personid))
                        dgvDrivers.DataSource =
                            clsDriversBusinessLayer.GetAllDriversByPersonID(personid);
                    break;

                case ComboboxItemsNumber.NationalNo:

                    dgvDrivers.DataSource =
                       clsDriversBusinessLayer.GetAllDriversByNationalNO(textBox1.Text);
                    break;

                case ComboboxItemsNumber.FullName:

                    dgvDrivers.DataSource =
                       clsDriversBusinessLayer.GetAllDriversByFullName(textBox1.Text);
                    break;


                default:
                    break;


            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                _RefreshDgvDrivers();
                textBox1.Clear();
                textBox1.Visible = false;
                
            }
            else
            {
                
                textBox1.Visible = true;
            }

           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedIndex == (int)ComboboxItemsNumber.PersonID
               || comboBox1.SelectedIndex == (int)ComboboxItemsNumber.DriverID)
            {
                if (!char.IsDigit(e.KeyChar) &&
                    e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }

            }
            else
            {
                e.Handled = false;
            }
        }



















    }
}
