using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace HashFunctions
{
    class Program
    {
        static int add_counter = 0;
        static int collision_counter = 0;
        static void Main(string[] args)
        {
            // read-in names.txt file
            string[] names = File.ReadAllLines("names.txt");
            // define the hashtable
            // the table should be able to hold (in each location) both K and V
            // use dotNet DictionaryEntry struct which is defined to hold two properties (both of type object)
            int max_size = names.Length + 79; // names.Length * 2;
            DictionaryEntry[] table = new DictionaryEntry[max_size];    // 2x size for Load Factor
            List<string> list = new List<string>(max_size);
            // List<string> needs to be filled in order to set an item into an index
            for(int i = 0; i < list.Capacity; i++)
            {
                list.Add("");
            }
            Dictionary<int, string> dict = new Dictionary<int, string>(max_size);
            // apply oat_hash
            // sequence through all the names
            //Console.WriteLine("\nUsing the oat_hash function");
            //Console.WriteLine("\nKey\t\tHash Value\t\tIndex");
            foreach(string key in names)
            {
                // DONE: Check for collision and perform avoidance as necessary
                AddWithCollisionDetection(list, key);
                //Console.WriteLine($"{ key,-25}{hashvalue,-15}{index}");
            }

            // Display the dictionary created during hashvalue => index calculating loop
            Console.WriteLine();
            foreach (KeyValuePair<int, string> kvp in dict)
            {
                Console.WriteLine($"Key={kvp.Key}\tValue={kvp.Value}");
                // DONE: Try adding these entries to a list
                list.Add(kvp.Value);
            }
            Console.ReadLine();

            // Display List contents
            DisplayList(list);
            Console.ReadLine();

            // DONE: Try to SORT the list (to check for duplicates)
            list.Sort();
            Console.Write("\n==>> Sorted List Contents <<==");
            DisplayList(list);

            // stats
            Console.WriteLine($"\nAddCounter: {add_counter}\nCollisionCounter: {collision_counter}");


            Console.Write("\n\nPress <Enter> to Exit. . .");
            Console.ReadKey();
        }
        static void AddWithCollisionDetection(List<string> l, string data, int incrementor = 0)
        {   // d:existing dictionary; data:value to add; incrementor:k+n^2 calculator
            // compute hash value
            Console.WriteLine($"Attempting Add of data: {data}");
            uint hashvalue = oat_hash(data);
            // convert (or map) to an index
            int capacity = l.Capacity;
            int index = Map(hashvalue + (uint)(Math.Pow(2,incrementor)), capacity); // (int)(Math.Pow(2, incrementor));
            if (l[index] != string.Empty)
            {
                collision_counter += 1;
                incrementor += 1;
                Console.WriteLine($"=> Collision! Attempt number: {incrementor} <=");
                AddWithCollisionDetection(l, data, incrementor);
                return;
            }
            else
            {
                add_counter += 1;
                l[index] = data;
            }
        }
        static void DisplayList(List<string> l)
        {
            Console.WriteLine("==>> Display List Contents <<==");
            foreach (string str in l)
            {
                if (str.Length < 1)
                {
                    Console.WriteLine("<blank>");
                }
                else
                {
                    Console.WriteLine(str);
                }
            }
            Console.WriteLine("\n\n");
        }
        //method that maps a hashvalue to an index of a given array
        static int Map(uint hashvalue, int table_size)
        {
            //use the mod function
            int index = (int)(hashvalue % table_size);
            return index;
        }


        //Additive Hash
        //*************
        //Simplest algorithm to come up with a hash value is to add all the characters
        //Generally this kind of algorithm will have a bad distribution, that means
        //it is very probable that two different keys return same hash value
        //example:  "abc", "cab", "bac",...

        static uint Add_Hash(object key)
        {
            string strkey = key.ToString();

            uint hash = 0;

            foreach (char ch in strkey)
            {
                hash += (uint)ch;
            }

            return hash;
        }

        //=============================================================
        ///XOR Hash
        ///********
        ///Even though this algorithm is better that additive, it still not very good
        ///
        static uint xor_hash(object key, int len)
        {
            string strkey = key.ToString();
            uint hash = 0;

            foreach (char ch in strkey)
            {
                hash ^= (uint)ch;
            }

            return hash;
        }

        ///=================================================================
        ///Rotating Hash
        ///*************
        ///Similar to XOR Hash, but involves more mixing of bits, which give the 
        ///rotating hash a much better distribution.
        ///Much of the time, this algorithm is sufficient and considered the minimal
        ///acceptable algorithm
        ///
        static uint rot_hash(object key)
        {
            string strkey = key.ToString();
            uint hash = 0;

            foreach (char ch in strkey)
            {
                hash = (hash << 4) ^ (hash >> 28) ^ (uint)ch;
            }

            return hash;
        }

        ///==========================================================================
        ///Bernstein Hash
        ///**************
        ///Proven to be very good for small character keys.
        ///
        static uint djb_hash(object key)
        {

            uint hash = 0;

            foreach (char ch in key.ToString())
            {
                hash = 33 * hash + (uint)ch;

                //you can use the Modified Bernstein Hash, by changing the + to ^
                // hash = 33 + hash ^ (uint)ch;
                //typically results in a better distribution
            }

            return hash;
        }

        ///=========================================================================
        ///Shift-Add-XOR Hash
        ///Similar to rotating hash, but powerful and flexible hash
        static uint ShiftAddXOR_hash(string key, int len)
        {
            uint hash = 0;

            foreach (char ch in key.ToString())
            {
                hash ^= (hash << 5) + (hash >> 2) + (uint)ch;
            }

            return hash;
        }

        ///=========================================================================
        ///FNV Hash (Fowler Noll Vo creators)
        ///used in many applications with great results
        ///
        static uint fnv_hash(object key)
        {

            uint hash = 2166136261;

            foreach (char ch in key.ToString())
            {
                hash = (hash * 16777619) ^ (uint)ch;
            }

            return hash;
        }

        ///===========================================================================
        ///One=at-a-Time Hash   by Bob Jenkins (authority on hash functions for table look up
        ///******************
        ///good hash function that should one of the first to be tested
        ///it has seen effective use.
        ///
        static uint oat_hash(object key)
        {
            uint hash = 0;

            foreach (char ch in key.ToString())
            {
                hash += (uint)ch;
                hash += (hash << 10);
                hash ^= (hash >> 6);
            }

            hash += (hash << 3);
            hash ^= (hash >> 11);
            hash += (hash << 15);

            return hash;
        }
    }
}
