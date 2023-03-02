namespace CustomConversions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle(15, 4);
            Console.WriteLine(r);
            r.Draw();
            Console.WriteLine();

            Square s = (Square)r;
            Console.WriteLine(s);
            s.Draw();
            Console.WriteLine();

            Rectangle rect = new Rectangle(10, 5);
            DrawSquare((Square)rect);

            Square sq2 = (Square)90;
            Console.WriteLine("sq2 = {0}", sq2);
            Console.WriteLine();

            int side = (int)sq2;
            Console.WriteLine("Side length of sq2 = {0}", side);
            Console.WriteLine();

            Square s3 = new Square { Length = 83 };
            Rectangle rect2 = s3;

            Square s4 = new Square { Length = 7 };
            Rectangle rect3 = s4;
            Console.WriteLine("rect3 = {0}", rect3);
            Console.WriteLine();

            Square s5 = new Square { Length = 3 };
            Rectangle rect4 = (Rectangle)s5;
            Console.WriteLine("rect4 = {0}", rect4);
            
        }

        static void DrawSquare (Square sq)
        {
            Console.WriteLine(sq);
            sq.Draw();
        }
    }
}