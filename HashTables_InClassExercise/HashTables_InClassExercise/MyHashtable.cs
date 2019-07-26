using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTables_InClassExercise
{
    public class MyHashtable
    {
        // uses "seperate chaining" collision resolution method
        LinkedList<DictionaryEntry>[] table;
        int count;
        // constructors
        public MyHashtable() : this(19)
        {
        }
        public MyHashtable(int capacity)
        {
            //get the next prime number (instead of just taking the users' entered number)
            for (int p = capacity; ; p++)
            {
                if (IsPrime(p))
                {
                    table = new LinkedList<DictionaryEntry>[p];
                    break;
                }
            }
            count = 0;
        }
        //properties
        public int Count { get { return this.count; } }
        //methods
        public void Add(object key, object value)
        {
            //get index from the key
            int bucket = Hash(key);

            if (table[bucket] == null)
            {
                //if entry at bucket is null, it means the LinkedList has not been created
                //this is the first time an attempt is made to save a value at the given bucket(index)
                //so create the LinkedList by passing it a DictionaryEntery
                table[bucket] = new LinkedList<DictionaryEntry>();
            }
            //now just add the new entry (key, value) to the linkedlist
            table[bucket].AddLast(new DictionaryEntry(key, value)); // create the DictionaryEntry in-line
            count++;

            //assuming a load factor of 0.5 or 50%
            if (count > table.Length / 2)
            {   // TODO's::::
                //double table size, look for the next prime number to be used as the new array size
                //create a temp array using a prime number for the size
                //sequence thru the table + inner loop to sequence thru each linkedList if
                //it exists. rehash every entry and insert into the temp array
            }
        }
        //get a value given its key
        public object Get(object key)
        {
            //get the index or bucket from hashing the key
            int bucket = Hash(key);
            if (table[bucket] == null) return null; //if this element was previously added, then a LinkedList 
                                                    //would have been created.

            //if there is a LinkedList at that index (slot) then sequence through the linkedlist
            //table[bucket] is a reference to the linkedlist, where bucket is an
            foreach (DictionaryEntry de in table[bucket])
            {
                if (de.Key.Equals(key))//assuming that the Equals method has been overriden in the class
                    return de.Value;   //from which the key is instantiated
            }
            return null; //if we get to this point then the LinkedList at this given bucket has been completely searched
                         //and such key has not been found
        }
        //remove a value by index
        public void Remove(object key)
        {
            //get the index, bucket or slot of the element we want to remove
            int bucket = Hash(key);

            //if the slot is empty then no such element exists in the hashtable. throw an exception
            if (table[bucket] == null) throw new InvalidOperationException("Could not find a value with the given key");

            //if the slot is not empty, then look for the element in the linkedlist (in that slot)
            foreach (DictionaryEntry de in table[bucket]) //sequence thru the linkedlist at index: bucket
            {
                if (de.Key.Equals(key))//search for an entry into the listlink with the given key
                {
                    //recall that table[bucket] is a reference to a linkedlist
                    //the Remove methd is a linkedlist method
                    table[bucket].Remove(de);//when found remove the entry
                    count--;
                    return;
                }
            }
            //if we get to this point, it means the key could not be found
            throw new InvalidOperationException("Could not find a value with the given key");
        }
        //return all the entries in this table
        public IEnumerator GetEnumerator()
        {
            foreach (LinkedList<DictionaryEntry> list in table)
            {
                if (list != null)
                {
                    foreach (DictionaryEntry de in list)
                    {
                        yield return de;
                    }
                }
            }
        }
        private int Hash(object key)
        {
            int hashvalue = Math.Abs(key.GetHashCode()); //assumption that you have overriden the GetHashcode method in
                                                         //the class
            return hashvalue % table.Length; //return the index where associated with this key
        }
        // Use folding on a string, summed 4 bytes at a time
        long sfold(String s, int M)
        {
            int intLength = s.Length / 4;
            long sum = 0;
            for (int j = 0; j < intLength; j++)
            {
                //char[] c = s.Substring(j * 4, (j * 4) + 4).ToCharArray();
                char[] c = s.Substring(j * 4, 4).ToCharArray();
                long mult = 1;
                for (int k = 0; k < c.Length; k++)
                {
                    sum += c[k] * mult;
                    mult *= 256;
                }
            }

            char[] c2 = s.Substring(intLength * 4).ToCharArray();
            long mult2 = 1;
            for (int k = 0; k < c2.Length; k++)
            {
                sum += c2[k] * mult2;
                mult2 *= 256;
            }

            return (Math.Abs(sum) % M);
        }
        private bool IsPrime(int m)
        {
            int n = m;
            if (n <= 1)
                return false;
            else if (n <= 3)
                return true;
            else if (n % 2 == 0 || n % 3 == 0)
                return false;
            int i = 5;
            while (i * i <= n)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
                i = i + 6;
            }
            return true;
        }
    }
}
