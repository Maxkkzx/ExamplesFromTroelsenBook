namespace AutoProps
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car();
            c.PetName = "Dodge";
            c.Speed = 220;
            c.Color = "Black";

            c.DisplayStats();

            Garage g = new Garage();
            g.MyAuto = c;

            Console.WriteLine($"Number of Cars in garage: {g.NumberOfCars}");
            Console.WriteLine($"Your car is named: {g.MyAuto.PetName}");
        }
    }
}