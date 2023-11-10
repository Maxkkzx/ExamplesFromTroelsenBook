namespace ThreadPoolApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With the CLR Thread Pool *****");
            Console.WriteLine($"Main thread started. ThreadID = {Thread.CurrentThread.ManagedThreadId}");

            Printer p = new Printer();
            WaitCallback workItem = new WaitCallback(PrintNumbers);

            for (int i = 0;i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(workItem, p);
            }
            Console.WriteLine("All tasks queued");
            Console.ReadLine();
        }

        static void PrintNumbers(object state)
        {
            Printer task = (Printer)state;
            task.PrintNumbers();
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