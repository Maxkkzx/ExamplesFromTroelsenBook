UseDictionary();

static void UseDictionary()
{
    Dictionary<string, Person> peopleA = new Dictionary<string, Person>();

    peopleA.Add("Homer", new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
    peopleA.Add("Marge", new Person { FirstName = "Marge", LastName = "Simpson", Age = 35 });
    peopleA.Add("Lisa", new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

    Person homer = peopleA["Homer"];
    Console.WriteLine(homer);

    Dictionary<string, Person> peopleB = new Dictionary<string, Person>()
    {
        { "Homer", new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 } },
        { "Marge", new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 } },
        { "Lisa", new Person { FirstName = "Lisa" , LastName = "Simpson", Age = 9 } }
    };

    Person lisa = peopleB["Lisa"];
    Console.WriteLine(lisa);

    Dictionary<string, Person> peopleC = new Dictionary<string, Person>()
    {
        ["Homer"] = new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 },
        ["Marge"] = new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 },
        ["Lisa"] = new Person { FirstName = "Marge", LastName = "Simpson", Age = 9 }
    };

    Person marge = peopleC["Marge"];
    Console.WriteLine(marge);
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public Person() { }
    public Person(string firstName, string lastName, int age)
    {
        Age = age;
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName}, Age: {Age}";
    }

}

