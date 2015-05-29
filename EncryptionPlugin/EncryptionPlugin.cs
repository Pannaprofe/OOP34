using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AircraftSerializer;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace EncryptionPlugin
{
    public enum DataEncryptionAlgorithm { AES, TripleDES }

    public class EncryptionPlugin : IDataTransformation
    {
        public string Name { get { return "Encryption"; } } 

        public DataEncryptionAlgorithm EncryptionAlgorithm;
        private Byte[] _Key, _IV;
        private bool IV16Bytes;

        public Byte[] Key
        {
            get { return _Key; }
            set 
            {
                if (value.Length < 16)
                    throw new Exception("Key must be 16 bytes long.");

                if (value.Length > 16)
                    _Key = value.Take(16).ToArray();
                else
                    _Key = value;
            }
        }

        public Byte[] IV
        {
            get { return _IV; }
            set
            {
                if (value.Length < 8)
                    throw new Exception("IV must be 8 (for TripleDES) or 16 (for AES) bytes long.");

                if (value.Length > 16)
                    _IV = value.Take(16).ToArray();
                else
                    _IV = value;
            }
        }

        public EncryptionPlugin()
        {
            this.EncryptionAlgorithm = DataEncryptionAlgorithm.AES;
            SearchForKeyFile();
        }

        public EncryptionPlugin(DataEncryptionAlgorithm encryptionAlgorithm)
        {
            this.EncryptionAlgorithm = encryptionAlgorithm;
            SearchForKeyFile();
        }

        public EncryptionPlugin(DataEncryptionAlgorithm encryptionAlgorithm, Byte[] key, Byte[] iv)
        {
            this.EncryptionAlgorithm = encryptionAlgorithm;
            this.Key = key;
            this.IV = iv;
        }

        public void WriteTransformedData(FileStream stream, Byte[] data)
        {
            if (EncryptionAlgorithm == DataEncryptionAlgorithm.AES)
                AesWrite(stream, data);
            else
                TripleDesWrite(stream, data);
        }

        public Byte[] ReadTransformedData(FileStream stream)
        {
            if (EncryptionAlgorithm == DataEncryptionAlgorithm.AES)
                return AesRead(stream);
            else
                return TripleDesRead(stream);
        }

        private void AesWrite(Stream stream, Byte[] data)
        {
            var crStream = new CryptoStream(stream, (new AesManaged()).CreateEncryptor(_Key, _IV), CryptoStreamMode.Write);
            crStream.Write(data, 0, data.Length);
            crStream.Flush();
            crStream.Close();
        }

        private void TripleDesWrite(Stream stream, Byte[] data)
        {
            var crStream = new CryptoStream(stream, (new TripleDESCryptoServiceProvider()).CreateEncryptor(_Key, _IV.Take(8).ToArray()), CryptoStreamMode.Write);
            crStream.Write(data, 0, data.Length);
            crStream.Flush();
            crStream.Close();
        }

        private Byte[] AesRead(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var crStream = new CryptoStream(stream, (new AesManaged()).CreateDecryptor(_Key, _IV), CryptoStreamMode.Read);
            var data = new Byte[stream.Length];
            crStream.Read(data, 0, data.Length);
            crStream.Close();
            return data;
        }

        private Byte[] TripleDesRead(Stream stream)
        {
            var crStream = new CryptoStream(stream, (new TripleDESCryptoServiceProvider()).CreateDecryptor(_Key, _IV.Take(8).ToArray()), CryptoStreamMode.Read);
            var data = new Byte[stream.Length];
            crStream.Read(data, 0, data.Length);
            crStream.Close();
            return data;
        }

        public void ConfigureByDialog(object sender, EventArgs e)
        {
            var dialog = new EncryptionSettingsDialog();
            dialog.CallingObject = this;
            dialog.Algorithm = this.EncryptionAlgorithm;
            dialog.IV16Bytes = this.IV16Bytes;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.EncryptionAlgorithm = dialog.Algorithm;
                this.IV16Bytes = dialog.IV16Bytes;
            }
        }

        private void RandomizeKeys()
        {
            this._Key = new Byte[16];
            this._IV = new Byte[16];
            var randomizer = new Random();
            randomizer.NextBytes(this._Key);
            randomizer.NextBytes(this._IV);

            this.IV16Bytes = true;
        }

        internal bool ReadKeyFile(String filePath)
        {
            var keyFileContents = File.ReadAllLines(filePath);
            if (keyFileContents.Length != 2 || keyFileContents[0].Length < 16 || keyFileContents[1].Length < 8)
            {
                MessageBox.Show("Encryption key file is not valid, key has been randomized. \nPlease specify a valid key file before opening/saving a file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RandomizeKeys();
                return true;
            }
            else
            {
                this._Key = Encoding.Default.GetBytes(keyFileContents[0]).Take(16).ToArray();
                if (keyFileContents[1].Length < 16)
                {
                    this._IV = Encoding.Default.GetBytes(keyFileContents[1]).Take(8).ToArray();
                    this.IV16Bytes = false;
                    this.EncryptionAlgorithm = DataEncryptionAlgorithm.TripleDES;
                    MessageBox.Show("Current IV is 8 bytes long, which is not enough for AES. \nPlease specify a key file with 16-byte IV to use AES.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    this._IV = Encoding.Default.GetBytes(keyFileContents[1]).Take(16).ToArray();
                    this.IV16Bytes = true;
                    return true;
                }
            }
        }

        private bool SearchForKeyFile()
        {
            var keyFilePaths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.epk");
            if (keyFilePaths.Count() < 1)
            {
                MessageBox.Show("Encryption key file not found, key has been randomized. \nPlease specify a valid key file before opening/saving a file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RandomizeKeys();
                return true;
            }
            else
            {
                return ReadKeyFile(keyFilePaths[0]);
            }
        }
    }
}
