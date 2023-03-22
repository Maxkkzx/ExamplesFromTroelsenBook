namespace FinalizableDisposableClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Dispose() / Destructor Combo Platter *****"); 

            MyResourceWrapper rw = new MyResourceWrapper();
            rw.Dispose();

            MyResourceWrapper rw2 = new MyResourceWrapper();

            Console.ReadLine();
        }
    }
}