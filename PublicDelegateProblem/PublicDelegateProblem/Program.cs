namespace PublicDelegateProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Agh! No Encapsulation!*****\n");

            Car myCar = new Car();

            myCar.listOfHandlers = new Car.CarEngineHandler(CallWhenExploded);
            myCar.Accelerate(10);

            myCar.listOfHandlers = new Car.CarEngineHandler(CallHereToo);
            myCar.Accelerate(10);

            myCar.listOfHandlers.Invoke("hee, hee, hee...");
            Console.ReadLine();
        }
        static void CallWhenExploded(string msg)
        { 
            Console.WriteLine(msg); 
        }
        static void CallHereToo(string msg)
        { 
            Console.WriteLine(msg); 
        }
    }

    public class Car
    {
        public delegate void CarEngineHandler(string msgForCaller);

        public CarEngineHandler listOfHandlers;

        public void Accelerate(int delta)
        {
            if (listOfHandlers != null)
                listOfHandlers("Sorry, this car is dead...");
        }
    }
}


