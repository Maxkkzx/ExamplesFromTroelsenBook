namespace AsyncDelegate
{
    public delegate int BinaryOp(int x, int y);
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Async Delegate Invocation *****");

            Console.WriteLine("Main() invoked on thread {0}",
                Thread.CurrentThread.ManagedThreadId);

            BinaryOp b = new BinaryOp(Add);

            IAsyncResult ar = b.BeginInvoke(10, 10, null, null);

            while (!ar.AsyncWaitHandle.WaitOne(1000, true))
            {
                Console.WriteLine("Doing more work in Main()!");
            }

            int answer = b.EndInvoke(ar);

            Console.WriteLine("10 + 10 is {0}.", answer);

            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            Console.WriteLine("Add() invoked on thread {0}",
                Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y;
        }
    }
}