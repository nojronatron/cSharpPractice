using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntroductionToTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Threads *****");
            Console.WriteLine($"ThreadID in Main: { Thread.CurrentThread.ManagedThreadId }; TaskID { Task.CurrentId }.");

            ////  These methods will run synchronously on Thread1 in order
            //Display1();
            //Display2();

            //  use Task class to run each method asynchronously (in parallel)
            //  step 1) Create an Action Delegate by assigning a method() to it
            Action action1 = Display1;  //  'the action delegate' that references a method()
            //  step 2) Create the Task
            Task task1 = new Task(action1); //  starting this task thereby starts the method referenced by the action delegate
            //  step 3) Execute the Task
            task1.Start();  //  start the asynchronous operation: Display1

            Action action2 = Display2;
            Task task2 = new Task(action2);
            task2.Start();

            Action action3 = Display3;
            Task task3 = Task.Factory.StartNew(action3);

            //  create a new task in a single-line using Lambda expression
            //      REPLACE the Action Delegate
            Task task4 = Task.Factory.StartNew(() =>
            {
                for (int i = 100_000; i <= 100_100; i++)
                {
                    //Thread.SpinWait(30_000_000);
                    Console.WriteLine($"ThreadID: { Thread.CurrentThread.ManagedThreadId };\tTaskID { Task.CurrentId };\ti: {i}");
                }

            });





            Console.WriteLine("Press <Enter> to exit. . .");
            Console.Read();
        }
        static void Display1()
        {
            for (int i = 1; i <= 100; i++)
            {
                //Thread.SpinWait(30_000_000);
                Console.WriteLine($"ThreadID: { Thread.CurrentThread.ManagedThreadId };\tTaskID { Task.CurrentId };\ti: {i}");
            }
        }
        static void Display2()
        {
            for(int i = 1000; i <= 1100; i++)
            {
                //Thread.SpinWait(30_000_000);
                Console.WriteLine($"ThreadID: { Thread.CurrentThread.ManagedThreadId };\tTaskID { Task.CurrentId };\ti: {i}");
            }
        }
        static void Display3()
        {
            for (int i = 10000; i <=10100; i++)
            {
                //Thread.SpinWait(30_000_000);
                Console.WriteLine($"ThreadID: { Thread.CurrentThread.ManagedThreadId };\tTaskID { Task.CurrentId };\ti: {i}");
            }
        }
    }
}
