using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDelegate
{
    class Program
    {
        public delegate int BinaryOp(int x, int y);
        static void Main(string[] args)
        {
            Console.WriteLine("***** Async Delegate Invokation *****\n");

            //  print out the ID of the executing thread
            Console.WriteLine($"Main() invoked on thread { Thread.CurrentThread.ManagedThreadId }.");

            //  invoke Add() on a secondary thread
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult ar = b.BeginInvoke(10, 20, null, null);
            //  once these statements are processed the calling thread is blocked until BeginInvoke() completes

            //  do other work on primary thread
            Console.WriteLine($"Doing more work in Main()!");

            //  obtain the result of the Add() method when ready
            int answer = b.EndInvoke(ar);
            Console.WriteLine($"10 + 10 = { answer }.");


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
