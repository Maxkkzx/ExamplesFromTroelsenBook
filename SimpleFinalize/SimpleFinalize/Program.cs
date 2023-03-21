namespace SimpleFinalize
{
    internal class Program
    {
        class MyResourceWrapper
        {
            ~MyResourceWrapper() => Console.Beep();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Finalizers *****\n");
            Console.WriteLine("Hit the return key to shut down this app");
            Console.WriteLine("and force the GC to invoke FinalizeO");
            Console.WriteLine("for finalizable objects created in this AppDomain.");
            Console.ReadLine();

            MyResourceWrapper resourceWrapper = new MyResourceWrapper();
        }
    }
}