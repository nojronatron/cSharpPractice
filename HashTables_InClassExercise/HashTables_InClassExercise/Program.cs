using System;
using System.Collections;

namespace HashTables_InClassExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With Hashtables *****");
            MyHashtable t1 = new MyHashtable();
            t1.Add(0, "John, 425-555-1212");
            t1.Add(10, "Melissa, 206-555-1213");
            t1.Add(15, "Kris, 509-555-1214");
            t1.Add(19, "Sarah, 425-555-1215");
            t1.Add(5, "Aaron, 206-555-1216");

            DisplayHashtable(t1);
            Console.Write("\nEnter a key to search for: ");
            int key = int.Parse(Console.ReadLine());
            Console.WriteLine($"Search result: {SearchHashtable(t1, key)}.");

            Console.Write("\nEnter a key to search for: ");
            key = int.Parse(Console.ReadLine());
            Console.WriteLine($"Search result: {SearchHashtable(t1, key)}.");

            Console.Write("\nEnter a key to remove: ");
            key = int.Parse(Console.ReadLine());
            RemoveItemFromHashtable(t1, key);

            DisplayHashtable(t1);

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
