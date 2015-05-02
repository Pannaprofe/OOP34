using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitePlugin
{
    public partial class KiteDialog : Form
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

        public int Wingspan
        {
            get { return Convert.ToInt32(wingspanTextBox.Text); }
            set { wingspanTextBox.Text = Convert.ToString(value); }
        }

        public int Tethers
        {
            get { return Convert.ToInt32(tethersTextBox.Text); }
            set { tethersTextBox.Text = Convert.ToString(value); }
        }

        public KiteDialog()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            int n;
            if (!(int.TryParse(maxLoadTextBox.Text, out n) && int.TryParse(massTextBox.Text, out n) && int.TryParse(wingspanTextBox.Text, out n) && int.TryParse(tethersTextBox.Text, out n)))
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
