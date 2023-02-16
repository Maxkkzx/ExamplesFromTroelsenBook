namespace GenericDelegate
{
    internal class Program
    {
        public delegate void MyGenericDelegate<T>(T arg);

        static void Main(string[] args)
        {
            MyGenericDelegate<string> strTarget =
                new MyGenericDelegate<string>(StringTarget);

            strTarget("Some string data");

            MyGenericDelegate<int> intTarget =
                new MyGenericDelegate<int>(IntTarget);
            intTarget(9);

            static void StringTarget(string arg)
            {
                Console.WriteLine("arg in uppercase is :{0}", arg.ToUpper());
            }

            static void IntTarget(int arg)
            {
                Console.WriteLine("++arg is: {0}", ++arg);
            }
        }
    }
} 
    

