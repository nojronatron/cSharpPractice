using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTables_InClassExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With Hashtables *****");
            //MyHashtable t1 = new MyHashtable();
            //t1.Add(0, "John, 425-555-1212");
            //t1.Add(10, "Melissa, 206-555-1213");
            //t1.Add(15, "Kris, 509-555-1214");
            //t1.Add(19, "Sarah, 425-555-1215");
            //t1.Add(5, "Aaron, 206-555-1216");

            //DisplayHashtable(t1);
            //Console.Write("\nEnter a key to search for: ");
            //int key = int.Parse(Console.ReadLine());
            //Console.WriteLine($"Search result: {SearchHashtable(t1, key)}.");

            //Console.Write("\nEnter a key to search for: ");
            //key = int.Parse(Console.ReadLine());
            //Console.WriteLine($"Search result: {SearchHashtable(t1, key)}.");

            //Console.Write("\nEnter a key to remove: ");
            //key = int.Parse(Console.ReadLine());
            //RemoveItemFromHashtable(t1, key);

            //DisplayHashtable(t1);

            // ==========================
            // in dotnet, Dictionary is a generic and is "the new Hashtable"
            //      is: a Key-Value pair

            Book b1 = new Book(
                            "Computer Science Illuminated",
                            "Nell Dale",
                            "Jones & Bartlett",
                             "9781449672843",
                             50.89m);
            Book b2 = new Book(
                "Nine Algorithms That Changed the Future",
                "John MacCormick",
                 "Princeton University Press",
                 "9780691147147",
                8.99m);

            Book b3 = new Book(
                "Python Programming 2nd Edition",
                "John Zelle",
                "Franklin, Beedle & Associates Inc",
                "9781590282410",
                42.75m);

            Dictionary<string, Book> bookDict = new Dictionary<string, Book>(); // <Key, Value> as Types
            bookDict.Add(b1.ISBN, b1); // uses ISBN as the key and the entire b1 object as the value
                                       // alternatively, the key could be manually generated
            bookDict.Add(b2.ISBN, b2);
            bookDict.Add(b3.ISBN, b3);
            
            // apply a foreach to a dictionary
            foreach (KeyValuePair<string, Book> kvp in bookDict)
            {
                Book book = kvp.Value;
                Console.WriteLine(book);    // default action is the overridden ToString()
            }

            // ==========================

            Console.Write("Press <Enter> key to exit. . .");
            Console.ReadLine();
        }
        static void RemoveItemFromHashtable(MyHashtable t, int k)
        {
            try
            {
                t.Remove(k);
            }
            catch(InvalidOperationException ioe)
            {
                Console.WriteLine($"key: {k} not in hashtable!");
            }
        }
        static object SearchHashtable(MyHashtable t, int k)
        {
            // use the Get method and pass to it the key
            object value = t.Get(k);
            if (value == null)
            {
                return ("key not found");
            }
            return value;
        }
        static void DisplayHashtable(MyHashtable t)
        {
            Console.WriteLine("==>> Display Values in Hashtable <<==");
            foreach(DictionaryEntry de in t)
            {
                Console.WriteLine($"key: {de.Key,-10}Value: {de.Value}");
            }
            Console.WriteLine();
        }
    }
}
