using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftSerializer
{
    public enum AirshipType { Rigid, NonRigid }

    class Airship : Aerostat
    {
        public override int MaxLoad { get; protected set; }
        public override int Mass { get; protected set; }
        public override int Gasbags { get { return 1; } }
        public override int Volume { get; protected set; }
        public AirshipType Type { get; protected set; }
        public AircraftPropulsionType PropulsionType { get; protected set; }

        public override void ModifyByDialog()
        {
            var dialog = new AirshipDialog();
            dialog.MaxLoad = this.MaxLoad;
            dialog.Mass = this.Mass;
            dialog.Volume = this.Volume;
            dialog.Type = this.Type;
            dialog.PropulsionType = this.PropulsionType;
            dialog.ShowDialog();

            this.MaxLoad = dialog.MaxLoad;
            this.Mass = dialog.Mass;
            this.Volume = dialog.Volume;
            this.Type = dialog.Type;
            this.PropulsionType = dialog.PropulsionType;
        }

        public Airship(int maxLoad, int mass, int volume, AirshipType type, AircraftPropulsionType propulsionType)
        {
            this.MaxLoad = maxLoad;
            this.Mass = mass;
            this.Volume = volume;
            this.Type = type;
            this.PropulsionType = propulsionType;
        }

        public Airship()
        {
            var dialog = new AirshipDialog();
            dialog.ShowDialog();

            this.MaxLoad = dialog.MaxLoad;
            this.Mass = dialog.Mass;
            this.Volume = dialog.Volume;
            this.Type = dialog.Type;
            this.PropulsionType = dialog.PropulsionType;
        }

        public override string ToString()
        {
            return String.Format("Tethered Balloon \nMax load: {0} \nMass: {1} \nGasbags: {2} \nVolume: {3} \nType: {4} \nPropulsion type: {5}", MaxLoad, Mass, Gasbags, Volume, Type, PropulsionType);
        }
    }
}
