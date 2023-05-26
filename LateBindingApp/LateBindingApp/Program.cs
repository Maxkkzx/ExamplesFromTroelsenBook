using System.Reflection;
using System.IO;

namespace LateBindingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Late Binding *****");
            Assembly a = null;

            try
            {
                a = Assembly.Load("CarLibrary");
            }

            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            if (a != null)
                CreateUsingLateBinding(a);

            Console.ReadLine();
        }

        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                Type miniVan = asm.GetType("CarLibrary.Minivan");

                object obj = Activator.CreateInstance(miniVan);
                Console.WriteLine("Created a {0} using late binding", obj);

                MethodInfo mi = miniVan.GetMethod("TurboBoost");
                mi.Invoke(obj, null);
            }
            
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void InvokeMethodWithArgsUsingLateBinding(Assembly asm)
        {
            try
            {
                Type sport = asm.GetType("CarLibrary.SportCar");

                object obj = Activator.CreateInstance(sport);

                MethodInfo mi = sport.GetMethod("TurnOnRadio");
                mi.Invoke(obj, new object[] {true, 2 });
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}