using SimpleIndexer;
using System.Security.Cryptography.X509Certificates;

namespace StringIndexer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonCollection myPeople = new PersonCollection();

            myPeople["Homer"] = new Person("Homer", "Simpson", 40);
            myPeople["Marge"] = new Person("Marge", "Simpson", 38);

            Person homer = myPeople["Homer"];

            Console.Write(homer);

        }
    }
}