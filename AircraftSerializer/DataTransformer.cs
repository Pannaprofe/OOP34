using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AircraftSerializer
{
    class DataTransformer : IDataTransformation
    {
        private List<IDataTransformation> dataTransformations;

        public string Name { get { return "Chain-of-command for data transformations."; } }

        public void AddTransformation(IDataTransformation transformation)
        {
            dataTransformations.Add(transformation);
        }

        public void WriteTransformedData(FileStream stream, Byte[] data)
        {
            switch (dataTransformations.Count)
            {
                case 0:
                    ;
                    break;
                case 1:
                    ;
                    break;
                default:
                    var tempData = data;
                    var tempMStream = new MemoryStream();
                    foreach (IDataTransformation transformation in dataTransformations)
                    {
                        var tempStream = new FileStream("temp", FileMode.Create);
                        transformation.WriteTransformedData(tempStream, tempData);
                        tempStream.CopyTo(tempMStream);
                        tempStream.Dispose();
                        tempData = tempMStream.ToArray();
                        tempMStream = new MemoryStream();
                    }
                    break;
            }
        }

        public Byte[] ReadTransformedData(FileStream stream)
        {
            return new Byte[74];
        }

        public void ConfigureByDialog(object sender, EventArgs e)
        {
            ;
        }
    }
}
