using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftSerializer
{
    public abstract class Aerostat : Aircraft
    {
        public abstract int Gasbags { get; }
        public abstract int Volume { get; protected set; }
    }
}
