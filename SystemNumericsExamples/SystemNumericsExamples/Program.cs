using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SystemNumericsExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            // System.Numerics dll reference allows using statement (select the checkbox when adding a Reference!)
            Console.WriteLine("***** Use BigInteger *****");
            // BigInteger Data Type is immutable - once assigned it cannot be changed
            BigInteger biggy = BigInteger.Parse("999999999999999999999999999999999999999999999");
            Console.WriteLine($"Value of biggy is {biggy}");
            Console.WriteLine($"Is biggy an even value?: {biggy.IsEven}");
            Console.WriteLine($"Is biggy a power of two?: {biggy.IsPowerOfTwo}");
            BigInteger reallyBig = BigInteger.Multiply(biggy, BigInteger.Parse("88888888888888888888888888888888888888888888888888"));
            Console.WriteLine($"Value of reallyBig is {reallyBig}");

            // Pause program execution before exiting
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
