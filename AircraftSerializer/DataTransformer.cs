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

        public DataTransformer()
        {
            dataTransformations = new List<IDataTransformation>();
        }

        public void AddTransformation(IDataTransformation transformation)
        {
            dataTransformations.Add(transformation);
        }

        public void WriteTransformedData(FileStream stream, Byte[] data)
        {
            switch (dataTransformations.Count)
            {
                case 0:
                    DefaultDataTransformation.Instance.WriteTransformedData(stream, data);
                    break;

                case 1:
                    dataTransformations[0].WriteTransformedData(stream, data);
                    break;

                default:
                    var tempData = data;
                    var tempMStream = new MemoryStream();
                    foreach (IDataTransformation transformation in dataTransformations)
                    {
                        var tempStream = new FileStream("temp", FileMode.Create);
                        transformation.WriteTransformedData(tempStream, tempData);
                        try
                        {
                            tempStream.CopyTo(tempMStream);
                        }
                        catch
                        {
                            tempStream = new FileStream("temp", FileMode.Open);
                            tempStream.CopyTo(tempMStream);
                        }
                        tempStream.Close();
                        tempData = tempMStream.ToArray();
                        tempMStream = new MemoryStream();
                    }

                    DefaultDataTransformation.Instance.WriteTransformedData(stream, tempData);
                    break;
            }
        }

        public Byte[] ReadTransformedData(FileStream stream)
        {
            Byte[] data = new Byte[0];

            switch (dataTransformations.Count)
            {
                case 0:
                    data = DefaultDataTransformation.Instance.ReadTransformedData(stream);
                    break;

                case 1:
                    data = dataTransformations[0].ReadTransformedData(stream);
                    break;

                default:
                    var tempMStream = new MemoryStream();
                    stream.CopyTo(tempMStream);

                    for (int i = dataTransformations.Count - 1; i >= 0; i--)
                    {
                        var tempStream = new FileStream("temp", FileMode.Create);
                        tempMStream.Seek(0, SeekOrigin.Begin);
                        tempMStream.CopyTo(tempStream);
                        data = dataTransformations[i].ReadTransformedData(tempStream);
                        tempStream.Close();
                        tempMStream = new MemoryStream(data);
                    }
                    break;
            }

            return data;
        }

        public void ConfigureByDialog(object sender, EventArgs e)
        {
            ;
        }
    }
}
