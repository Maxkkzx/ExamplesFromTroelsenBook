BinaryOp b = new BinaryOp(SimpleMath.Add);
DisplayDelegateInfo(b);
Console.WriteLine("10 + 10 is {0}", b(10, 10));
static void DisplayDelegateInfo(Delegate delObj)
{
    foreach (Delegate d in delObj.GetInvocationList())
    {
        Console.WriteLine("Method Name: {0}", d.Method);
        Console.WriteLine("Type Name: {0}", d.Target);
    }
}

public delegate int BinaryOp(int x, int y);

public class SimpleMath
{
    public static int Add(int x, int y) => x + y;
    public static int Substract(int x, int y) => x - y;
}