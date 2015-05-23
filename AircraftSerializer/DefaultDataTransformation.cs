using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AircraftSerializer
{
    class DefaultDataTransformation : IDataTransformation
    {
        public string Name { get { return "Default"; } }

        public void WriteTransformedData(FileStream stream, Byte[] data)
        {
            stream.Write(data, 0, data.Length);
        }

        public Byte[] ReadTransformedData(FileStream stream)
        {
            var data = new Byte[stream.Length];
            stream.Read(data, 0, data.Length);
            return data;
        }

        public void ConfigureByDialog(object sender, EventArgs e)
        {
            ;
        }
    }
}
