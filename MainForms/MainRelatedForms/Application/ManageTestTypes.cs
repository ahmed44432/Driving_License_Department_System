using System;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms
{
    public partial class ManageTestTypes : Form
    {
        public ManageTestTypes()
        {
            InitializeComponent();

            dgvManageTestTypes.ReadOnly = true;
            dgvManageTestTypes.AllowUserToAddRows = false;
            dgvManageTestTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _RefreshTestTypes();


            dgvManageTestTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvManageTestTypes.Columns[0].FillWeight = 40;
            dgvManageTestTypes.Columns[1].FillWeight = 100;
            dgvManageTestTypes.Columns[2].FillWeight = 200;
            dgvManageTestTypes.Columns[3].FillWeight = 40;
        }

        private void _RefreshTestTypes()
        {
            dgvManageTestTypes.DataSource =
                clsTestTypesBusinessLayer.GetTestTypes();
            lbRecordNumbers.Text = dgvManageTestTypes.RowCount.ToString();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID =
                  Convert.ToInt32(dgvManageTestTypes.SelectedRows[0].Cells["ID"].Value);
            UpdateTestTypes updateTestTypes = new UpdateTestTypes(ID);
            updateTestTypes.StartPosition = FormStartPosition.CenterScreen;
            updateTestTypes.ShowDialog();
            _RefreshTestTypes();
        }
    }
}
