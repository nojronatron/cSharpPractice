using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackArrayImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With Stacks *****");
            MyStack ms1 = new MyStack(4);
            ms1.Push("John");
            ms1.Push("Sandra");
            ms1.Push("Mike");
            ms1.Push("David");
            ms1.Push("Michelle");
            ms1.Push("Karen");

            // copy stack to an array
            // object[] dataArray = ms1.ToArray();
            // display the copied stack array
            // Display(dataArray);
            Display(ms1); // using IEnumerable's GetEnumerator is the correct way to implement this

            ms1.Push("Steve");
            Display(ms1);

            Console.WriteLine($"\nCurrent \"Top\" item: {ms1.Peek()}");
            Console.WriteLine($"\nPOPing the \"Top\" item: {ms1.Pop()}");

            Console.WriteLine($"\nAfter 1 Pop(), the new top item is: {ms1.Peek()}");
            ms1.Pop();
            ms1.Pop();
            Console.WriteLine($"\nAfter 2 more Pop()s, the new top item is: {ms1.Peek()}");
            ms1.Pop();
            ms1.Pop();
            ms1.Pop();
            // this last one will cause an Exception to be thrown because the Stack is empty
            // ms1.Pop();


            Console.Write("\n\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
        static void Display(MyStack stack)
        {
            Console.WriteLine("\nCurrent contents of MyStack");
            Console.WriteLine("===========================");
            foreach(object item in stack)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine("===========================\n");
        }
        // below is legacy code that does not take advantage of DotNet's IEnumerable interface
        // static void Display(object[] arr)
        //{
        //    Console.WriteLine("Contents of MyStack");
        //    Console.WriteLine("===================");
        //    foreach(object data in arr)
        //    {
        //        Console.WriteLine(data);
        //    }
        //}
    }
}
