using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThisChain
{
    public class Motorcycle
    {
        public int driverIntensity;
        public string driverName;

        public Motorcycle() { }
        public Motorcycle(int intensity)
            :this(intensity, "") { }
        public Motorcycle(string name)
            : this(0, name) { }
        public Motorcycle(int intensity, string name)
        {
            if(intensity > 10)
            {
                intensity = 10;
            }
            driverIntensity = intensity;
            driverName = name;
        }

        public void ShowMoto()
        {
            Console.Write(driverIntensity + " " + driverName);
        }
    }
}
