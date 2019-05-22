using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstData
{
    class MyMathClass
    {
        public const double PI = 3.1415;
    }

    class MyMathClass2
    {
        public readonly double PI;
        public MyMathClass2 () { PI = 3.1416916; }

        // Unable to: public void ChangePI() {PI = 3.14444;}
        // This is not legal because the Readonly Field can only exist inside a Constructor
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With Const *****");
            Console.WriteLine($"The value of PI is: {MyMathClass.PI}");

            // Cannot change a const, example:
            // MyMathClass.PI = 0;
            // The Left-hand side of the assignment is neither a variable, property, nor indexer
            // This works when local const data is assigned within the Method() it is created in
            LocalConstSTringVariable();

            Console.ReadLine();
        }

        static void LocalConstSTringVariable()
        {
            // A local constant data point can be directly accessed
            const string fixedStr = "Fixed string Data";
            Console.WriteLine(fixedStr);
        }
    }
}
