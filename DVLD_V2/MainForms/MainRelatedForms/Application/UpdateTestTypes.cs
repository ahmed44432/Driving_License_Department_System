using System;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms
{
    public partial class UpdateTestTypes : Form
    {
        public UpdateTestTypes(int id)
        {
            InitializeComponent();
            TestType = clsTestTypesBusinessLayer.GetTestTypeByID(id);
            lbID.Text = TestType.ID.ToString();
            txbTitle.Text = TestType.Title;
            txbFees.Text = TestType.Fees.ToString();
            txbDescreption.Text = TestType.Description;
        }

        clsTestTypesBusinessLayer TestType;

        private bool IsValide()
        {
            bool result = true;

            if (string.IsNullOrWhiteSpace(txbTitle.Text))
            {
                errorProvider1.SetError(txbTitle, "its Empty");

                return result = false;
            }
            else
            {
                errorProvider1.SetError(txbTitle, "");
                result = true;
            }

            if (string.IsNullOrWhiteSpace(txbDescreption.Text))
            {
                errorProvider1.SetError(txbDescreption, "its Empty");

                return result = false;
            }
            else
            {
                errorProvider1.SetError(txbDescreption, "");
                result = true;
            }

            if (string.IsNullOrWhiteSpace(txbFees.Text))
            {
                errorProvider1.SetError(txbFees, "its Empty");
                return result = false;
            }
            else
            {
                errorProvider1.SetError(txbFees, "");
                result = true;
            }


            return result;
        }

        private void txbFees_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.' &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValide())
            {
                TestType.Title = txbTitle.Text;
                TestType.Description = txbDescreption.Text;
                int.TryParse(txbFees.Text, out int fees);
                TestType.Fees = fees;
                if (TestType.Save())
                {
                    MessageBox.Show("Updated Successfully");
                }
                else
                {
                    MessageBox.Show("did not Updated");
                }

            }
            else
            {
                MessageBox.Show("Not a Valid Info`s");
            }
        }
    }
}
