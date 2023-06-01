using AttributedCarLibrary;

namespace VehicleDescriptionAttributeReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Value of VehicleDescriptionAttribute *****\n");
            ReflectOnAttnbutesUsingEarlyBinding();
            Console.ReadLine();
        }

        private static void ReflectOnAttnbutesUsingEarlyBinding()
        {
            Type t = typeof(Winnebago);

            object[] customAtts = t.GetCustomAttributes(false);

            foreach (Types v in customAtts)
                Console.WriteLine("-> \n", v.Description);
        }
    }
}