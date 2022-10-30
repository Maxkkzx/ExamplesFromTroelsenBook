using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    internal class Garage
    {
        public int NumberOfCars { get; set; } = 1;
        public Car MyAuto { get; set; } = new Car();

        public Garage() { }
        public Garage(Car car, int number)
        {
            MyAuto = car;
            NumberOfCars = number;
        }   
    }
}
