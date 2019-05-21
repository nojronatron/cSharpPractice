using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAndTesterClasses
{
    class Tester
    {
        static void Main(string[] args)
        {
            bool repeater = true;
            do
            {
                Console.Clear();
                Console.WriteLine("***** Calculator Tester *****");
                Console.WriteLine("Enter two numbers to be added together.");
                Console.Write("\nFirst number: ");
                int alpha = int.Parse(Console.ReadLine());
                Console.Write("\nSecond number: ");
                int bravo = int.Parse(Console.ReadLine());

                Calculator calc = new Calculator();
                Console.Write($"\nThe sum of {alpha} and {bravo} is {calc.Add(alpha, bravo)}");

                // pause program execution
                Console.Write("\n\nEnter \"y\" to run another test or \"n\" to exit the program:");
                string again = Console.ReadLine();

                // if(again.IndexOf("y", StringComparison.OrdinalIgnoreCase))
                if(again.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    repeater = false;
                }

            } while (repeater);

            Console.Clear();
            //Console.Write("Exiting program. Press the Enter key:");
            //Console.ReadLine();
        }
    }
}
