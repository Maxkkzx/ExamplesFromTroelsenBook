namespace SimpleDispose
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Dispose *****\n");

            using (MyResourceWrappe rw = new MyResourceWrappe(),
                rw2 = new MyResourceWrappe())
            {
                //
            }
        }
    }
}