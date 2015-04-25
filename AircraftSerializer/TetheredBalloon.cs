using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftSerializer
{
    public class TetheredBalloon : Aerostat
    {
        public override int MaxLoad { get; protected set; }
        public override int Mass { get; protected set; }
        public override int Gasbags { get { return 1; } }
        public override int Volume { get; protected set; }
        public int Tethers { get; protected set; }

        public override void ModifyByDialog()
        {
            var dialog = new TetheredBalloonDialog();
            dialog.MaxLoad = this.MaxLoad;
            dialog.Mass = this.Mass;
            dialog.Volume = this.Volume;
            dialog.Tethers = this.Tethers;
            dialog.ShowDialog();

            this.MaxLoad = dialog.MaxLoad;
            this.Mass = dialog.Mass;
            this.Volume = dialog.Volume;
            this.Tethers = dialog.Tethers;
        }

        public TetheredBalloon(int maxLoad, int mass, int volume, int tethers)
        {
            this.MaxLoad = maxLoad;
            this.Mass = mass;
            this.Volume = volume;
            this.Tethers = tethers;
        }

        public TetheredBalloon()
        {
            var dialog = new TetheredBalloonDialog();
            dialog.ShowDialog();

            this.MaxLoad = dialog.MaxLoad;
            this.Mass = dialog.Mass;
            this.Volume = dialog.Volume;
            this.Tethers = dialog.Tethers;
        }

        public override string ToString()
        {
            return String.Format("Tethered Balloon \nMax load: {0} \nMass: {1} \nGasbags: {2} \nVolume: {3} \nTethers: {4}", MaxLoad, Mass, Gasbags, Volume, Tethers);
        }
    }
}
