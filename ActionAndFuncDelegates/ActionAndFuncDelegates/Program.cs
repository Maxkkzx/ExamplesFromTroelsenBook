namespace ActionAndFuncDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string, ConsoleColor, int> actionTarget = DisplayMessage;
            actionTarget("Action Message!", ConsoleColor.Yellow, 5);

            Func<int, int, int> funcTarget = Add;
            int result = funcTarget.Invoke(40, 40);
            Console.WriteLine($"40 + 40 = {result}");

            Func<int, int, string> funcTarget2 = SumToString;
            string sum = funcTarget2(90, 300);
            Console.WriteLine(sum);
        }

        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;

            for (int i = 0; i < printCount; i++)
                Console.WriteLine(msg);

            Console.ForegroundColor = previous;
        }

        static int Add(int x, int y)
        {
            return x + y;
        }

        static string SumToString(int x, int y)
        {
            return (x + y).ToString();
        }
    }
}