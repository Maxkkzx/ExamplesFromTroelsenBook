namespace LamdaExpressionsMultipleParams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleMath m = new SimpleMath();
            m.SetMathHandler((msg, result) =>
            {
                Console.WriteLine($"Message: {msg}, Result: {result}");
            });

            m.Add(10, 10);

        }
    }
}