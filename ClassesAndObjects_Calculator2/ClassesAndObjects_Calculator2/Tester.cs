using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects_Calculator2
{
    class Tester
    {
        static void Main(string[] args)
        {
            // Create Object Instance using primary Constructor
            Calculator c1 = new Calculator(1, 2);

            // Add and Multiply using Tester's Methods
            Console.WriteLine($"Result: {c1.Add()}");
            Console.WriteLine($"Result: {c1.Multiply()}");
            
            // Create Object Instance using Copy Constructor
            Calculator c2 = new Calculator(c1);
            
            // Add and Multiply using Tester's Methods
            Console.WriteLine($"Result: {c2.Add()}");
            Console.WriteLine($"Result: {c2.Multiply()}");

            Console.ReadLine();
        }
    }
}
