using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftSerializer
{
    public interface IAircraftSerializerPlugin
    {
        string Name { get; }
        Type AircraftType { get; }
    }
}
