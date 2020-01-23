using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateWithLambdaExpression
{
    //  Delegates can be defined in the Namespace or Class levels
    //  Delegates are a built-in DotNET Class, so creating a new one inherits from DotNET Delegate
    public delegate double MyDoubleDelegate(double x, double y);
    //  the SIGNATURE is defined by the input parameter(s) type(s), and the return type
    //  methods MUST have the same signature as the delegate that is referenced
    //      A Delegate can be used to reference ANY method with the same signature as the Delegate

    public delegate bool MyBoolDelegate(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            //  create Delegate object from MyDoubleDelegate
            // MyDoubleDelegate d1 = new MyDoubleDelegate(GetAverage);  //  the verbose was or previous version compiler way
            MyDoubleDelegate d1 = GetAverage;   //  a short-cut way to instantiate the instance
            double arg1 = 2, arg2 = 3;
            double avg = d1(arg1, arg2);    //  compiler issues the .Invoke method on d1
            Console.WriteLine($"The average of { arg1 } and { arg2 } is: { avg }.");


            //  a delegate object referencing an anonymous method (the old way to do it)
            //  conceptually, the dev doesn't need to name every-single-method and why name the method if it's only used
            //      in one place -- by a Delegate
            //  an anonymous method MUST be created already linked to a Delegate so there is a reference (because, its nameless)
            MyDoubleDelegate d2 = delegate (double aa, double bb)
            {
                return aa * bb;
            };  //  notice the semicolon!
            //  invoke d2 to display the result
            Console.WriteLine($"The product of { arg1 } and { arg2 } is: { d2(arg1, arg2) }.");

            MyDoubleDelegate d3 = delegate (double aa, double bb)
            {
                return aa / bb;
            };  //  notice the semicolon!
            //  invoke d3 using d3.invoke method
            Console.WriteLine($"The divisor of { arg1 } and { arg2 } is: { d3.Invoke(arg1, arg2) }.");

            //  Lambda expression as the method for the Delegate
            MyDoubleDelegate d4 = (aaa, bbb) => Math.Pow(aaa, bbb);    //  if more than one statement use curly-brackets around the statement list
            Console.WriteLine($"The average of { arg1 } and { arg2 } (as a lambda expression) is: { d4(arg1, arg2) }.");


            //  EXERCISE: Define a Delegate type that takes 2 int and returns a bool
            //              create a delegate object to reference a lambda expression that returns true
            //              if both inputs are even, false otherwise
            int arg3 = 2, arg4 = 4;
            MyBoolDelegate mbd1 = (xxx, yyy) => (xxx % 2 == 0 && yyy % 2 == 0);
            Console.WriteLine($"The inputs { arg1 } and { arg2 } are EVEN: { mbd1(arg3, arg4) }.");




            Console.WriteLine("\n\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
        //  method that takes two doubles and returns one double (a signature)
        static double GetAverage(double a, double b)
        {
            //  single-statement methods are easier to convert into a Lambda expression
            return (a + b) / 2;
        }
        static bool AreEven(int a, int b)
        {
            if (a % b == 0)
            {
                return true;
            }
            return false;
        }
    }
}
