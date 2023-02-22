using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEventArgs
{
    public class Car
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }

        private bool carIsDead;

        public delegate void CarEngineHandler(object sender, CarEventsArgs e);

        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;

        public Car() 
        { 
            MaxSpeed = 100; 
        }

        public Car(string name, int currentSpeed, int maxSpeed)
        {
            this.PetName = name;
            this.CurrentSpeed = currentSpeed;
            this.MaxSpeed = maxSpeed;
        }

        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                Exploded?.Invoke(this, new CarEventsArgs("Sorry, this car is dead..."));
            }
            else
            {
                CurrentSpeed += delta;

                if (10 == MaxSpeed - CurrentSpeed)
                {
                    AboutToBlow(this, new CarEventsArgs("Careful buddy! Gonna blow!"));
                }

                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }

        }
    }
}
