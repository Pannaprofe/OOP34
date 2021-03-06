﻿using System;
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
    public partial class GliderDialog : Form
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

        public GliderLaunchType LaunchType
        {
            get 
            { 
                switch (launchTypeComboBox.SelectedIndex)
                {
                    case 0:
                        return GliderLaunchType.TowLaunched;
                    case 1:
                        return GliderLaunchType.Motorized;
                    default:
                        return GliderLaunchType.FootLaunched;
                }
            }
            set 
            { 
                switch (value)
                {
                    case GliderLaunchType.TowLaunched:
                        launchTypeComboBox.SelectedIndex = 0;
                        break;
                    case GliderLaunchType.Motorized:
                        launchTypeComboBox.SelectedIndex = 1;
                        break;
                    default:
                        launchTypeComboBox.SelectedIndex = 2;
                        break;
                }
            }
        }

        public GliderDialog()
        {
            InitializeComponent();
            launchTypeComboBox.SelectedIndex = 0;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            int n;
            if (!(int.TryParse(maxLoadTextBox.Text, out n) && int.TryParse(massTextBox.Text, out n) && int.TryParse(wingspanTextBox.Text, out n)))
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
