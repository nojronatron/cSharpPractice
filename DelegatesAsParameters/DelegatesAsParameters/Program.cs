using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAsParameters
{
    //  delegate type that takes an int and returns a bool
    public delegate bool MyPredicate(int x);
    public delegate bool MyPredicate2(int x, int y);

    class Program
    {
        static int[] array = new int[50];
        static void Main(string[] args)
        {
            PreloadArray();
            Display(array);

            //  find the first value that is positive
            MyPredicate predicate = IsPositive;
            int firstPosX = Find(predicate);    //  compiler creates a delegate to be passed to the Find() method
            Console.WriteLine($"\n\nFirst positive value: { firstPosX }.");

            //  find the first value that is negative
            predicate = IsNegative;
            int firstNegX = Find(predicate);
            Console.WriteLine($"\n\nFirst negative value: { firstNegX }.");

            //  find the first value that is negative and odd
            predicate = IsNegativeOdd;
            int firstNegOddX = Find(predicate);
            Console.WriteLine($"\n\nFirst negative odd value: { firstNegOddX }.");

            //  find the first value that is positive and even
            predicate = IsPositiveEven;
            int firstPosEvenX = Find(predicate);
            Console.WriteLine($"\n\nFirst positive even value: { firstPosEvenX }.");

            //  another way to do this: pass a delegate referencing a lambda expression
            MyPredicate predicate2 = x => (x) > 0 && x % 2 != 0;  //  boolean expression for 'positive' 'odd'
            int firstPositiveOdd = Find(predicate2);
            Console.WriteLine($"\n\nFirst positive odd value (Lambda-style): { firstPositiveOdd }.");

            //  Create an example using a Delegate that takes two int parameters and returns bool
            //  then wire-up the Delegate to a method that collects all matching instances of x
            //  return the count of matches
            MyPredicate2 mp2 = AreEqual;
            List<int> matches = MyFindAll(mp2);
            Console.WriteLine($"\n\nNumber of matching items found: { matches.Count }.");


            Console.WriteLine("\n\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
        static List<int> MyFindAll(MyPredicate2 mp2)
        {
            int numToFind = 20;
            List<int> list = new List<int>();
            foreach (int x in array)
            {
                if(mp2(numToFind, x))
                {
                    list.Add(x);
                }
            }
            return list;
        }
        static bool AreEqual(int x, int y)
        {
            return x == y;
        }

        //  utility method to preload the array
        static void PreloadArray()
        {
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-99, 100);
            }
        }
        static void Display(int[] arr)
        {
            int counter = 1;
            foreach (int x in arr)
            {
                if (counter % 16 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write($" { x }");
                counter++;
            }
            Console.WriteLine(".\n");
        }
        ////  method to find the first negative odd value and return that value
        //static int FindFirstNegativeOdd()
        //{
        //    foreach (int x in array)
        //    {
        //        if(IsNegativeOdd(x))
        //        {
        //            return x;
        //        }
        //    }
        //    return 0;
        //}
        ////  define a method with same signature as the predicate that returns true if x is negative and odd
        static bool IsNegativeOdd(int x)
        {
            return (x < 0 && x % 2 != 0);
        }
        ////  define a method to find the first positive value
        //static int FindFirstPositiveNumber()
        //{
        //    foreach (int x in array)
        //    {
        //        if (IsPositive(x))
        //        {
        //            return x;
        //        }
        //    }
        //    return 0;
        //}
        static bool IsPositive(int x)
        {
            return (x > 0);
        }

        //  rather than re-writing the same code (almost), pass-in a "condition method"
        //  since we cannot pass a method to a method directly, we do that using
        //  a delegate object. we can pass a delegate object to a method, as a
        //  parameter using the type of condition method we want should have the signature
        //  of MyPredicate
        static int Find(MyPredicate predicate)  //  need to associate 'predicate' with a method in order to invoke that method
        {
            foreach(int x in array)
            {
                if (predicate(x))
                {
                    return x;
                }
            }
            return 0;
        }
        static bool IsNegative(int x)
        {
            return x < 0;
        }
        static bool IsOdd(int x)
        {
            return x % 2 != 0;
        }
        static bool IsEven(int x)
        {
            return x % 2 == 0;
        }
        static bool IsPositiveEven(int x)
        {
            //return x > 0 && x % 2 == 0;
            return IsPositive(x) && IsEven(x);
        }
    }
}
