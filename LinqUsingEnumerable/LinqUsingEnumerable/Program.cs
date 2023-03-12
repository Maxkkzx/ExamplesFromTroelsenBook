namespace LinqUsingEnumerable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QueryStringWithOperators();
            QueryStringsWithEnumerableAndLambdas();
            QueryStringsWithAnonymousMethods();
            VeryComplexQueryExpression.QueryStringsWithRawDelegates();

        }

        static void QueryStringWithOperators()
        {
            Console.WriteLine("***** Using Query Operators *****");

            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            var subset = from game in currentVideoGames where game.Contains(" ") orderby game select game;

            foreach (string s in subset)
                Console.WriteLine($"Item: {s}");
            Console.WriteLine();
        }

        static void QueryStringsWithEnumerableAndLambdas()
        {
            Console.WriteLine("***** Using Enumerable / Lambda Expressions *****");

            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            var subset = currentVideoGames.Where(game => game.Contains(" ")).OrderBy(game => game).Select(game => game);

            foreach (var game in subset)
                Console.WriteLine($"Item: {game}");
            Console.WriteLine();
        }

        static void QueryStringsWithAnonymousMethods()
        {
            Console.WriteLine("***** Using Anonymous Methods *****");

            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            Func<string, bool> searchFilter =
                 delegate (string game) { return game.Contains(" "); };

            Func<string, string> itemToProccess =
                delegate (string s) { return s; };

            var subset = currentVideoGames.Where(searchFilter).OrderBy(itemToProccess).Select(itemToProccess);

            foreach (var game in subset)
                Console.WriteLine($"Item: {game}");
            Console.WriteLine();
        }
    }
}