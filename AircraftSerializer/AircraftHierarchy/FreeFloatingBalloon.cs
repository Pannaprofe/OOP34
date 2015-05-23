using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftSerializer
{
    public enum FreeFloatingBalloonType { HotAir, Gas }

    [Serializable()]
    class FreeFloatingBalloon : Aerostat
    {
        public override int MaxLoad { get; protected set; }
        public override int Mass { get; protected set; }
        public override int Gasbags { get { return 1; } }
        public override int Volume { get; protected set; }
        public FreeFloatingBalloonType Type { get; protected set; }

        public override void ModifyByDialog()
        {
            var dialog = new FreeFloatingBalloonDialog();
            dialog.MaxLoad = this.MaxLoad;
            dialog.Mass = this.Mass;
            dialog.Volume = this.Volume;
            dialog.Type = this.Type;
            dialog.ShowDialog();

            this.MaxLoad = dialog.MaxLoad;
            this.Mass = dialog.Mass;
            this.Volume = dialog.Volume;
            this.Type = dialog.Type;
        }

        public FreeFloatingBalloon(int maxLoad, int mass, int volume, FreeFloatingBalloonType type)
        {
            this.MaxLoad = maxLoad;
            this.Mass = mass;
            this.Volume = volume;
            this.Type = type;
        }

        public FreeFloatingBalloon()
        {
            var dialog = new FreeFloatingBalloonDialog();
            dialog.ShowDialog();

            this.MaxLoad = dialog.MaxLoad;
            this.Mass = dialog.Mass;
            this.Volume = dialog.Volume;
            this.Type = dialog.Type;
        }

        public override string ToString()
        {
            return String.Format("Free-floating Balloon \nMax load: {0} \nMass: {1} \nGasbags: {2} \nVolume: {3} \nType: {4}", MaxLoad, Mass, Gasbags, Volume, Type);
        }
    }
}
