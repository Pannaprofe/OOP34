using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitePlugin
{
    public class KitePlugin : AircraftSerializer.IAircraftSerializerPlugin
    {
        public string Name { get { return "Kite"; } }
        public Type AircraftType { get { return typeof(Kite); } }
    }
}
