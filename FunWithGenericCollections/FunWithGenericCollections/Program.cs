using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithGenericCollections
{
    class Program
    {
        static void UseSortedSet()
        {
            // make some people with different ages
            SortedSet<Person> setOfPeople = new SortedSet<Person>(new SortPeopleByAge())
            {
                new Person { FirstName="Homer", LastName="Simpson", Age=47 },
                new Person {FirstName="Marge", LastName="Simpson", Age=45 },
                new Person {FirstName="Lisa", LastName="Simpson", Age=9 },
                new Person {FirstName="Bart", LastName="Simpson", Age=8 }
            };
        // note the items are sorted by age
        foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            // add a few new people with various ages
            setOfPeople.Add(new Person { FirstName = "Saku", LastName = "Jones", Age = 1 });
            setOfPeople.Add(new Person { FirstName = "Mikko", LastName = "Jones", Age = 32 });

            // check to see if still sorted by age
            foreach(Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();
        }
        static void UseGenericQueue()
        {
            // Make a Q with three people
            Queue<Person> peopleQ = new Queue<Person>();
            peopleQ.Enqueue(new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            peopleQ.Enqueue(new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            peopleQ.Enqueue(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

            // Peek at first person in Q
            Console.WriteLine("{0} is first in line!", peopleQ.Peek().FirstName);

            // Remove each person from Q
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());

            // Try to DQ when Q is empty
            try
            {
                GetCoffee(peopleQ.Dequeue());
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine("\nError! {0}", ioe.Message);
            }
        }
        static void GetCoffee(Person p)
        {
            Console.WriteLine("{0} got coffee!", p.FirstName);
        }
        static void UseGenericStack()
        {
            Stack<Person> stackOfPeople = new Stack<Person>();
            stackOfPeople.Push(new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            stackOfPeople.Push(new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            stackOfPeople.Push(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

            // look at the TOP item (last in), POP it, then look again
            Console.WriteLine("First person is: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
            Console.WriteLine("\nFirst person is now: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
            Console.WriteLine("\nFirst person item is now: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped off {0}", stackOfPeople.Pop());

            try
            {
                Console.WriteLine("\n\nFirst person is: {0}", stackOfPeople.Peek());
                Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine("\nError! {0}", ioe.Message);
            }
        }
        static void UseGenericList()
        {
            // make a list of Person objects, filled with collection/object init syntax
            List<Person> people = new List<Person>()
            {
                new Person {FirstName = "Homer", LastName = "Simpson", Age=47 },
                new Person {FirstName = "Marge", LastName = "Simpson", Age=45},
                new Person {FirstName = "Lisa", LastName = "Simplson", Age=9},
                new Person {FirstName = "Bart", LastName = "Simpson", Age=8}
            };
            // print out num items in List
            Console.WriteLine("Items in list: {0}", people.Count);
            // Enumerate over List
            foreach(Person p in people)
            {
                Console.WriteLine(p);
            }
            // insert a new person
            Console.WriteLine("\n=> Inserting new person.");
            people.Insert(2, new Person { FirstName = "Maggie", LastName = "Simpson", Age = 2 });
            Console.WriteLine("Items in list: {0}", people.Count);
            // copy data into a new array
            Person[] arrayOfPeople = people.ToArray();
            foreach(Person p in arrayOfPeople)
            {
                Console.WriteLine("First Names: {0}", p.FirstName);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("***** Use Generic List *****\n");
            UseGenericList();
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("***** Use Generic Stack *****\n");
            UseGenericStack();
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("***** Use Generic Queue *****\n");
            UseGenericQueue();
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("***** Use SortedSet *****\n");
            UseSortedSet();


            Console.Write("\n\nPress <Enter> to exit. . .");
            _ = Console.ReadLine();
        }
    }
}
