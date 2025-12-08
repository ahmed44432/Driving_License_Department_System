using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.MainForms.MainRelatedForms
{
    public partial class Filter : UserControl
    {
        public Filter()
        {
            InitializeComponent();
        }

        public delegate void FilterTextHandler (clsPeopleBusinessLayer person);
        public event FilterTextHandler FilterDataBack;

        private clsPeopleBusinessLayer _person;
        private void Filter_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilterDataBack?.Invoke(_person);
        }

        enum ComboboxItemsNumber
        {
            PersonID = 0, NationaNO = 1, FirstName = 2,
            SecondName = 3, ThirdName = 4, LastName = 5,
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            clsPeopleBusinessLayer person = new clsPeopleBusinessLayer();

            switch ((ComboboxItemsNumber)comboBox1.SelectedIndex)
            {
                case ComboboxItemsNumber.PersonID:
                    if (int.TryParse(text, out int id))
                        person = clsPeopleBusinessLayer.GetPersonByID(id);
                    break;

                case ComboboxItemsNumber.NationaNO:
                    person = clsPeopleBusinessLayer.GetPersonByNationalNO(text);
                    break;

                case ComboboxItemsNumber.FirstName:
                    person = clsPeopleBusinessLayer.GetPersonByFirstName(text);
                    break;

                case ComboboxItemsNumber.SecondName:
                    person = clsPeopleBusinessLayer.GetPersonBySecondName(text);
                    break;

                case ComboboxItemsNumber.ThirdName:
                    person = clsPeopleBusinessLayer.GetPersonByThirdName(text);
                    break;

                case ComboboxItemsNumber.LastName:
                    person = clsPeopleBusinessLayer.GetPersonByLastName(text);
                    break;

            }

            _person = person;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedIndex == (int)ComboboxItemsNumber.PersonID)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
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
