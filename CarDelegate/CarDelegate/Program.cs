using System.Globalization;
using System.Security;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("***** Delegates as event enablers *****\n");

        Car cl = new Car("SlugBug", 100, 10);

        cl.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
        cl.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent2));

        Console.WriteLine("Speeding up");

        for (int i = 0; i < 6; i++)
            cl.Acellerate(20);

        static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("*********************************\n");
        }

        static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine($"=> {msg.ToUpper()}");
        }

    }
}

public class Car
{

    public int CurrentSpeed { get; set; }
    public int MaxSpeed { get; set; }
    public string PetName { get; set; }

    private bool CarIsDead;


    public Car() { }
    public Car(string name, int maxSp, int currSp)
    {
        CurrentSpeed = currSp;
        MaxSpeed = maxSp;
        PetName = name;
    }

    public delegate void CarEngineHandler(string msgForCaller);
    private CarEngineHandler listOfHandlers;

    public void RegisterWithCarEngine(CarEngineHandler methodToCall)
    {
        listOfHandlers += methodToCall;
    }

    public void Acellerate(int delta)
    {
        if (CarIsDead)
        {
            if (listOfHandlers != null)
                listOfHandlers("Sorry, this car is dead...");
        }
        else
        {
            CurrentSpeed += delta;
            if (10 == (MaxSpeed - CurrentSpeed) && listOfHandlers != null)
            {
                listOfHandlers("Careful buddy! Gonna blow!");
            }
            if (CurrentSpeed >= MaxSpeed)
                CarIsDead = true;
            else
                Console.WriteLine($"Current speed = {CurrentSpeed}");
        }
    }
}