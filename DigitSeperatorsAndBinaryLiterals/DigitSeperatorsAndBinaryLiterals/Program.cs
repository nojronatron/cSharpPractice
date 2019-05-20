using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitSeperatorsAndBinaryLiterals
{
    class Program
    {
        static void Main(string[] args)
        {
            // An underscore character can be used as a digit seperator for integer, long, decimal, or double data types
            // Note that this does NOT impact the output, and is meant for easier reading of the code

            void DigitSeperators()
            {
                Console.WriteLine("***** Use Digit Seperatrors *****");
                Console.Write("Integer:");
                Console.WriteLine(123_456);
                Console.Write("Long:");
                Console.WriteLine(123_456_789L);
            }

            void BinaryLiterals()
            {
                Console.WriteLine("***** Use Binary Literals *****");
                Console.WriteLine($"Sixteen: {0b0001_0000}");
                Console.WriteLine($"Thirty Two: {0b0010_0000}");
                Console.WriteLine($"Sixty Four: {0b0100_0000}");
            }

            Console.WriteLine();
            DigitSeperators();

            Console.WriteLine();
            BinaryLiterals();

            // Pause program execution before exit
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
