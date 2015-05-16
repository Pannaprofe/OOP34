using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptionPlugin
{
    public partial class EncryptionSettingsDialog : Form
    {
        public bool IV16Bytes;
        public DataEncryptionAlgorithm Algorithm
        {
            get
            {
                if (algoComboBox.SelectedIndex == 0)
                    return DataEncryptionAlgorithm.AES;
                else
                    return DataEncryptionAlgorithm.TripleDES;
            }
            set
            {
                if (value == DataEncryptionAlgorithm.AES)
                    algoComboBox.SelectedIndex = 0;
                else
                    algoComboBox.SelectedIndex = 1;
            }
        }
        public EncryptionPlugin CallingObject;

        public EncryptionSettingsDialog()
        {
            InitializeComponent();
            algoComboBox.SelectedIndex = 0;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (algoComboBox.SelectedIndex == 0 || IV16Bytes == false)
                MessageBox.Show("Current IV length is 8 bytes, while AES requires a 16-byte IV.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                IV16Bytes = CallingObject.ReadKeyFile(openDialog.FileName);
            }
        }
    }
}
