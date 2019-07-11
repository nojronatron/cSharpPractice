using System;
using System.Diagnostics;

namespace PerformingExponentiation
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw1 = new Stopwatch();
            double a = 2; // number
            double p = 32; // power
            Console.WriteLine("***** Fun with Exponentiation *****");
            Console.WriteLine($"Inputs: {a}^{p}\n");

            // use dotnet POW()
            sw1.Start();
            double pPow = Math.Pow(a, p);
            sw1.Stop();
            Console.WriteLine($"Using DotNet Math.Pow(a, p)...");
            Console.WriteLine($"Result: {pPow:N}");
            Console.WriteLine($"Elapsed Ticks: {sw1.ElapsedTicks}\n");

            // use multiplication to find powers
            sw1.Start();
            double mp = MultiplicativePowers(a, p);
            sw1.Stop();
            Console.WriteLine($"MultiplicativePowers (Start with {a}, then multiply it with itself {p - 1} more times)...");
            Console.WriteLine($"Result: {mp:N}");
            Console.WriteLine($"Elapsed Ticks: {sw1.ElapsedTicks}\n");
            sw1.Reset();

            // use Exponentiation (Book pg.35)
            sw1.Start();
            double cp = CalculatePowers(a, p);
            sw1.Stop();
            Console.WriteLine($"Calculated Exponentiation...");
            Console.WriteLine($"Result: {cp:N}");
            Console.WriteLine($"Elapsed Ticks: {sw1.ElapsedTicks}\n");

            // check all answers
            if (pPow.CompareTo(mp) == 0)
            {
                if (pPow.CompareTo(cp) == 0)
                {
                    Console.WriteLine($"\nAll results are the same!");
                }
                else if (mp.CompareTo(cp) != 0)
                {
                    Console.WriteLine($"Muliplicative Powers {mp} and Calculated Explonentiation {cp} are different.");
                }
                else
                {
                    Console.WriteLine($"DotNet Math {pPow} and Calculated Exponentiation {cp} are different.");
                }
            }
            else
            {
                Console.WriteLine($"DotNet math {pPow} and MultiplicativePowers {mp} are different.");
            }

            Console.WriteLine("\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
        static double MultiplicativePowers(double A, double P)
        {
            if (P == 0)
            {
                return 1;
            }
            double result = A;
            for (int i = 2; i <= P; i++)
            {
                result *= A;
            }
            return result;
        }
        static double CalculatePowers(double A, double P)
        {
            if (P < 0)
            {
                return -1; // standard error output alternative to throwing an exception
            }
            double N = 0;
            double tracker = 1;
            // calculate A, A^2, A^4, A^8... until A^N where N + 1 > P
            while (N + 1 <= P)
            {
                N++;
                tracker = Math.Pow(A, N);
            }
            return tracker;
        }
    }
}
