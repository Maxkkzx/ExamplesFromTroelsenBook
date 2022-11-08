using ProcessMultipleExceptions.Class;

namespace ProcessMultipleExceptions
{
    class Programm
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("Rusty", 90);

            try
            {
                myCar.Accelerate(-10);
            }
            catch(CarIsDeadException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.ErrorTimeStamp);
                Console.WriteLine(e.CauseOfError);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }  
    }
}