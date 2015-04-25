using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace AircraftSerializer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var a = new TetheredBalloon();
            //MessageBox.Show(a.ToString());
            //var b = new FreeFloatingBalloon();
            //MessageBox.Show(b.ToString());
            //var c = new Airship();
            //MessageBox.Show(c.ToString());
            //var d = new Airplane();
            //MessageBox.Show(d.ToString());
            //var f = new Glider();
            //MessageBox.Show(f.ToString());
            //var g = new Rotorcraft();
            //MessageBox.Show(g.ToString());
            var h = new Airship();
            aircraftListBox.Items.Add(h);
            infoLabel.Text = h.ToString();
        }

        private void aircraftListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (aircraftListBox.SelectedIndex >= 0)
                infoLabel.Text = aircraftListBox.SelectedItem.ToString();
            else
                infoLabel.Text = "";
        }

        private void createAirplaneButton_Click(object sender, EventArgs e)
        {
            aircraftListBox.Items.Add(new Airplane());
            aircraftListBox.SelectedIndex = aircraftListBox.Items.Count - 1;
            infoLabel.Text = aircraftListBox.SelectedItem.ToString();
        }

        private void createAirshipButton_Click(object sender, EventArgs e)
        {
            aircraftListBox.Items.Add(new Airship());
            aircraftListBox.SelectedIndex = aircraftListBox.Items.Count - 1;
            infoLabel.Text = aircraftListBox.SelectedItem.ToString();
        }

        private void createFreeFloatingBalloonButton_Click(object sender, EventArgs e)
        {
            aircraftListBox.Items.Add(new FreeFloatingBalloon());
            aircraftListBox.SelectedIndex = aircraftListBox.Items.Count - 1;
            infoLabel.Text = aircraftListBox.SelectedItem.ToString();
        }

        private void createTetheredBalloonButton_Click(object sender, EventArgs e)
        {
            aircraftListBox.Items.Add(new TetheredBalloon());
            aircraftListBox.SelectedIndex = aircraftListBox.Items.Count - 1;
            infoLabel.Text = aircraftListBox.SelectedItem.ToString();
        }

        private void createGliderButton_Click(object sender, EventArgs e)
        {
            aircraftListBox.Items.Add(new Glider());
            aircraftListBox.SelectedIndex = aircraftListBox.Items.Count - 1;
            infoLabel.Text = aircraftListBox.SelectedItem.ToString();
        }

        private void createRotorcraftButton_Click(object sender, EventArgs e)
        {
            aircraftListBox.Items.Add(new Rotorcraft());
            aircraftListBox.SelectedIndex = aircraftListBox.Items.Count - 1;
            infoLabel.Text = aircraftListBox.SelectedItem.ToString();
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            if (aircraftListBox.SelectedIndex >= 0)
            {
                ((Aircraft)(aircraftListBox.Items[aircraftListBox.SelectedIndex])).ModifyByDialog();
                aircraftListBox.DisplayMember = "";
                aircraftListBox.DisplayMember = aircraftListBox.SelectedItem.ToString();
                infoLabel.Text = aircraftListBox.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("No items selected.");
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (aircraftListBox.SelectedIndex >= 0)
            {
                aircraftListBox.Items.RemoveAt(aircraftListBox.SelectedIndex);
            }
            else
            {
                MessageBox.Show("No items selected.");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var aircraftArray = aircraftListBox.Items.Cast<Aircraft>().ToArray();

                var file = saveDialog.OpenFile();
                (new SoapFormatter()).Serialize(file, aircraftArray);
                file.Close();
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var file = openDialog.OpenFile();
                var aircraftArray = (Aircraft[])(new SoapFormatter()).Deserialize(file);
                file.Close();

                aircraftListBox.Items.Clear();
                foreach (Aircraft aircraft in aircraftArray)
                {
                    aircraftListBox.Items.Add(aircraft);
                }
            }
        }
    }
}
