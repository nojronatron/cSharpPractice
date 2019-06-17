using System;
using System.Collections.ObjectModel;

namespace FunWithObservableCollections
{
    class Program
    {
        public enum NotifyCollectionChangedAction
        {
            Add=0,
            Remove=1,
            Replace=2,
            Move=3,
            Reset=4,
        }
        static void Main(string[] args)
        {
            // make a collection to observe and add a few Person objects
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                new Person{FirstName = "Peter", LastName = "Murphy", Age = 52 },
                new Person{FirstName = "Kevin", LastName = "Key", Age = 48 },
            };
            // wire up the CollectionChanged event
            people.CollectionChanged += people_CollectionChanged;

            // add an item
            people.Add(new Person { FirstName = "Andy", LastName = "Anderson", Age = 32 });

            // display list as it is now
            Console.WriteLine("\nHere is the list of people as it now stands:");
            foreach (Person p in people)
            {
                Console.WriteLine(p.ToString());
            }

            // remove an item: custom-developed by me
            Person rp = FindMatch(people);
            people.Remove(rp); // HERE the CollectionChanged event should fire for "Remove"

            // show what remains in the collection
            Console.WriteLine("\nRemaining people in collection:");
            foreach(Person p in people)
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine("\n\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
        private static Person FindMatch(ObservableCollection<Person> people)
        { // custom developed by me because I do not know what I am doing with Generics yet
            // seems like there should be a better way
            int index;
            foreach (Person p in people)
            {
                Console.WriteLine();
                index = people.IndexOf(p);
                Console.WriteLine($"Index: {index}; Person p: {p.ToString()}.");
                if (people[index].FirstName == "Kevin")
                {
                    return people[index];
                }
            }
            return null;
        }
        static void Display(Person p)
        {
            Console.WriteLine(p.ToString());
            //Console.WriteLine(p.GetType());
        }
        static void people_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //what was the action that caused the event?
            Console.WriteLine("\n=> Action for this event: {0}", e.Action);

            //something was removed
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("\n==>> Here are the OLD items:");
                foreach (Person p in e.OldItems)
                {
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine();
            }

            //something was added
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                //now show the NEW items that were inserted
                Console.WriteLine("\n==>>Here are the NEW items:");
                foreach(Person p in e.NewItems)
                {
                    Console.WriteLine(p.ToString());
                }
            }
        }
    }
}
