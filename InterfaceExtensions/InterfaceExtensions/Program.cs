namespace InterfaceExtensions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] data = {"Wow", "this", "is", "sort", "of", "annoying",
            "but", "in", "a", "weird", "way", "fun!",};
            
            data.PrintDataAndBeep();
            Console.WriteLine();

            List<int> myInts = new List<int>() { 10, 15, 20 };
            myInts.PrintDataAndBeep();
        }
    }
}