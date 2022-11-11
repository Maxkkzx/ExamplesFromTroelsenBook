
public interface IDrawable
{
    void Draw();
}

public interface IAdvancedDraw : IDrawable
{
    void DrawInBoundingBox(int top, int left, int bottom, int right);
    void DrawUpsideDown();
}

public class BitMapImage : IAdvancedDraw
{
    public void Draw()
    {
        Console.WriteLine("Drawing...");
    }

    public void DrawInBoundingBox(int top, int left, int bottom, int right)
    {
        Console.WriteLine("Drawing in a box...");
    }

    public void DrawUpsideDown()
    {
        Console.WriteLine("Drawing upside down!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        BitMapImage myBitmap = new BitMapImage();

        myBitmap.Draw();
        myBitmap.DrawInBoundingBox(10, 10, 100, 150);
        myBitmap.DrawUpsideDown();

        IAdvancedDraw iAdvDraw = myBitmap as IAdvancedDraw;
        if (iAdvDraw != null)
            iAdvDraw.DrawUpsideDown();
    }
}
