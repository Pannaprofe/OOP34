using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AircraftSerializer
{
    public class SaveOptionAdapter : IDataTransformation
    {
        private OOP_laba3.SaveOption<Byte> adaptee;

        public SaveOptionAdapter(OOP_laba3.SaveOption<Byte> saveOptionPlugin)
        {
            this.adaptee = saveOptionPlugin;
        }

        public string Name 
        {
            get { return adaptee.Name + " (via SaveOptionAdapter)"; } 
        }

        public void WriteTransformedData(FileStream stream, Byte[] data)
        {
            stream.Close();

            adaptee.Save(new PseudoSerializer(), data.ToList(), stream.Name);
        }

        public Byte[] ReadTransformedData(FileStream stream)
        {
            stream.Close();

            var byteList = adaptee.Load(new PseudoSerializer(), stream.Name);
            return byteList.ToArray();
        }

        public void ConfigureByDialog(object sender, EventArgs e)
        {
            ;
        }
    }

    public class PseudoSerializer : OOP_laba3.ISerializer<Byte>
    {
        public MemoryStream Serialize(List<Byte> items)
        {
            var data = items.ToArray();
            return new MemoryStream(data);
        }

        public List<Byte> Deserialize(string path)
        {
            var fileStream = new FileStream(path, FileMode.Open);
            var data = new Byte[fileStream.Length];
            fileStream.Read(data, 0, data.Length);
            fileStream.Close();

            return data.ToList();
        }
    }
}
