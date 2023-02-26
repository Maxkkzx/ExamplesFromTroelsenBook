namespace SimpleLambdaExpressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LabdaExpressionSyntax();
        }

        static void LabdaExpressionSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            List<int> evenNumbers = list.FindAll((i) =>
            {
                Console.WriteLine("value of is currently: {0}", i);
                bool isEven = ((i % 2) == 0);
                return isEven;
            });

            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write($"{evenNumber}\t");
            }
            Console.WriteLine();    
        }
    }
}