using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LinqUsingEnumerable
{
    internal class VeryComplexQueryExpression
    {
        public static void QueryStringsWithRawDelegates()
        {
            Console.WriteLine("***** Using Raw Delegates *****");

            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            Func<string, bool> searchFilter = new Func<string, bool>(Filter);
            Func<string, string> itemToProccess = new Func<string, string>(ProcessItem);

            var subset = currentVideoGames.Where(searchFilter).OrderBy(itemToProccess).Select(itemToProccess);

            foreach (var game in subset)
                Console.WriteLine($"Item: {game}");
            Console.WriteLine();
        }
            public static bool Filter(string game) { return game.Contains(" "); }
            public static string ProcessItem(string game) { return game; }
    }
}
