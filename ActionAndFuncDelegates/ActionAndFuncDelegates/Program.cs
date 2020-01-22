using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates
{
    class Program
    {
        //  the target for the Action<T> delegate
        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            //  set color of console text
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;

            for (int i=0; i<printCount; i++)
            {
                Console.WriteLine($"{ msg }");
            }

            //  restore color
            Console.ForegroundColor = previous;
        }

        //  target for the Func<> delegate
        static int Add(int x, int y)
        {
            return x + y;
        }

        //  similar to Add but stringifies the return value
        static string SumToString(int x, int y)
        {
            return (x + y).ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Action and Func *****");
            //  use the Action<> delegate to point to DisplayMessage
            Action<string, ConsoleColor, int> actionTarget = new Action<string, ConsoleColor, int>(DisplayMessage);
            actionTarget("Action Message!", ConsoleColor.Yellow, 5);

            //  use the Func<> delegate to point to Add() method
            Func<int, int, int> funcTarget = new Func<int, int, int>(Add);
            int funcTargetOutput = funcTarget.Invoke(1, 2); //  Invoke appears to be optional
            Console.WriteLine($"Func<int, int, int> output: { funcTargetOutput }.");
            funcTargetOutput = funcTarget(2, 3);
            Console.WriteLine($"Func<int, int, int> output: { funcTargetOutput }.");
            funcTargetOutput = funcTarget(3, 5);
            Console.WriteLine($"Func<int, int, int> output: { funcTargetOutput }.");

            //  use Func<> delegate to point to the SumString() method
            Func<int, int, string> funcTarget2 = new Func<int, int, string>(SumToString);
            string funcTarget2Output = funcTarget2.Invoke(5, 8);
            Console.WriteLine($"Func<int, int, string> output: { funcTarget2Output }.");

            //  using method group conversion to shorten the code...
            Func<int, int, int> shortTarget = Add;
            Console.WriteLine($"ShortFunc<int, int, int> output: { shortTarget.Invoke(8, 13) }.");


            Console.WriteLine("\n\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
    }
}
