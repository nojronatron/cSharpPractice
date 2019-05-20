using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingValuesFromStringData
{
    class Program
    {
        static void Main(string[] args)
        {
            void ParseFromStrings()
            {
                // Use object parsing method to extract a value from a string

                Console.WriteLine("***** Data Type Parsing From Strings *****");
                bool b = bool.Parse("True");
                Console.WriteLine($"\nValue of b: {b}");
                double d = double.Parse("99.884");
                Console.WriteLine($"Value of d: {d}");
                int i = int.Parse("8");
                Console.WriteLine($"Value of i: {i}");
                char c = Char.Parse("w");
                Console.WriteLine($"Value of c: {c}");
                Console.WriteLine();
            }

            void ParseFromStringsWithTryParse()
            {
                // Use TryParse method
                // key takeaway is if a string CAN be converted to the requested datatype, the TryParse() method returns 'true' and assigns the parsed value
                //    to the variable passed into the method. If the value CANNOT be parsed, the variable is assigned its default value and the TryParse()
                //    method returns False

                Console.WriteLine("***** Data Type Parsing with TryParse *****");
                Console.WriteLine();
                if (bool.TryParse("True", out bool b))
                {
                    Console.WriteLine($"Value of b: {b}");
                }
                string value = "Hello";
                if (double.TryParse(value, out double d))
                {
                    Console.WriteLine($"Value of d: {d}");
                }
                else
                {
                    Console.WriteLine($"Failed to convert the input ({value}) to a double");
                }
            }

            ParseFromStrings();
            ParseFromStringsWithTryParse();

            Console.WriteLine();

            // Stop program execution before exit
            Console.ReadLine();
        }
    }
}
