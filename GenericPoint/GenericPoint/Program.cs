

Point<int> p = new Point<int>(10, 10);
Console.WriteLine("p.ToString() = {0}", p.ToString());
p.ResetPoint();
Console.WriteLine("p.ToString() = {0}", p.ToString());
Console.WriteLine();

Point<double> p2 = new Point<double>(5.4, 3.3);
Console.WriteLine("p2.ToString() = {0}", p2.ToString());
p2.ResetPoint();
Console.WriteLine("p2.ToString() = {0}", p2.ToString());


public struct Point<T>
{
    public T xPos;
    public T yPos;

    public Point(T xVal, T yVal)
    {
        this.xPos = xVal;
        this.yPos = yVal;
    }

    public T X
    {
        get { return xPos; }
        set { xPos = value; }
    }

    public T Y
    {
        get { return yPos; }
        set { yPos = value; }
    }

    public override string ToString() => $"[{xPos}, {yPos}]";

    public void ResetPoint()
    {
        xPos = default(T);
        yPos = default(T);
    }
}

