using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Recursion *****");
            Console.WriteLine("\nUsing a for loop:");
            Display(20);

            Console.WriteLine("\nUsing Recursion:");
            Print(20);

            Console.WriteLine("\n\nUse Recursion to print a right-triangle of size N");
            PrintTriangle(7);

            Console.WriteLine("\n\nPress <Enter> to exit. . .");
            Console.Read();
        }
        // method that displays a series of values from some value n to 1
        static void Display(int n)
        {
            for (int i = n; i >= 1; i--)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
        // method that displays a series of values from some value n to 1 using recursion
        static void Print(int n)
        {
            // every Recursion must have a Base Condition
            if (n < 1) // base condition
            {
                return; // action (return always exits out of a method)
            }
            // call this method again to print the next value
            Print(n - 1);
            Console.Write($"{n} ");
        }
        // create a helper method() display/print n stars in a single line
        static void PrintSingleLineWithNstars(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
        // use a recursive method() to display/print a triangle filled with stars
        // ex:
        //  ***
        //  **
        //  *
        static void PrintTriangle(int rows)
        {
            // write base case to define when to end recursion
            if (rows < 1)
            {
                return;
            }
            //  // apply the process to perform
            //  PrintSingleLineWithNstars(rows);
            // do a recursive call
            PrintTriangle(rows - 1);
            // apply the process to perform
            PrintSingleLineWithNstars(rows); // now this action happens during the RETURN portion
        }
    }
}
