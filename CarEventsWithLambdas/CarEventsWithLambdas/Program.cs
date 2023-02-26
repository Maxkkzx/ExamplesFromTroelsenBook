using CarEventsWithLambdas;

namespace CarEventsWithLambdas
{
    internal class Program
    {   
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Events *****\n");

            Car c1 = new Car("SlugBug", 100, 10);

            c1.AboutToBlow += (sender, e) => { Console.WriteLine(e.msg); };
            c1.Exploded += (sender, e) => { Console.WriteLine(e.msg); };

            Console.WriteLine("***** Speeding up *****");

            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            Console.WriteLine("\n***** Speeding up *****");

            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
        }
    }
}