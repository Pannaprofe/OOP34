using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftSerializer
{
    public enum AircraftPropulsionType { Jet, Propeller }

    [Serializable()]
    public abstract class Aircraft : IDialogModifiable
    {
        public abstract int MaxLoad { get; protected set; }
        public abstract int Mass { get; protected set; }
        public abstract void ModifyByDialog();
    }
}
