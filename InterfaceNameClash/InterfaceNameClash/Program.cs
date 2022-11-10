using InterfaceNameClash.Interface;
using InterfaceNameClash.Class;

namespace InterfaceNameClash
{
    class Program
    {
        static void Main(string[] args)
        {
            Octagon oct = new Octagon();

            IDrawToForm itfForm = (IDrawToForm)oct;
            itfForm.Draw();

            ((IDrawToPrinter)oct).Draw();

            if (oct is IDrawToMemory dtm)
                dtm.Draw();
        }
    }
}