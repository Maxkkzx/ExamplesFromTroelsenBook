namespace LinqOverArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with LINQ to Objects *****\n");
            QueryOverStrings();
            Console.WriteLine();

            QueryOverStringsWithExtensionMethods();
            Console.WriteLine();

            QueryOverInts();
            Console.WriteLine();

            Console.ReadLine();
        }

        static void QueryOverStrings()
        {
            string[] currentVideoGames =
            {
                "Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"
            };

            IEnumerable<string> subset = from g in currentVideoGames
                                         where g.Contains(" ")
                                         orderby g
                                         select g;

            ReflectOverQueryResults(subset);

            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
            ReflectOverQueryResults(subset);

        }

        static void QueryOverStringsWithExtensionMethods()
        {
            string[] currentVideoGames =
            {
                "Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"
            };

            IEnumerable<string> subset = currentVideoGames.Where(g => g.Contains(" ")).OrderBy(g => g).Select(g => g);
            ReflectOverQueryResults(subset, "Extension Methods");

            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }

        static void QueryOverStringsLongHand()
        {
            string[] currentVideoGames =
            {
                "Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"
            };

            string[] gamesWithSpaces = new string[5];

            for (int i = 0; i < currentVideoGames.Length; i++)
            {
                if (currentVideoGames[i].Contains(" "))
                    gamesWithSpaces[i] = currentVideoGames[i];
            }

            Array.Sort(gamesWithSpaces);

            foreach (string s in gamesWithSpaces)
            {
                if (s != null)
                    Console.WriteLine("Item: {0}", s);
            }
            Console.WriteLine();
        }

        static void QueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            var subset = from i in numbers where i < 10 select i;

            foreach (var i in subset)
                Console.WriteLine("{0} < 10", i);
            Console.WriteLine();

            numbers[0] = 4;

            foreach (var j in subset)
                Console.WriteLine("{0} < 10", j);

            Console.WriteLine();
            ReflectOverQueryResults(subset);
        }

        static void ImmediateExecution()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            int[] subsetAsIntArray = (from i in numbers where i < 10 select i).ToArray<int>();

            List<int> subsetAsListOfInts = (from i in numbers where i < 10 select i).ToList<int>();
        }

        static void ReflectOverQueryResults(object resultSet, string queryType = "Query Expressions")
        {
            Console.WriteLine($"***** Info about your query using {queryType} *****");
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
        }
    }
}