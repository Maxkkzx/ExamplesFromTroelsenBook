using GenericCarEventArgs;

namespace GenericCarEventArgs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Events *****\n");

            Car c1 = new Car("SlugBug", 100, 10);

            c1.AboutToBlow += CarExploded;

            c1.AboutToBlow += CarAboutToBlow;

            EventHandler<CarEventsArgs> d = new EventHandler<CarEventsArgs>(CarExploded);

            c1.Exploded += d;

            Console.WriteLine("***** Speeding up *****");

            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            c1.Exploded -= CarExploded;

            Console.WriteLine("\n***** Speeding up *****");

            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
        }

        public static void CarAboutToBlow(object sender, CarEventsArgs e)
        {
            if(sender is Car c)
            {
                Console.WriteLine($"Critical Message from {c.PetName}: {e.msg}");
            }
        }

        public static void CarExploded(object sender, CarEventsArgs e)
        {
            Console.WriteLine(e.msg);
        }
    }
}