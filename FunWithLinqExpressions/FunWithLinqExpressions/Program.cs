namespace FunWithLinqExpressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Query Expressions *****");

            ProductInfo[] itemsInStock = new[]
            {
                new ProductInfo { Name = "Mac's Coffee", Description = "Coffee with TEETH", NumberInStock = 24 },
                new ProductInfo { Name = "Milk Maid Milk", Description = "Milk cow's love", NumberInStock = 100},
                new ProductInfo { Name = "Pure Silk Tofu", Description = "Bland as Possible", NumberInStock = 120},
                new ProductInfo { Name = "Crunchy Pops", Description = "Cheezy, peppery goodness", NumberInStock = 2},
                new ProductInfo { Name = "RipOff Water", Description = "From the tap to your wallet", NumberInStock = 100},
                new ProductInfo { Name = "Classic Valpo Pizza", Description = "Everyone loves pizza!", NumberInStock = 73}
            };

            SelectEverything(itemsInStock);
            ListProductNames(itemsInStock);
            GetOverstock(itemsInStock);
            GetNameAndDescriptions(itemsInStock);

            Array objs = GetProjectedSubset(itemsInStock);
            foreach (object o in objs)
            {
                Console.WriteLine(o);
            }

            GetCountFromQuery();
            ReverseEveryThing(itemsInStock);
            AlphabetizeProductNames(itemsInStock);
            DisplayDiff();
            DisplayIntersection();
            DisplayUnion();
            DisplayConcat();
            DisplayConcatNoDups();
            AggregateOps();
        }


        static void SelectEverything(ProductInfo[] products)
        {
            Console.WriteLine("All product details:");

            var allProducts = from p in products select p;

            foreach (var prod in allProducts)
            {
                Console.WriteLine(prod.ToString());
            }

            Console.WriteLine();
        }

        static void ListProductNames(ProductInfo[] products)
        {
            Console.WriteLine("Only product names: ");

            var names = from p in products select p.Name;

            foreach (var n in names)
            {
                Console.WriteLine($"Name: {n}");
            }

            Console.WriteLine();
        }

        static void GetOverstock(ProductInfo[] products)
        {
            Console.WriteLine("The overstock items!");

            var overstock = from p in products where p.NumberInStock > 25 select p;

            foreach (ProductInfo c in overstock)
            {
                Console.WriteLine(c.ToString());
            }

            Console.WriteLine();
        }

        static void GetNameAndDescriptions(ProductInfo[] products)
        {
            Console.WriteLine("Names and Descriptions: ");

            var nameDesc = from p in products select new { p.Name, p.Description };

            foreach (var item in nameDesc)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();
        }

        static Array GetProjectedSubset(ProductInfo[] products)
        {
            var nameDesc = from p in products select new { p.Name, p.Description };

            return nameDesc.ToArray();
        }

        static void GetCountFromQuery()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            int numb = (from g in currentVideoGames where g.Length > 6 select g).Count();

            Console.WriteLine($"{numb} items honor the LINQ query.");

            Console.WriteLine();
        }

        static void ReverseEveryThing(ProductInfo[] products)
        {
            Console.WriteLine("Product in reverse:");

            var allProducts = from p in products select p;

            foreach (var prod in allProducts.Reverse())
            {
                Console.WriteLine(prod.ToString());
            }

            Console.WriteLine();
        }

        static void AlphabetizeProductNames(ProductInfo[] products)
        {
            var subset = from p in products orderby p.Name select p;

            Console.WriteLine("Orderby by Name:");
            foreach (var p in subset)
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine();
        }

        static void DisplayDiff()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            var carDiff = (from c in myCars select c).Except(from c2 in yourCars select c2);

            Console.WriteLine("Here is what  you don't  have, but I do:");

            foreach (string s in carDiff)
                Console.WriteLine(s);

            Console.WriteLine();
        }

        static void DisplayIntersection()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            var carIntersect = (from c in myCars select c).Intersect(from c2 in yourCars select c2);

            Console.WriteLine("Here is what we have in common:");
            foreach (string s in carIntersect)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();
        }

        static void DisplayUnion()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            var carUnion = (from c in myCars select c).Union(from c2 in yourCars select c2);

            Console.WriteLine("Here is everything:");
            foreach (string s in carUnion)
                Console.WriteLine(s);
        }

        static void DisplayConcat()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            var carConcat = (from c in myCars select c).Concat(from c2 in yourCars select c2);

            foreach (string s in carConcat)
                Console.WriteLine(s);

            Console.WriteLine();
        }

        static void DisplayConcatNoDups()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            var carConcat = (from c in myCars select c).Concat(from c2 in yourCars select c2);

            foreach (string s in carConcat.Distinct())
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();
        }

        static void AggregateOps()
        {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };

            Console.WriteLine($"Max temp: {(from t in winterTemps select t ).Max()}");
            Console.WriteLine($"Min temp: {(from t in winterTemps select t ).Min()}");
            Console.WriteLine($"Average temp: {(from t in winterTemps select t ).Average()}");
            Console.WriteLine($"Sum of all temps: {(from t in winterTemps select t ).Sum()}");

            Console.WriteLine();
        }
    }
}