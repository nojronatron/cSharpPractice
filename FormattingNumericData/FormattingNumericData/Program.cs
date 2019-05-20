using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormattingNumericData
{
    class Program
    {
        static void Main(string[] args)
        {
            // example use of format tags
            Console.WriteLine($"The value 99999 in various formats:");

            Console.WriteLine("c format: {0:c}", 99999);
            Console.WriteLine("d9 format: {0:d9}", 99999);
            Console.WriteLine("f3 format: {0:f3}", 99999);
            Console.WriteLine("n format: {0:n}", 99999);

            // note: upper- or lowercasing for hex determines if letters are upper- or lowercased
            Console.WriteLine("E format: {0:E}", 99999);
            Console.WriteLine("e format: {0:e}", 99999);
            Console.WriteLine("X format: {0:X}", 99999);
            Console.WriteLine("x format: {0:x}", 99999);
            
            // C# 7.1 allows setting a default value to variables
            int myInt = default;
            Console.WriteLine($"Default value of myInt: {myInt}");

            // Syntactically well-formed C# that creates variables with default-valuees
            bool b = new bool();
            Console.WriteLine($"Default bool value, following syntactically correct (and cumbersome) code: {b}");

            // halt program execution before exit
            Console.ReadLine();
        }
    }
}
