using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionDelegateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //  example of Func<> that takes 3 params of type int and returns the average as a double
            Func<int, int, int, double> function1 = (x, y, z) => (x + y + z) / 3.0; //  lambda exp replaces a method
            //  the above associates a Delegate to a Lambda expression
            int a = 1, b = 2, c = 3;
            Console.WriteLine($"Average of { a }, {b }, and { c }: { function1(a, b, c).ToString() }.");


            //  example of a Func<> delegate that takes NO parameters and returns an int value
            Func<int> function2 = () => new Random().Next();
            //  invoke it
            int r = function2();
            Console.WriteLine($"Random value: { r }.");






            Console.Write("\n\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
    }
}
