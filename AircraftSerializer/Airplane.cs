using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftSerializer
{
    public class Airplane : FixedWingAircraft
    {
        public override int MaxLoad { get; protected set; }
        public override int Mass { get; protected set; }
        public override AerodyneLiftType LiftType { get { return AerodyneLiftType.Aerodynamic; } }
        public override int Wingspan { get; protected set; }
        public AircraftPropulsionType PropulsionType { get; protected set; }

        public override void ModifyByDialog()
        {
            var dialog = new AirplaneDialog();
            dialog.MaxLoad = this.MaxLoad;
            dialog.Mass = this.Mass;
            dialog.Wingspan = this.Wingspan;
            dialog.PropulsionType = this.PropulsionType;
            dialog.ShowDialog();

            this.MaxLoad = dialog.MaxLoad;
            this.Mass = dialog.Mass;
            this.Wingspan = dialog.Wingspan;
            this.PropulsionType = dialog.PropulsionType;
        }

        public Airplane(int maxLoad, int mass, int volume, AircraftPropulsionType type)
        {
            this.MaxLoad = maxLoad;
            this.Mass = mass;
            this.Wingspan = volume;
            this.PropulsionType = type;
        }

        public Airplane()
        {
            var dialog = new AirplaneDialog();
            dialog.ShowDialog();

            this.MaxLoad = dialog.MaxLoad;
            this.Mass = dialog.Mass;
            this.Wingspan = dialog.Wingspan;
            this.PropulsionType = dialog.PropulsionType;
        }

        public override string ToString()
        {
            return String.Format("Airplane \nMax load: {0} \nMass: {1} \nLift type: {2} \nWingspan: {3} \nType: {4}", MaxLoad, Mass, LiftType, Wingspan, PropulsionType);
        }
    }
}
