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
        public IDataTransformation DataTransformation;

        public Form1()
        {
            InitializeComponent();

            //parameters for custom buttons
            int buttonCount = 0;
            var gButton = (Button)Controls.Find("createGliderButton", true)[0];
            var ffbButton = (Button)Controls.Find("createTetheredBalloonButton", true)[0];
            var buttonHeight = gButton.Size.Height;
            var buttonWidth = ffbButton.Location.X + ffbButton.Size.Width - gButton.Location.X;
            var buttonX = gButton.Location.X;
            var gapY = gButton.Location.Y - (ffbButton.Location.Y + ffbButton.Size.Height);
            var buttonY = gButton.Location.Y + gButton.Size.Height + gapY;

            //menu for plugin configuration
            MenuStrip menuStrip = default(MenuStrip);
            ToolStripMenuItem settingsMenuItem = default(ToolStripMenuItem);

            //chain-of-command for transformations
            var transformer = new DataTransformer();

            var publicKeyFilePaths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.snk");
            if (publicKeyFilePaths.Count() < 1)
            {
                MessageBox.Show("Could not load plugins: public key file is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var dllPaths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll");
                foreach (String dllPath in dllPaths)
                {
                    var pluginAssembly = Assembly.LoadFrom(dllPath);
                    if (PluginVerification.Verify(pluginAssembly, publicKeyFilePaths[0]))
                    {
                        //signed assemblies

                        foreach (Type type in pluginAssembly.GetExportedTypes())
                        {
                            if (type.GetInterfaces().Contains(typeof(IAircraftClassPlugin)))
                            {
                                var plugin = (IAircraftClassPlugin)type.GetConstructor(Type.EmptyTypes).Invoke(new Object[0]);
                                buttonCount++;

                                Button newButton = new Button();
                                //newButton.Location = new System.Drawing.Point(7, 114 + buttonCount * 37);
                                newButton.Location = new Point(buttonX, buttonY + (buttonCount - 1) * (buttonHeight + gapY));
                                newButton.Name = "create" + plugin.Name + "Button";
                                //newButton.Size = new System.Drawing.Size(206, 30);
                                newButton.Size = new Size(buttonWidth, buttonHeight);
                                newButton.Text = plugin.Name;
                                newButton.UseVisualStyleBackColor = true;
                                newButton.Tag = plugin.AircraftType;
                                newButton.Click += new System.EventHandler(this.dynamicCreateButton_Click);

                                this.Size = new Size(this.Size.Width, this.Size.Height + 37);
                                createGroupBox.Size = new Size(createGroupBox.Size.Width, createGroupBox.Size.Height + 37);
                                createGroupBox.Controls.Add(newButton);
                            }

                            //data transformation plugins
                            if (type.GetInterfaces().Contains(typeof(IDataTransformation)))
                            {
                                var transformation = (IDataTransformation)type.GetConstructor(Type.EmptyTypes).Invoke(new Object[0]);
                                transformer.AddTransformation(transformation);

                                //update menu
                                if (menuStrip == default(MenuStrip))
                                {
                                    menuStrip = new MenuStrip();
                                    settingsMenuItem = new ToolStripMenuItem("Settings");
                                }
                                settingsMenuItem.DropDownItems.Add(new ToolStripMenuItem(transformation.Name, null, new EventHandler(transformation.ConfigureByDialog)));
                            }
                        }
                    }
                    else
                    {
                        //unsigned assemblies

                        foreach (Type type in pluginAssembly.GetExportedTypes())
                        {
                            //SaveOption plugins
                            var saveOptionGUID = typeof(OOP_laba3.SaveOption<>).GUID;
                            if (type.BaseType != null && type.BaseType.GUID == saveOptionGUID)
                            {
                                //create an instance of generic type with Byte as generic type parameter
                                Type constructedType = type.MakeGenericType(typeof(Byte));
                                OOP_laba3.SaveOption<Byte> saveOptionPlugin = (OOP_laba3.SaveOption<Byte>)Activator.CreateInstance(constructedType);
                                var adaptedPlugin = new SaveOptionAdapter(saveOptionPlugin);
                                transformer.AddTransformation(adaptedPlugin);

                                //update menu
                                if (menuStrip == default(MenuStrip))
                                {
                                    menuStrip = new MenuStrip();
                                    settingsMenuItem = new ToolStripMenuItem("Settings");
                                }
                                settingsMenuItem.DropDownItems.Add(new ToolStripMenuItem(adaptedPlugin.Name, null, new EventHandler(adaptedPlugin.ConfigureByDialog)));
                            }
                        }
                    }
                }
            }

            if (menuStrip != default(MenuStrip))
            {
                menuStrip.Items.Add(settingsMenuItem);

                var menuHeight = menuStrip.Size.Height;
                this.Size = new Size(this.Size.Width, this.Size.Height + menuHeight);
                foreach (Control control in this.Controls)
                    control.Location = new Point(control.Location.X, control.Location.Y + menuHeight);

                this.Controls.Add(menuStrip);
            }

            DataTransformation = transformer;
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

                var serializationStream = new MemoryStream();
                (new SoapFormatter()).Serialize(serializationStream, aircraftArray);
                var data = serializationStream.ToArray();
                DataTransformation.WriteTransformedData((FileStream)file, data);

                file.Close();
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var file = openDialog.OpenFile();

                Byte[] data = default(Byte[]);
                try
                {
                    data = DataTransformation.ReadTransformedData((FileStream)file);
                }
                catch
                {
                    MessageBox.Show("File decryption failed: \"" + openDialog.FileName + "\" is not a valid AircraftSerializer file or it was made without encryption.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var deserializationStream = new MemoryStream(data);
                var aircraftArray = (Aircraft[])(new SoapFormatter()).Deserialize(deserializationStream);

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
