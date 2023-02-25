namespace AnonymousMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car("SlugBug", 100, 10);

            int aboutToBlowCounter = 0;

            c1.AboutToBlow += delegate
            {
                aboutToBlowCounter++;
                Console.WriteLine("Eek! Going too fast!");
            };

            c1.AboutToBlow += delegate (object sender, CarEventsArgs e)
            {
                aboutToBlowCounter++;
                Console.WriteLine("Message from Car: {0}", e.msg);
            };

            c1.Exploded += delegate (object sender, CarEventsArgs e)
            {
                Console.WriteLine("Fatal message from Car: {0}", e.msg);
            };


            for(int i = 0; i < 6 ; i++)
            {
                c1.Accelerate(20);
            }
            Console.WriteLine("AboutToBlow event was fired {0} times.", aboutToBlowCounter);
        }
    }
}