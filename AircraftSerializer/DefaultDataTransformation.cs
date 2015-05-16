using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AircraftSerializer
{
    class DefaultDataTransformation : IDataTransformationPlugin
    {
        public string Name { get { return "Default"; } } 

        public void WriteTransformedData(FileStream file, Byte[] data)
        {
            file.Write(data, 0, data.Length);
        }

        public Byte[] ReadTransformedData(FileStream file)
        {
            var data = new Byte[file.Length];
            file.Read(data, 0, data.Length);
            return data;
        }

        public void ConfigureByDialog(object sender, EventArgs e)
        {
            ;
        }
    }
}
