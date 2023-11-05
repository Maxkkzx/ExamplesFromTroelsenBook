namespace MultiThreadPrinting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Synchronizing Threads *****\n");

            Printer p = new Printer();

            Thread[] threads = new Thread[10];

            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(new ThreadStart(p.PrintNumbers))
                {
                    Name = $"Worker thread #{i}"
                };
            }

            foreach (Thread t in threads)
            {
                t.Start();
            }
            Console.ReadLine();
        }

        public class Printer
        {
            private object threadLock = new object();
            public void PrintNumbers()
            {
                lock (threadLock)
                {

                    Console.WriteLine("-> {0} is executing PrintNumbers ()",
                        Thread.CurrentThread.Name);
                    Console.Write("Your numbers: ");

                    for (int i = 0; i < 10; i++)
                    {
                        Random r = new Random();
                        Thread.Sleep(100 * r.Next(5));
                        Console.Write($"{i}, ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}