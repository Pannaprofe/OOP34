using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AircraftSerializer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var a = new TetheredBalloon();
            //MessageBox.Show(a.ToString());
            //var b = new FreeFloatingBalloon();
            //MessageBox.Show(b.ToString());
            //var c = new Airship();
            //MessageBox.Show(c.ToString());
            //var d = new Airplane();
            //MessageBox.Show(d.ToString());
            //var f = new Glider();
            //MessageBox.Show(f.ToString());
            var g = new Rotorcraft();
            MessageBox.Show(g.ToString());
        }
    }
}
