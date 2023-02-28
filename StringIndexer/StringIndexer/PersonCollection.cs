using System.Collections;

namespace SimpleIndexer
{
    class PersonCollection : IEnumerable
    {
        private Dictionary<string, Person> listPeople =
            new Dictionary<string, Person>();

        public Person this[string name]
        {
            get => (Person)listPeople[name];
            set => listPeople[name] = value;
        }

        public void ClearPeople()
        {
            listPeople.Clear();
        }

        public int Count => listPeople.Count;

        IEnumerator IEnumerable.GetEnumerator() => listPeople.GetEnumerator();
    }
} 
