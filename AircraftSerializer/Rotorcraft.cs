using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftSerializer
{
    public enum RotorcraftRotorType { Powered, Unpowered }

    public class Rotorcraft : Aerodyne
    {
        public override int MaxLoad { get; protected set; }
        public override int Mass { get; protected set; }
        public override AerodyneLiftType LiftType { get { return AerodyneLiftType.Aerodynamic; } }
        public int Blades { get; protected set; }
        public RotorcraftRotorType RotorType { get; protected set; }

        public override void ModifyByDialog()
        {
            var dialog = new RotorcraftDialog();
            dialog.MaxLoad = this.MaxLoad;
            dialog.Mass = this.Mass;
            dialog.Blades = this.Blades;
            dialog.RotorType = this.RotorType;
            dialog.ShowDialog();

            this.MaxLoad = dialog.MaxLoad;
            this.Mass = dialog.Mass;
            this.Blades = dialog.Blades;
            this.RotorType = dialog.RotorType;
        }

        public Rotorcraft(int maxLoad, int mass, int volume, RotorcraftRotorType type)
        {
            this.MaxLoad = maxLoad;
            this.Mass = mass;
            this.Blades = volume;
            this.RotorType = type;
        }

        public Rotorcraft()
        {
            var dialog = new RotorcraftDialog();
            dialog.ShowDialog();

            this.MaxLoad = dialog.MaxLoad;
            this.Mass = dialog.Mass;
            this.Blades = dialog.Blades;
            this.RotorType = dialog.RotorType;
        }

        public override string ToString()
        {
            return String.Format("Rotorcraft \nMax load: {0} \nMass: {1} \nLift type: {2} \nBlades: {3} \nRotor type: {4}", MaxLoad, Mass, LiftType, Blades, RotorType);
        }
    }
}
