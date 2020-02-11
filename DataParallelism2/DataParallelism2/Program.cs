using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataParallelism2
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

            //  EVERY iteration of the FOR loop runs in its own thread and all cycles are independant of each other
            Parallel.For(0, 20, i =>
            {
                Console.WriteLine($"Parallel For Loop Task ==>> taskId: { Task.CurrentId } \ti={ i }\tthreadId: { Thread.CurrentThread.ManagedThreadId }");
                //Thread.SpinWait(10_000_000);
            });

            //  regular loop to compute sumroot() then parallel for loop to compute sumroot()

            Console.WriteLine( SumRoot(10) );
            Parallel.For(0, 20, i =>
            {
                double result = SumRoot(i);
                Console.WriteLine($"Parallel For Loop Task ==>> taskId: { Task.CurrentId } \ti={ i }\tresult={ result }\tthreadId: { Thread.CurrentThread.ManagedThreadId }");
            });


            Console.Write("Press <Enter> to Exit. . .");
            Console.ReadLine();
        }
        static double SumRoot(int root)
        {
            double result = 0;
            for (int i = 0; i < 10_000_000; i++)
            {
                result += Math.Exp(Math.Log(i)) / root;
            }
            return result;
        }
    }
}
