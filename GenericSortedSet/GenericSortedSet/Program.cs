UseSortedSet();

static void UseSortedSet()
{
    SortedSet<Person> setOfPeople =
        new SortedSet<Person>(new SortPeopleByAge())
        {
            new Person {FirstName = "Homer", LastName = "Simpson", Age =47},
            new Person {FirstName = "Marge", LastName = "Simpson", Age =45},
            new Person {FirstName = "Lisa", LastName = "Simpson", Age =9},
            new Person {FirstName = "Bart", LastName = "Simpson", Age =8}
        };
    

    foreach (Person p in setOfPeople)
    {
        Console.WriteLine(p);
    }
    Console.WriteLine();

    setOfPeople.Add(new Person { FirstName = "Saku", LastName = "Jones", Age = 1 });
    setOfPeople.Add(new Person { FirstName = "Mikko", LastName = "Jones", Age = 32 });

    foreach (Person p in setOfPeople)
    {
        Console.WriteLine(p);
    }
}

class SortPeopleByAge : IComparer<Person>
{
    public int Compare(Person firstPerson, Person secondPerson)
    {
        if(firstPerson?.Age > secondPerson?.Age)
        {
            return 1;
        }
        if (firstPerson?.Age < secondPerson?.Age)
        {
            return -1;
        }
        return 0;
    }
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public Person() { }
    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName; 
        LastName = lastName; 
        Age = age;
    }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName}, Age: {Age}";
    }
}