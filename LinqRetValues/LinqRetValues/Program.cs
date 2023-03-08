﻿namespace LinqRetValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> subset = GetStringSubset();

            foreach (string item in subset)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            foreach (string item in GetStringSubsetAsArray())
            {
                Console.WriteLine(item);
            }
        }

        static IEnumerable<string> GetStringSubset()
        {
            string[] colors = {"Light Red", "Green",
                "Yellow", "Dark Red", "Red", "Purple" };

            var theRedColors = from c in colors
                               where c.Contains("Red")
                               select c;

            return theRedColors;
        }

        static IEnumerable<string> GetStringSubsetAsArray()
        {
            string[] colors = {"Light Red", "Green",
                "Yellow", "Dark Red", "Red", "Purple" };

            var theRedColors = from c in colors
                               where c.Contains("Red")
                               select c;

            return theRedColors.ToArray();
        }
    }
}