using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExtensionMethods;

namespace ExtensionMethods
{
    static class Program
    {
        static void Main(string[] args)
        {
            int myInt = 12345678;
            myInt.DisplayDefiningAssembly();

            System.Data.DataSet d = new System.Data.DataSet();
            d.DisplayDefiningAssembly();

            Console.WriteLine("Value of myInt: {0}", myInt);
            Console.WriteLine("Reversed digits of myInt: {0}", myInt.ReverseDigits());
        }
    }
}