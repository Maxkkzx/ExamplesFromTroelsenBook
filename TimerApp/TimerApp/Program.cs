namespace TimerApp
{
    internal class Program
    {

        static void PrintTime(object state)
        {
            Console.WriteLine($"Time is {DateTime.Now.ToLongTimeString()}, Param is: {state.ToString()}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** Working with Timer type *****\n");

            TimerCallback timeCB = new TimerCallback(PrintTime);

            var _ = new Timer(
                timeCB,
                "Use of autonomous discarding",
                0,
                1000);
            Console.WriteLine("Hit key to  terminate...");
            Console.ReadLine();
        }
    }
}