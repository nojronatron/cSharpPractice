using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelForEach
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 0, 10, 20, 30, 40, 50, 60, 70, 80, 90 };
            //  normal for loop
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(
                    $"Standard For Loop ==>> taskId: { Task.CurrentId } \t" +
                    $"item={ DoStuff(i) }\t" +
                    $"threadId: { Thread.CurrentThread.ManagedThreadId }");
                //Thread.SpinWait(10_000_000);
            }
            Console.WriteLine();

            //  Parallel ForEach:
            //  ForEach<TSource>(IEnumerable<TSource>, ParallelOptions, Action<TSource>) 
            Parallel.ForEach(array, x =>
            {
                Console.WriteLine(
                    $"Parallel.ForEach Loop ==>> taskId: { Task.CurrentId } \t" +
                    $"item={ DoStuff(x) }\t" +
                    $"threadId: { Thread.CurrentThread.ManagedThreadId }");
            });
            Console.WriteLine();


            Console.Write("\n\nPress <Enter> to Exit. . .");
            Console.ReadLine();
        }
        static double DoStuff(int num)
        {
            if (num < 1)
            {
                return 0;
            }
            if (num == 1 || num == 2)
            {
                return num;
            }
            return DoStuff(num - 1) + DoStuff(num - 2);
        }
    }
}