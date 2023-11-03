namespace AddWithThreads
{
    internal class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("***** Adding with Thread object *****");
            Console.WriteLine($"ID of thread in Main(): {Thread.CurrentThread.ManagedThreadId}");

            AddParams ap = new AddParams(10, 10);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ap);

            waitHandle.WaitOne();
            Console.WriteLine("other thread is done!");

            Console.ReadLine();
        }

        static void Add(object data)
        {
            if(data is AddParams) 
            {
                Console.WriteLine($"ID of thread in Add(): {Thread.CurrentThread.ManagedThreadId}");

                AddParams ap = (AddParams)data;
                Console.WriteLine($"{ap.a} + {ap.b} = {ap.a + ap.b}");

                waitHandle.Set();
            }
        }

        class AddParams
        {
            public int a, b;    
            
            public AddParams(int numb1, int numb2)
            {
                a = numb1;
                b = numb2;  
            }
        }
    }
}