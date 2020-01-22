using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelegate
{
    //  This delegate can point to an method, taking two integers and returning an integer
    public delegate int BinaryOp(int x, int y);

    //  This class contains methods BinaryOp will point to
    public class SimpleMath
    {
        //public static int Add(int x, int y) => x + y;
        public int Add(int x, int y) => x + y;
        public static int Subtract(int x, int y) => x - y;
        public static int SquareNumber(int a) => a * a;
    }

    class Program
    {
        //  spicy delegate example
        static void DisplayDelegateInfo(Delegate delObj)
        {
            foreach (Delegate d in delObj.GetInvocationList())
            {
                Console.WriteLine($"Method Name: { d.Method }");
                Console.WriteLine($"Type Name: { d.Target }");  //  static methods will not display Type due to lack of an object instance
            }
        }

        static void Main(string[] args)
        {
            //  create non-static members (see Add() method, above) and instanciate the member object
            SimpleMath simpleMath = new SimpleMath();

            Console.WriteLine("***** Simple Delegate Example *****\n");

            //  create a BinaryOp delegate object that points to SimpleMath.Add()
            //BinaryOp bOp = new BinaryOp(SimpleMath.Add);
            BinaryOp bOp = new BinaryOp(simpleMath.Add);

            ////  the following is illegal and will cause a compile-time error
            //BinaryOp bOp2 = new BinaryOp(SimpleMath.SquareNumber);  //  missing an overload (parameter)

            //  Invoke Add() method indirectly using delegates object
            int x = 1, y = 2;
            int bOpResult = bOp(x, y);
            Console.WriteLine($"{ x } + { y } = { bOpResult }.\n");

            Console.WriteLine();

            //BinaryOp spicy = new BinaryOp(SimpleMath.Add);    //  static-object reference
            BinaryOp spicy = new BinaryOp(simpleMath.Add);
            DisplayDelegateInfo(spicy);

            Console.WriteLine();
            Console.ReadLine();
        }

        ////  this delegate can point to any method taking two integers and returnign an integer
        //public delegate int BinaryOp(int x, int y);
        ////  the compiler automatically generates a sealed class deriving from System.MulticastDelegate
        ////  System's Delegate and MulticateDelegate classes enable the Delegate to maintain a list of methods to be invoked at a later time

        //  delegate signature is: 3x bool Parameters; returns String
        public delegate string MyDelegate(bool a, bool b, bool c);

        //  delegates can point to methods that contain any number of out or ref parameters (and params array parameters)
        public delegate string MyOtherDelegate(out bool a, ref bool b, int c);

        //  Select Members, common to System Delegate and MulticastDelegate
        //  Method  Returns object representing addressed/pointed-to static method details
        //  Target  Returns an object (like Method) but for Object-Level Methods
        //  Combine()   Adds a method to the list maintained by the delegate (use += operators to activate this method)
        //  GetInvocationList()     Returns an array of System.Delegate objects each representing methods that may be invoked
        //  Remove(), RemoveAll()   Remove a/all Method/s from delegate's invocation list (use -= operator to activate this method)


    }
}
