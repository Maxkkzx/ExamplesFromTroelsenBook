namespace CheckingToPalindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string inputString = Console.ReadLine().ToLower();

            goodWay(inputString);
        }

        static void goodWay(string inputString)
        {
            Console.WriteLine("Good way!");

            string supString = inputString;
            char[] charArray = supString.ToCharArray();

            Array.Reverse(charArray);

            supString = new string(charArray);

            if (supString == inputString)
            {
                Console.WriteLine("It's a palindrome");
            }
            else
            {
                Console.WriteLine("It's not a palindrome");
            }
        }
    }
}