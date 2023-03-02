namespace CustomConversions
{
    public struct Square
    {
        public int Length { get; set; }
        public Square(int i) : this()
        {
            Length = i;
        }

        public void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public override string ToString() => $"[Length = {Length}, Length]";

        public static explicit operator Square(Rectangle r)
        {
            Square s = new Square { Length = r.Height };
            return s;
        }

        public static implicit operator Square(int sideLength)   
        {
            Square newSq = new Square { Length = sideLength };
            return newSq;
        }

        public static explicit operator int(Square square) => square.Length;
    }
}
