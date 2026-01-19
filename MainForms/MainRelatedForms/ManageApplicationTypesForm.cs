using System;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms
{
    public partial class ManageApplicationTypesForm : Form
    {
        public ManageApplicationTypesForm()
        {
            InitializeComponent();
            

            dgvManageApplicationTypes.ReadOnly = true;
            dgvManageApplicationTypes.AllowUserToAddRows = false;
            dgvManageApplicationTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _RefreshApplicationTypes();


            dgvManageApplicationTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvManageApplicationTypes.Columns[0].FillWeight = 20;
            dgvManageApplicationTypes.Columns[1].FillWeight = 60;
            dgvManageApplicationTypes.Columns[2].FillWeight = 20;


        }

        private void _RefreshApplicationTypes()
        {
            dgvManageApplicationTypes.DataSource =
                clsApplicationTypesBusinessLayer.GetAllclsApplicationTypes();
            lbRecordNumbers.Text = dgvManageApplicationTypes.RowCount.ToString();   

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int ID =
                   Convert.ToInt32(dgvManageApplicationTypes.SelectedRows[0].Cells["ID"].Value);
            UpdateApplicationType updateApplicationType = new UpdateApplicationType(ID);
            updateApplicationType.StartPosition = FormStartPosition.CenterScreen;
            updateApplicationType.ShowDialog();
            _RefreshApplicationTypes();

        }
    }
}
