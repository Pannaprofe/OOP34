using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AircraftSerializer;

namespace KitePlugin
{
    [Serializable()]
    public class Kite : FixedWingAircraft
    {
        public override int MaxLoad { get; protected set; }
        public override int Mass { get; protected set; }
        public override AerodyneLiftType LiftType { get { return AerodyneLiftType.Aerodynamic; } }
        public override int Wingspan { get; protected set; }
        public int Tethers { get; protected set; }

        public override void ModifyByDialog()
        {
            var dialog = new KiteDialog();
            dialog.MaxLoad = this.MaxLoad;
            dialog.Mass = this.Mass;
            dialog.Wingspan = this.Wingspan;
            dialog.Tethers = this.Tethers;
            dialog.ShowDialog();

            this.MaxLoad = dialog.MaxLoad;
            this.Mass = dialog.Mass;
            this.Wingspan = dialog.Wingspan;
            this.Tethers = dialog.Tethers;
        }

        public Kite(int maxLoad, int mass, int volume, int tethers)
        {
            this.MaxLoad = maxLoad;
            this.Mass = mass;
            this.Wingspan = volume;
            this.Tethers = tethers;
        }

        public Kite()
        {
            var dialog = new KiteDialog();
            dialog.ShowDialog();

            this.MaxLoad = dialog.MaxLoad;
            this.Mass = dialog.Mass;
            this.Wingspan = dialog.Wingspan;
            this.Tethers = dialog.Tethers;
        }

        public override string ToString()
        {
            return String.Format("Kite \nMax load: {0} \nMass: {1} \nLift type: {2} \nWingspan: {3} \nTethers: {4}", MaxLoad, Mass, LiftType, Wingspan, Tethers);
        }
    }
}
