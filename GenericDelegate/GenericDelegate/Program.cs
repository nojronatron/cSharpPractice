using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDelegate
{
    //  this generic delegate can represent any method returning void and taking a single parameter of type T
    public delegate void MyGenericDelegate<T>(T arg);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Generic Delegates *****\n");

            //  register targets
            MyGenericDelegate<string> strTarget = new MyGenericDelegate<string>(StringTarget);
            strTarget("Some string data");

            MyGenericDelegate<int> intTarget = new MyGenericDelegate<int>(IntTarget);
            intTarget(9);


            Console.WriteLine("Press <Enter> to exit. . .");
            Console.ReadLine();
        }

        static void StringTarget(string arg)
        {
            Console.WriteLine($"arg in uppercase is: { arg.ToUpper() }.");
        }

        static void IntTarget(int arg)
        {
            Console.WriteLine($"++arg is: { ++arg }.");
        }
    }
}
