namespace ThreadStats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Primary Thread stats *****\n");

            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "ThrePrimaryThread";

            Console.WriteLine($"Name of current AppDomain: {Thread.GetDomain().FriendlyName}");
            Console.WriteLine($"Id of current AppDomain: {Thread.GetDomainID}");


            Console.WriteLine($"Thread Name: {primaryThread.Name}");
            Console.WriteLine($"Has thread started?: {primaryThread.IsAlive}");
            Console.WriteLine($"Priority Level: {primaryThread.Priority}");
            Console.WriteLine($"Thread State: {primaryThread.ThreadState}");

            Console.ReadLine();
        }
    }
}