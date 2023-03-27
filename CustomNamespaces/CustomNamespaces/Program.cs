using MyShapes;
using The3DHexagon = Chapter14.My3DShapes.Hexagon;
using bfHome = System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace CustomNamespaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hexagon h = new Hexagon();
            Circle c = new Circle();
            Square s = new Square();

            MyShapes.Hexagon hex = new MyShapes.Hexagon();
            MyShapes.Circle cir = new MyShapes.Circle();
            MyShapes.Square squ = new MyShapes.Square();

            Chapter14.My3DShapes.Square squa = new Chapter14.My3DShapes.Square();
            Chapter14.My3DShapes.Circle circ = new Chapter14.My3DShapes.Circle();
            Chapter14.My3DShapes.Hexagon hexa = new Chapter14.My3DShapes.Hexagon();

            The3DHexagon h2 = new The3DHexagon();

            bfHome.BinaryFormatter b = new bfHome.BinaryFormatter();

            BinaryFormatter b2 = new BinaryFormatter();
        }
    }
}