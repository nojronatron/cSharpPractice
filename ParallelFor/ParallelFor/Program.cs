using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelFor
{
    class Program
    {
        static void Main(string[] args)
        {
            //  normal for loop
            for (int i = 0; i <= 20; i++)
            {
                Console.WriteLine($"Standard For Loop Task ==>> taskId: { Task.CurrentId } \ti={ i }\tthreadId: { Thread.CurrentThread.ManagedThreadId }");
                //Thread.SpinWait(10_000_000);
            }


            Console.Write("Press <Enter> to Exit. . .");
            Console.ReadLine();
        }
    }
}
