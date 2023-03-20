namespace SimpleGC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** GC Basics *****");

            MakeACar();

            Console.WriteLine($"Enstimated byte on heap : {GC.GetTotalMemory(false)}");
            Console.WriteLine($"This OS has {GC.MaxGeneration + 1} object generations.\n");

            Car refToMyCar = new Car("Zippy", 100);
            Console.WriteLine(refToMyCar.ToString());
            Console.WriteLine();

            Console.WriteLine($"Generation of  refToMyCar is {GC.GetGeneration(refToMyCar)}");

            object[] tonsOfObjects = new object[50000];
            for (int i = 0; i < 50000; i++)
                tonsOfObjects[i] = new object();

            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            Console.WriteLine($"Generation of refToMyCar is: {GC.GetGeneration(refToMyCar)}");

            if (tonsOfObjects[9000] != null)
            {
                Console.WriteLine($"Generation of tonsOfObjects[9000] is: {GC.GetGeneration(tonsOfObjects[9000])}");
            }
            else
                Console.WriteLine("tonsOfObject[9000] is no longer alive");

            Console.WriteLine("\nGen 0 has been swept {0} times",
                GC.CollectionCount(0));

            Console.WriteLine("Gen 1 has been swept {0} times",
                GC.CollectionCount(1));

            Console.WriteLine("Gen 2 has been swept {0} times",
                GC.CollectionCount(2));

        }

        static void MakeACar()
        {
            Car myCar = new Car();
            myCar = null;
        }
    }
}