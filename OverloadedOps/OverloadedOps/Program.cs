namespace OverloadedOps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point ptOne = new Point(100, 100);
            Point ptTwo = new Point(40, 40);

            Console.WriteLine($"ptOne = {ptOne}");
            Console.WriteLine($"ptTwo = {ptTwo}");

            Console.WriteLine($"ptOne + ptTwo: {ptOne + ptTwo}");
            Console.WriteLine($"ptOne - ptTwo: {ptOne - ptTwo}");
            Console.WriteLine();

            Point biggerPoint = ptOne + 10;

            Console.WriteLine($"ptOne + 10 = {biggerPoint}");
            Console.WriteLine($"10 + biggerPoint = {10 + biggerPoint}");
            Console.WriteLine();

            Point ptThree = new Point(90, 5);
            Console.WriteLine($"ptThree = {ptThree}");
            Console.WriteLine($"ptThree += ptTwo: {ptThree += ptTwo}");
            Console.WriteLine();

            Point ptFour = new Point(0, 500);
            Console.WriteLine($"ptFour = {ptFour}");
            Console.WriteLine($"ptFour -= ptThree: {ptFour - ptThree}");
            Console.WriteLine();

            Point ptFive = new Point(1, 1);
            Console.WriteLine($"++ptFive = {++ptFive}");
            Console.WriteLine($"--ptFive = {--ptFive}");
            Console.WriteLine();

            Point ptSix = new Point(20, 20);
            Console.WriteLine($"ptSix++ = {ptSix++}");
            Console.WriteLine($"ptSix-- = {ptSix--}");
            Console.WriteLine();

            Console.WriteLine($"ptOne == ptTwo : {ptOne == ptTwo}");
            Console.WriteLine($"ptOne != ptTwo : {ptOne != ptTwo}");
            Console.WriteLine();

            Console.WriteLine("ptOne < ptTwo : {0}", ptOne < ptTwo);
            Console.WriteLine("ptOne > ptTwo : {0}", ptOne > ptTwo);
            Console.WriteLine();
        }
    }
}