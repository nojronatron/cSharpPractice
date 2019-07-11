using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatestCommonDivisors
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAXCAP = 30;
            Console.WriteLine("***** Fun with Greatest Common Denominator Algorithm *****");
            Random rand = new Random();
            List<int> alpha = new List<int>(MAXCAP);
            List<int> bravo = new List<int>(MAXCAP);

            for (int i=0; i <= MAXCAP-1; i++)
            {
                int item1 = rand.Next(1, MAXCAP);
                alpha.Add(item1);
                int item2 = rand.Next(3, MAXCAP + 2);
                bravo.Add(item2);
            }
            Console.WriteLine();

            Console.WriteLine("A=\t\tB=\t\tGCD=");
            Console.WriteLine("~~\t\t~~\t\t~~~~");
            for (int j=0; j<MAXCAP-1;j++)
            {
                Console.WriteLine($"{alpha[j]}\t\t{bravo[j]}\t\t{FindGCD(alpha[j], bravo[j])}");
            }

            Console.WriteLine("\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
        static int FindGCD(int a, int b)
        {
            while (b != 0)
            {
                int remainder = a % b;
                a = b;
                b = remainder;
            }
            return a;
        }
    }
}
