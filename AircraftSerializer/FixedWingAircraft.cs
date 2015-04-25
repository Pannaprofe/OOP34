using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftSerializer
{
    public abstract class FixedWingAircraft : Aerodyne
    {
        public abstract int Wingspan { get; protected set; }
    }
}
