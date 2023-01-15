using System.Collections.ObjectModel;




class Program
{
    static void Main(string[] args)
    {
        ObservableCollection<Person> people = new ObservableCollection<Person>()
        {
            new Person { FirstName = "Peter", LastName = "Murphy", Age = 52 },
            new Person { FirstName = "Kevin", LastName = "Key", Age = 48 },
        };

        people.CollectionChanged += people_CollectionChanged;

        people.Add(new Person("Fred", "Smith", 32));

        people.RemoveAt(0);

    }

    static void people_CollectionChanged(object sender,
        System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        Console.WriteLine($"Action for this event: {e.Action}");

        if (e.Action ==
            System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
        {
            Console.WriteLine("Here are the OLD times:");
            foreach (Person p in e.OldItems)
            {
                Console.WriteLine(p.ToString());    
            }
        }

        if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
        {
            Console.WriteLine("Here are the New items:");
            foreach (Person p in e.NewItems)
            {
                Console.WriteLine(p.ToString());
            }
        }

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