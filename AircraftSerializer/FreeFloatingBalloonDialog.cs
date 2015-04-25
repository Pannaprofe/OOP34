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
    public partial class FreeFloatingBalloonDialog : Form
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

        public int Volume
        {
            get { return Convert.ToInt32(volumeTextBox.Text); }
            set { volumeTextBox.Text = Convert.ToString(value); }
        }

        public FreeFloatingBalloonType Type
        {
            get { return (typeComboBox.SelectedIndex == 0) ? FreeFloatingBalloonType.HotAir : FreeFloatingBalloonType.Gas; }
            set { typeComboBox.SelectedIndex = (value == FreeFloatingBalloonType.HotAir) ? 0 : 1; }
        }

        public FreeFloatingBalloonDialog()
        {
            InitializeComponent();
            typeComboBox.SelectedIndex = 0;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            int n;
            if (!(int.TryParse(maxLoadTextBox.Text, out n) && int.TryParse(massTextBox.Text, out n) && int.TryParse(volumeTextBox.Text, out n)))
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
