namespace CustomConversions
{
    public struct Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle(int width, int height) : this()
        {
            Width = width;
            Height = height;
        }

        public void Draw()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            return $"[Width = {Width}; Height = {Height}]";
        }

        public static implicit operator Rectangle(Square s)
        {
            Rectangle r = new Rectangle
            {
                Height = s.Length,
                Width = s.Length * 2
            };
            return r;
        }
    }
}


