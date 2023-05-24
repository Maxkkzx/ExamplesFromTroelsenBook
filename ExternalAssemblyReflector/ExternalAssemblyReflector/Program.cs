using System.Reflection;

namespace ExternalAssemblyReflector
{
    internal class Program
    {
        static void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("\n***** Type In Assembly *****");
            Console.WriteLine("->{0}", asm.FullName);
            Type[] types = asm.GetTypes();
            foreach (Type t in types)
                Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** External Assembly Viewer *****");
            string asmName = "";
            Assembly asm = null;
            do
            {
                Console.WriteLine("\n Enter an assembly to evaluate");
                Console.Write("or enter Q to quit: ");
                asmName = Console.ReadLine();

                if (asmName.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                try
                {
                    asm = Assembly.LoadFrom(asmName);
                    DisplayTypesInAsm(asm);
                }
                catch
                {
                    Console.WriteLine("Sorry, can't find assembly.");
                }
            } while (true);
        }
    }
}