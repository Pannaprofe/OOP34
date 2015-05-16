using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AircraftSerializer
{
    public interface IDataTransformationPlugin
    {
        string Name { get; }
        void WriteTransformedData(FileStream file, Byte[] data);
        Byte[] ReadTransformedData(FileStream file);
        void ConfigureByDialog(object sender, EventArgs e);
    }
}
