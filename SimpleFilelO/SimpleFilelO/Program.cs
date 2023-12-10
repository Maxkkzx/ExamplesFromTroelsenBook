namespace SimpleFilelO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple I/O with the File Type *****");
            string[] myTasks =
            {
                "Fix bathroom sink", "Call Dave",
                "Call Mom and Dad", "Play Xbox One"
            };

            File.WriteAllLines(@"tasks.txt", myTasks);
            
            foreach (string task in File.ReadAllLines(@"tasks.txt"))
            {
                Console.WriteLine("TODO: {0}", task);
            }
            Console.ReadLine();
        } 
    }
}