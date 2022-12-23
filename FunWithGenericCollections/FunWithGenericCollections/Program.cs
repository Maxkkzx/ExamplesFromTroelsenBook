using FunWithGenericCollections;

static void UseGenericList()
{
    List<Person> people = new List<Person>()
    {
        new Person{FirstName = "Homer", LastName = "Simpson", Age = 47},
        new Person{FirstName = "Marge", LastName = "Simpson", Age= 45},
        new Person{FirstName = "Lisa", LastName = "Simpson", Age = 9},
        new Person{FirstName = "Bart", LastName = "Simpson", Age = 8}
    };

    Console.WriteLine($"Items in list: {people.Count}");

    foreach (Person p in people)
        Console.WriteLine(p);

    Console.WriteLine("\n ->Inserting new person.");

    people.Insert(2,
        new Person { FirstName = "Maggie", LastName = "Simpson", Age = 2 });
    Console.WriteLine($"Items in list: {people.Count}");

    Person[] arrrayOfPeople = people.ToArray();
    foreach (Person p in arrrayOfPeople)
        Console.WriteLine("First Names: {0}", p.FirstName);
}
UseGenericList();