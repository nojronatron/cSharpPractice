using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncCallbackDelegate
{
    public delegate int BinOp(int a, int b);
    class Program
    {
        static bool IsDone = false;
        static void Main(string[] args)
        {
            Console.WriteLine("***** AsyncCallback Delegate Example *****\n");
            Console.WriteLine($"Main() invoked on thread { Thread.CurrentThread.ManagedThreadId }." );

            BinOp bOp = new BinOp(Add);
            IAsyncResult ar = bOp.BeginInvoke(10, 10, new AsyncCallback(AddComplete), "Callback Completed!");

            //  assume other work is performed here...
            while (!IsDone)
            {
                Console.WriteLine("Working. . .");
                Thread.Sleep(1000);
            }
            //  use the IAsyncResult (of type int, per the delegate) to capture the Add() return
            int result = bOp.EndInvoke(ar);
            Console.WriteLine($"Result of 10 + 10 is: { result }.");



            Console.Write("\n\nPress <Enter> to Exit. . .");
            Console.ReadLine();
        }
        static int Add(int x, int y)
        {
            Console.WriteLine($"Add() method invoked on thread { Thread.CurrentThread.ManagedThreadId }.");
            Thread.Sleep(1000);
            return x + y;
        }
        static void AddComplete(IAsyncResult iar)
        {
            Console.WriteLine($"AddComplete() invoked on this thread { Thread.CurrentThread.ManagedThreadId }.");
            Console.WriteLine("Addition operation complete!");
            IsDone = true;
            Console.WriteLine($"iar.AsyncState.ToString() called: { iar.AsyncState.ToString() }");
        }
    }
}
