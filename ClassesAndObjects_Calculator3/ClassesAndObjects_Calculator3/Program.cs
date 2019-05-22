using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects_Calculator3
{
    public class Calculator
    {
        // Parameter passing can be used in a Method - the out keyword must be used
        public void Add(int a, int b, out int z)
        {
            // Add Method using Out keyword (note void return type)
            z = a + b;
        }
    }
    class Tester
    {
        static void Main(string[] args)
        {
            // define local variables - the third is defined in the .Add() Method call
            int alpha = 7;
            int bravo = 11;

            // Create a new instance of the Calculator Object
            Calculator calc = new Calculator();

            // Execute the .Add() Method using the out keyword
            calc.Add(alpha, bravo, out int zulu);

            // Display the results
            Console.WriteLine($"The sum of {alpha} and {bravo} is {zulu}");

            Console.ReadLine();
        }
    }
}
