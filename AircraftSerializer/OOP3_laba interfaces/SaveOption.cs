using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_laba3
{
    public interface SaveOption<T>
    {
        string Name
        {
            get;
            set;
        }

        void Save(ISerializer<T> animalSerializer, List<T> animals, string path);

        List<T> Load(ISerializer<T> animalSerializer, string path);
    }
}
