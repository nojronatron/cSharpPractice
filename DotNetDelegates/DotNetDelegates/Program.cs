using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDelegates
{
    class Program
    {
        //  DotNet defines 3 types of delegate (generic delegates)
        //      Action<>
        //      Func<>
        //      Predicate<>
        static void Main(string[] args)
        {
            Action<int, int, int> action1 = DisplayAvg;
            Action<int, int, int> action2 = (x, y, z) => Console.WriteLine($"\nAverage value: { (x + y + z) / 3.0 }.");
            //  invoke action1 and action2
            action1(1, 2, 3);   //  no return type so just input values you want as params
            action2(4, 5, 6);

            //  TODO: Define a method that takes 5 ints and display the total and the product
            //  of all parameters
            //  TODO: Create an Action delegate for this method
            //  TODO: Create a second Action delegate for a lambda expression that takes
            //  6 doubles and display the product of all parameters

            Action<int, int, int, int, int> action3 = DisplayTotAndProd;
            Action<double, double, double, double, double, double> action4 = (a, b, c, d, e, f) => 
                Console.WriteLine($"\n(Lambda-style) Sum of { a } + { b } + { c } + { d } + { e } + { f } is { a + b + c + d + e + f }.");
            action3(1, 2, 3, 4, 5);
            action4(6, 7, 8, 9, 10, 11);



            Console.WriteLine("\n\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
        static void DisplayTotAndProd(int a, int b, int c, int d, int e)
        {
            int total = a+b+c+d+e;
            int product = a*b*c*d*e;
            Console.WriteLine($"\nDisplayTotAndProd Inputs: { a }, { b }, { c }, { d }, and { e }.");
            Console.WriteLine($"Total: { total }.");
            Console.WriteLine($"Product: { product }.");
        }
        static void DisplayAvg(int a, int b, int c)
        {
            double average = (a + b + c) / 3.0;
            Console.WriteLine($"Average value: { average }.");
        }
    }
}
