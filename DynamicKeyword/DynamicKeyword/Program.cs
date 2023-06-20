using System.Diagnostics;

namespace DynamicKeyword
{
    internal class Program
    {
        class Person
        {
            public string FirstName { get; set; } = "";

            public string LastName { get; set; } = "";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with the dynamic keyword *****");
            PrintThreeStrings();
            Console.WriteLine();

            ChangeDynamicDataType();
            Console.WriteLine();

            InvokeMembersOnDynamicData();
            Console.WriteLine();
        }

        static void ImplicitlyTypedVariable()
        {
            var a = new List<int> { 90 };

        }

        static void UseObjectVariable()
        {
            object o = new Person() { FirstName = "Mike", LastName = "Larson" };
            Console.WriteLine("Person's first name is {0}", ((Person)o).FirstName);
        }

        static void PrintThreeStrings()
        {
            var s1 = "Greetings";
            object s2 = "From";
            dynamic s3 = "Minneapolis";

            Console.WriteLine("s1 is of type: {0}", s1.GetType());
            Console.WriteLine("s2 is of type: {0}", s2.GetType());
            Console.WriteLine("s3 is of type: {0}", s3.GetType());

        }

        static void ChangeDynamicDataType()
        {
            dynamic t = "Hello!";
            Console.WriteLine("t is of type: {0}", t.GetType());

            t = false;
            Console.WriteLine("t is of type: {0}", t.GetType());

            t = new List<int>();
            Console.WriteLine("t is of type: {0}", t.GetType());
        }
        
        static void InvokeMembersOnDynamicData()
        {
            dynamic textData1 = "Hello"; 
            try
            {
                Console.WriteLine(textData1.ToUpper());
                Console.WriteLine(textData1.toupper());
                Console.WriteLine(textData1.Foo(10, "ee", DateTime.Now));
            }

            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        class VeryDynamicClass
        {
            private static dynamic myDinamicField;
            public dynamic DynamicProperty { get; set; }

            public dynamic DynamicMethod(dynamic dynamicParam)
            {
                dynamic dynamicLocalVar = "Local variable";
                int myInt = 10;
                if (dynamicParam is int)
                {
                    return dynamicLocalVar;
                }
                else
                {
                    return myInt;
                }
            }
        }
    }
}