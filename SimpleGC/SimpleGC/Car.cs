using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGC
{
    internal class Car
    {
        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }

        public Car() { }
        
        public Car(string petName, int currentSpeed)
        {
            CurrentSpeed = currentSpeed;
            PetName = petName;
        }

        public override string ToString() => $"{PetName} is going {CurrentSpeed} MPH";
    }
}
