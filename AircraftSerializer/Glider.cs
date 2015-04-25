using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftSerializer
{
    public enum GliderLaunchType { TowLaunched, FootLaunched, Motorized }

    [Serializable()]
    public class Glider : FixedWingAircraft
    {
        public override int MaxLoad { get; protected set; }
        public override int Mass { get; protected set; }
        public override AerodyneLiftType LiftType { get { return AerodyneLiftType.Aerodynamic; } }
        public override int Wingspan { get; protected set; }
        public GliderLaunchType LaunchType { get; protected set; }

        public override void ModifyByDialog()
        {
            var dialog = new GliderDialog();
            dialog.MaxLoad = this.MaxLoad;
            dialog.Mass = this.Mass;
            dialog.Wingspan = this.Wingspan;
            dialog.LaunchType = this.LaunchType;
            dialog.ShowDialog();

            this.MaxLoad = dialog.MaxLoad;
            this.Mass = dialog.Mass;
            this.Wingspan = dialog.Wingspan;
            this.LaunchType = dialog.LaunchType;
        }

        public Glider(int maxLoad, int mass, int volume, GliderLaunchType type)
        {
            this.MaxLoad = maxLoad;
            this.Mass = mass;
            this.Wingspan = volume;
            this.LaunchType = type;
        }

        public Glider()
        {
            var dialog = new GliderDialog();
            dialog.ShowDialog();

            this.MaxLoad = dialog.MaxLoad;
            this.Mass = dialog.Mass;
            this.Wingspan = dialog.Wingspan;
            this.LaunchType = dialog.LaunchType;
        }

        public override string ToString()
        {
            return String.Format("Glider \nMax load: {0} \nMass: {1} \nLift type: {2} \nWingspan: {3} \nLaunch type: {4}", MaxLoad, Mass, LiftType, Wingspan, LaunchType);
        }
    }
}
