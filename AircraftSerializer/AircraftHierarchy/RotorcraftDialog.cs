using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AircraftSerializer
{
    public partial class RotorcraftDialog : Form
    {
        public int MaxLoad 
        { 
            get { return Convert.ToInt32(maxLoadTextBox.Text); }
            set { maxLoadTextBox.Text = Convert.ToString(value); }
        }

        public int Mass
        {
            get { return Convert.ToInt32(massTextBox.Text); }
            set { massTextBox.Text = Convert.ToString(value); }
        }

        public int Blades
        {
            get { return Convert.ToInt32(bladesTextBox.Text); }
            set { bladesTextBox.Text = Convert.ToString(value); }
        }

        public RotorcraftRotorType RotorType
        {
            get { return (rotorTypeComboBox.SelectedIndex == 0) ? RotorcraftRotorType.Powered : RotorcraftRotorType.Unpowered; }
            set { rotorTypeComboBox.SelectedIndex = (value == RotorcraftRotorType.Powered) ? 0 : 1; }
        }

        public RotorcraftDialog()
        {
            InitializeComponent();
            rotorTypeComboBox.SelectedIndex = 0;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            int n;
            if (!(int.TryParse(maxLoadTextBox.Text, out n) && int.TryParse(massTextBox.Text, out n) && int.TryParse(bladesTextBox.Text, out n)))
            {
                MessageBox.Show("Invalid input.");
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
    }
}
