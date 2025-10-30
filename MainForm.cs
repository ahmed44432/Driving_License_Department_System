using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.MainRelatedForms;

namespace DVLD
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void tspmiPeople_Click(object sender, EventArgs e)
        {
            PeopleForm peopleForm = new PeopleForm();
            peopleForm.StartPosition = FormStartPosition.CenterScreen;
            peopleForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            CenterPictureBox();
            
        }

        private void CenterPictureBox()
        {
            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = (this.ClientSize.Height - pictureBox1.Height) / 2;
        }

     
    }
}
