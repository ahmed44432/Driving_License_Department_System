using System;
using System.Windows.Forms;
using BusinessLayer;


namespace DVLD.MainForms.MainRelatedForms
{
    public partial class UpdateApplicationType : Form
    {

        public UpdateApplicationType(int id)
        {
            InitializeComponent();
            apptype = clsApplicationTypesBusinessLayer.GetAppTypeByID(id);
            lbID.Text = apptype.ID.ToString();
            txbTitle.Text = apptype.Title;
            txbFees.Text = apptype.Fees.ToString();
        }

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
                errorProvider1.SetError(txbTitle,"");
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


        clsApplicationTypesBusinessLayer apptype;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValide())
            {
                apptype.Title = txbTitle.Text;
                int.TryParse(txbFees.Text, out int fees);
                apptype.Fees = fees;
                if (apptype.Save()) {
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
