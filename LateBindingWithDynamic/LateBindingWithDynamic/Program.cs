using System.Reflection;

namespace LateBindingWithDynamic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddWithReflection();
        }

        private static void AddWithReflection()
        {
            Assembly asm = Assembly.Load("MathLibrary");

            try
            {
                Type math = asm.GetType("MathLibrary.SimpleMath");

                dynamic obj = Activator.CreateInstance(math);

                Console.WriteLine("Result is: {0}", obj.Add(10,70));
            }

            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}