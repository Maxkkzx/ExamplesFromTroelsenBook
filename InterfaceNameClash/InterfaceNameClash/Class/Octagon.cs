using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceNameClash.Interface;

namespace InterfaceNameClash.Class
{
    class Octagon : IDrawToForm, IDrawToPrinter, IDrawToMemory
    {
        void IDrawToForm.Draw()
        {
            Console.WriteLine("Drawing to form...");
        }
        void IDrawToMemory.Draw()
        {
            Console.WriteLine("Drawing to memory...");
        }
        void IDrawToPrinter.Draw()
        {
            Console.WriteLine("Drawing to printer");
        }
    }
}
