using System.Collections;

namespace ListOverCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>()
            {
                new Car { PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW" },
                new Car { PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW" },
                new Car { PetName = "Mary", Color = "Black", Speed = 55, Make = "VM"},
                new Car { PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car { PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"},
            };

            GetFastCars(cars);
            GetFastBMWs(cars);
            LINQOverArrayList();
            OfTypeAsFilter();
        }

        static void GetFastCars(List<Car> cars)
        {
            var fastCars = from c in cars where c.Speed > 55 select c;

            foreach(var car  in fastCars)
            {
                Console.WriteLine($"{car.PetName} is going too fast!");
            }
            Console.WriteLine();
        }

        static void GetFastBMWs(List<Car> cars)
        {
            var fastCars =
                from c in cars where c.Speed > 90 && c.Make == "BMW" select c;
            
            foreach(var car in fastCars)
            {
                Console.WriteLine($"{car.PetName} is going too fast!!");
            }
            Console.WriteLine();
        }

        static void LINQOverArrayList()
        {
            Console.WriteLine("***** LINQ over ArrayList *****");

            ArrayList cars = new ArrayList()
            {
                new Car { PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW" },
                new Car { PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW" },
                new Car { PetName = "Mary", Color = "Black", Speed = 55, Make = "VM"},
                new Car { PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car { PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"},
            };

            var myCarsEnum = cars.OfType<Car>();

            var fastCars = from c in myCarsEnum where c.Speed > 55 select c;

            foreach(Car car in fastCars)
            {
                Console.WriteLine($"{car.PetName} is going too fast!!!");
            }
            Console.WriteLine();
        }

        static void OfTypeAsFilter()
        {
            ArrayList myStuff = new ArrayList();

            myStuff.AddRange(new object[] { 10, 400, 8, false, new Car(), "string data" });
            var myInts = myStuff.OfType<int>();

            foreach(int i in myInts)
            {
                Console.WriteLine($"Int values: {i}");
            }
        }
    }
}