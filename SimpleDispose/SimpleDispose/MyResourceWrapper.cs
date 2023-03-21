using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDispose
{
    internal class MyResourceWrappe : IDisposable
    {
        public void Dispose() 
        {
            Console.WriteLine("***** In Dispose! *****");
        }  
    }
}
