using System.Reflection;
using System.Runtime.CompilerServices;

namespace DefaultAppDomainApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with the default AppDomain *****\n");
            DisplayDADStats();
            Console.WriteLine();    

            ListAllAssembliesInAppDomain();
            InitAD();
        }

        private static void DisplayDADStats()
        {
            AppDomain defaultAd = AppDomain.CurrentDomain;

            Console.WriteLine("Name of this domain: {0}", defaultAd.FriendlyName);

            Console.WriteLine("ID of domain in this process: {0}", defaultAd.Id);

            Console.WriteLine("Is this the default domain?: {0}", defaultAd.IsDefaultAppDomain());

            Console.WriteLine("Base directory of this domain: {0}", defaultAd.BaseDirectory); 
        }

        static void ListAllAssembliesInAppDomain()
        {
            AppDomain defaultAD = AppDomain.CurrentDomain;
            var loadedAssemblies = from a in defaultAD.GetAssemblies()
                                   orderby a.GetName().Name select a;

            Console.WriteLine("***** Here are the assemblies loaded in {0} *****\n", defaultAD.FriendlyName);

            foreach (var assembly in loadedAssemblies)
            {
                Console.WriteLine("-> Name: {0}", assembly.GetName().Name);
                Console.WriteLine("-> Version: {0}", assembly.GetName().Version);
            }
        }

        private static void InitAD()
        {
            AppDomain defaultAD = AppDomain.CurrentDomain;
            defaultAD.AssemblyLoad += (o, s) =>
            {
                Console.WriteLine("{0} has been loaded!", s.LoadedAssembly.GetName().Name);
            };
        }
    }
}