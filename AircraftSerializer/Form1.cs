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
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;

namespace AircraftSerializer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var publicKeyFilePaths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.snk");
            if (publicKeyFilePaths.Count() < 1)
            {
                MessageBox.Show("Could not load plugins: public key file is missing.");
            }
            else
            {
                var dllPaths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll");
                foreach (String dllPath in dllPaths)
                {
                    var pluginAssembly = Assembly.LoadFrom(dllPath);
                    if (PluginVerification.Verify(pluginAssembly, publicKeyFilePaths[0]))
                    {
                        int buttonCount = 0;
                        foreach (Type type in pluginAssembly.GetExportedTypes())
                        {
                            if (type.GetInterfaces().Contains(typeof(IAircraftSerializerPlugin)))
                            {
                                var plugin = (IAircraftSerializerPlugin)type.GetConstructor(Type.EmptyTypes).Invoke(new Object[0]);
                                buttonCount++;

                                Button newButton = new Button();
                                newButton.Location = new System.Drawing.Point(7, 114 + buttonCount * 37);
                                newButton.Name = "create" + plugin.Name + "Button";
                                newButton.Size = new System.Drawing.Size(206, 30);
                                newButton.Text = plugin.Name;
                                newButton.UseVisualStyleBackColor = true;
                                newButton.Tag = plugin.AircraftType;
                                newButton.Click += new System.EventHandler(this.dynamicCreateButton_Click);

                                this.Size = new Size(this.Size.Width, this.Size.Height + 37);
                                createGroupBox.Size = new Size(createGroupBox.Size.Width, createGroupBox.Size.Height + 37);
                                createGroupBox.Controls.Add(newButton);
                            }
                        }
                    }
                }
            }
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

        private void dynamicCreateButton_Click(object sender, EventArgs e)
        {
            var newAircraft = ((Type)((Button)sender).Tag).GetConstructor(Type.EmptyTypes).Invoke(new Object[0]);
            aircraftListBox.Items.Add(newAircraft);
            aircraftListBox.SelectedIndex = aircraftListBox.Items.Count - 1;
            infoLabel.Text = aircraftListBox.SelectedItem.ToString();
        }
    }
}
