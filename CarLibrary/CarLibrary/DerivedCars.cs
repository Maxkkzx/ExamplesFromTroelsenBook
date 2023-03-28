using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarLibrary
{
    internal class SportsCar : Car
    {
        public SportsCar() { }
        public SportsCar(string name, int maxSp, int curSp)
            : base(name, maxSp, curSp) { }

        public override void TurboBoost()
        {
            MessageBox.Show("Ramming speed!", "Faster is better...");
        }
    }

    internal class MiniVan : Car
    {
        public MiniVan() { }
        public MiniVan(string name, int maxSp, int curSp)
            : base (name, maxSp, curSp) { }

        public override void TurboBoost()
        {
            egnState = EngineState.engineDead;
            MessageBox.Show("Eek!", "Your engine block exploded!");
        }
    }
}
