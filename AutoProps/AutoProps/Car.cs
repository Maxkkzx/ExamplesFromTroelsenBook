using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    internal class Car
    {
        public string PetName { get; set; }
        public int Speed { get; set; }
        public string Color { get; set; }

        public void DisplayStats()
        {
            Console.WriteLine($"Car Name: {PetName}");
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"Color: {Color}");
        }
    }
}
