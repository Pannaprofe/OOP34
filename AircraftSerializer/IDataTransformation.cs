using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AircraftSerializer
{
    public interface IDataTransformation
    {
        string Name { get; }
        void WriteTransformedData(FileStream stream, Byte[] data);
        Byte[] ReadTransformedData(FileStream stream);
        void ConfigureByDialog(object sender, EventArgs e);
    }
}
