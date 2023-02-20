namespace CarEvents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Events *****\n");

            Car c1 = new Car("SlugBug", 100, 10);

            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;
            c1.Exploded += CarExploded;

            Console.WriteLine("***** Speeding up *****");

            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            c1.Exploded -= CarExploded;

            Console.WriteLine("\n***** Speeding up *****");

            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
        }

        public static void CarAboutToBlow(string msg)
        {
            Console.WriteLine(msg);
        }
        public static void CarIsAlmostDoomed(string msg)
        {
            Console.WriteLine($"=> Critical Message from Car: {msg}");
        }
        public static void CarExploded(string msg)
        {
            Console.WriteLine(msg);
        }


        public class Car
        {
            public int CurrentSpeed { get; set; }
            public int MaxSpeed { get; set; }   
            public string PetName { get; set; }

            private bool carIsDead;

            public delegate void CarEngineHandler(string msgForCaller);
            public event CarEngineHandler Exploded;
            public event CarEngineHandler AboutToBlow;

            public Car() { MaxSpeed = 100; }

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
                    Exploded?.Invoke("Sorry, this car is dead...");
                }
                else
                {
                    CurrentSpeed += delta;
                        
                    if (10 == MaxSpeed - CurrentSpeed)
                    {
                        AboutToBlow?.Invoke("Careful buddy! Gonna blow!");
                    }

                    if (CurrentSpeed >= MaxSpeed)
                        carIsDead = true;
                    else
                        Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
                }

            }
        }
    }
}