using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AircraftSerializer;
using System.Security.Cryptography;

namespace EncryptionPlugin
{
    public enum DataEncryptionAlgorythm { AES, TripleDES }

    public class EncryptionPlugin : IDataTransformationPlugin
    {
        public DataEncryptionAlgorythm EncryptionAlgorythm;
        private Byte[] _Key, _IV;

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

        public EncryptionPlugin(DataEncryptionAlgorythm encryptionAlgorythm)
        {
            this.EncryptionAlgorythm = encryptionAlgorythm;

            this._Key = new Byte[16];
            this._IV = new Byte[16];
            var randomizer = new Random();
            randomizer.NextBytes(this._Key);
            randomizer.NextBytes(this._IV);
        }

        public EncryptionPlugin(DataEncryptionAlgorythm encryptionAlgorythm, Byte[] key, Byte[] iv)
        {
            this.EncryptionAlgorythm = encryptionAlgorythm;
            this.Key = key;
            this.IV = iv;
        }

        public void WriteTransformedData(FileStream file, Byte[] data)
        {
            if (EncryptionAlgorythm == DataEncryptionAlgorythm.AES)
                AesWrite(file, data);
            else
                TripleDesWrite(file, data);
        }

        public Byte[] ReadTransformedData(FileStream file)
        {
            if (EncryptionAlgorythm == DataEncryptionAlgorythm.AES)
                return AesRead(file);
            else
                return TripleDesRead(file);
        }

        private void AesWrite(FileStream file, Byte[] data)
        {
            var crStream = new CryptoStream(file, (new AesManaged()).CreateEncryptor(_Key, _IV), CryptoStreamMode.Write);
            crStream.Write(data, 0, data.Length);
            crStream.Flush();
            crStream.Close();
        }

        private void TripleDesWrite(FileStream file, Byte[] data)
        {
            var crStream = new CryptoStream(file, (new TripleDESCryptoServiceProvider()).CreateEncryptor(_Key, _IV.Take(8).ToArray()), CryptoStreamMode.Write);
            crStream.Write(data, 0, data.Length);
            crStream.Flush();
            crStream.Close();
        }

        private Byte[] AesRead(FileStream file)
        {
            var crStream = new CryptoStream(file, (new AesManaged()).CreateDecryptor(_Key, _IV), CryptoStreamMode.Read);
            var data = new Byte[file.Length];
            crStream.Read(data, 0, data.Length);
            crStream.Close();
            return data;
        }

        private Byte[] TripleDesRead(FileStream file)
        {
            var crStream = new CryptoStream(file, (new TripleDESCryptoServiceProvider()).CreateDecryptor(_Key, _IV.Take(8).ToArray()), CryptoStreamMode.Read);
            var data = new Byte[file.Length];
            crStream.Read(data, 0, data.Length);
            crStream.Close();
            return data;
        }

        public void ConfigureByDialog()
        {
            ;
        }
    }
}
