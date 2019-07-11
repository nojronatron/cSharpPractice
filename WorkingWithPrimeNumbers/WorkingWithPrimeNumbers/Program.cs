using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WorkingWithPrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw1 = new Stopwatch();
            const double A = 1717171717;
            // Prime Numbers are counting numbers that are greater than 1, 
            //  and can only be divided evenly by itself and the number 1
            // Composite Numbers are counting numbers that are greater than 1
            //  and are NOT Prime
            Console.WriteLine("***** Fun with Prime Number Alogorithms *****");
            Console.WriteLine($"\nInput number: {A}\n");

            Console.WriteLine(" => FindPrimeFactors_Alpha() <=");
            Display(FindPrimeFactors_Alpha(A));
            sw1.Start();
            FindPrimeFactors_Alpha(A);
            sw1.Stop();
            Console.WriteLine($"Elapsed Ticks: {sw1.ElapsedTicks}\n");

            sw1.Reset();
            Console.WriteLine();
            Console.WriteLine(" => FindPrimeFactors_Bravo() <=");
            Display(FindPrimeFactors_Bravo(A));
            sw1.Start();
            FindPrimeFactors_Bravo(A);
            sw1.Stop();
            Console.WriteLine($"Elapsed Ticks: {sw1.ElapsedTicks}\n");

            Console.WriteLine();
            Console.WriteLine("Press <Enter> to exit. . .");
            Console.ReadLine();
        }
        static List<double> FindPrimeFactors_Bravo(double number)
        {
            // suggested algorithm improvements made here
            // 1) dividing by any other even number than 2 is not necessary,
            //  because 2 is the base even Composite number.
            // 2) check factors only up to the sqrt() of the number
            //  if n=p*q either p or q must be less than or equal to sqrt(n)
            //  once the smaller factor is found, n/small_factor = larger_factor.
            // 3) every time you divide the number by a factor you can update
            //  the upper bound on the possible factors that you need to check.
            List<double> factors = new List<double>();
            // pull out factors of 2
            while (number % 2 == 0)
            {
                factors.Add(2);
                number = number / 2;
            } // end while
            // look for odd factors
            int i = 3;
            double max_factor = Math.Sqrt(number);
            while (i <= max_factor)
            {
                // pull out factors of i
                while (number % i == 0)
                {
                    // i is a factor so add it to the list
                    factors.Add(i);
                    // divide number by i
                    number = number / i;
                    // set new upper bound
                    max_factor = Math.Sqrt(number);
                } // end while
                // check next possible odd factor
                i = i + 2;
            } // end while
            // if there is anything left of number then it is a factor too
            if (number > 1)
            {
                factors.Add(number);
            }
            return factors;
        }
        static List<double> FindPrimeFactors_Alpha(double number)
        {
            List<double> factors = new List<double>();
            for (int i = 2; i < number; i++)
            {
                // pull out factors of i
                while (number % i == 0)
                {
                    // i is a factor so add it to the list
                    factors.Add(i);
                    // divide by i
                    number = number / i;
                }
                // end While... check next possible factor
            }
            if (number > 1)
            {
                factors.Add(number);
            }
            return factors; // list<int> of factors
        }
        static void Display(List<double> factors)
        {
            if (factors.Count < 1)
            {
                throw new ArgumentNullException("The list was empty!");
            }
            Console.WriteLine("\nList of Factors");
            Console.WriteLine("~~~~~~~~~~~~~~~");
            Console.WriteLine("Index\tValue");
            for (int index = 0; index < factors.Count; index++)
            {
                Console.WriteLine($"{index}\t{factors[index]}");
            }
            Console.WriteLine("~~~~~~~~~~~~~~~\n");
        }
    }
}
