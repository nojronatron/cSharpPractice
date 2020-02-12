using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReviewDotNetDelegates
{
    class Program
    {
        //  a C# delegate type that matches a method with return type INT and takes two parameters of type INT
        public delegate int BinaryOp(int x, int y);
        static void Main(string[] args)
        {
            Console.WriteLine("***** Sync Delegate Review *****\n");

            //  print out the ID of the executing thread
            Console.WriteLine($"Main() invoked on thread { Thread.CurrentThread.ManagedThreadId }.");

            //  invoke Add() in a synchronous manner
            BinaryOp b = new BinaryOp(Add);

            //  could also write b.Invoke(10, 10)
            int answer = b.Invoke(10, 10);

            //  these lines will not execute until the Add() method has completed
            Console.WriteLine($"Doing more work in Main()!");
            Console.WriteLine($"10 + 10 is { answer }.");

            //  just for fun
            Console.WriteLine($"5 + 10 is { b.Invoke(5, 15) }.");



            Console.Write($"\n\nPress <Enter> to Exit. . .");
            Console.ReadLine();
        }
        static int Add(int x, int y)
        {
            //  print out the ID of the executing thread
            Console.WriteLine($"Add() invoked on thread { Thread.CurrentThread.ManagedThreadId }.");

                //  pause to simulate a lengthy operation
                Thread.Sleep(5000);
            return x + y;
        }
    }
}
