using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateDelegateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Predicate Delegate *****");
            //  Predicate Delegate has ONLY ONE constructor (unlike Action<T> and Func<T>)
            //  Predicate is ONLY used for a method that returns a Boolean type and takes only one parameter

            //  Example: Create a Predicate delegate for a Lambda expression that returns true
            //      when the input parameter is positive and odd

            Predicate<int> predicate1 = x => x % 2 != 0 && x > 0;
            int randoNum = new Random().Next();
            Console.WriteLine($"predicate1 input: { randoNum }; predicate1 output: { predicate1(randoNum) }.");

            //  apply the find and findall method as defined in .net for the List collection
            int[] array = { 22, -5, -3, 8, 9, 33, 24, -32, 26, 21, -7, -15, 7, -44, 14 };
            List<int> list1 = new List<int>(array);

            //  public T Find (Predicate<T> match); 
            //  ^^^^^^ gets the 1stw element that satisfies the condition set by the predicate match
            //  1) find the first negative even value
            Predicate<int> match = x => x < 0 && x % 2 == 0;
            int result1 = list1.Find(match);
            Console.WriteLine($"Matched 1st negative-odd in 'array': { result1 }.");

            //  2) find ALL values that are negative and even
            List<int> result2 = list1.FindAll(match);
            Console.Write($"Matched the following negative-odd entries in 'array':");
            foreach(int i in result2)
            {
                Console.Write($" { i }");
            }
            Console.WriteLine(".");

            //  3) Exercise FindAll() the values that are odd and between -11 and 23
            List<int> result3 = list1.FindAll(x => x > -11 && x < 23);
            Console.Write($"Matched the following entries that are between -11 and 23 in 'array':");
            foreach(int j in result3)
            {
                Console.Write($" { j }");
            }
            Console.WriteLine(".");


            Console.Write("\n\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
    }
}
