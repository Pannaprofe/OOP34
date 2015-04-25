using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftSerializer
{
    public enum AerodyneLiftType { Aerodynamic, Thrust }

    public abstract class Aerodyne : Aircraft
    {
        public abstract AerodyneLiftType LiftType { get; }
    }
}
