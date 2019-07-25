using System;
using System.Collections.Generic;

namespace StackArrayImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With Stacks *****");
            MyStack myStack1 = new MyStack(4);
            myStack1.Push("John");
            myStack1.Push("Sandra");
            myStack1.Push("Mike");
            myStack1.Push("David");
            myStack1.Push("Michelle");
            myStack1.Push("Karen");

            // copy stack to an array
            // 1) bad example:
            //      object[] dataArray = ms1.ToArray();
            //      display the copied stack array
            //      Display(dataArray);
            // 2) the right way...
            DisplayMyStack(myStack1); // using IEnumerable's GetEnumerator is the correct way to implement this

            myStack1.Push("Steve");
            Console.WriteLine("Adding \"Steve\" to myStack1. . .");
            DisplayMyStack(myStack1);

            Console.ReadLine();

            Console.WriteLine($"\nCurrent \"Top\" item: {myStack1.Peek()}");
            Console.WriteLine($"\nPOPing the \"Top\" item: {myStack1.Pop()}");

            Console.WriteLine($"\nAfter 1 Pop(), the new top item is: {myStack1.Peek()}");
            myStack1.Pop();
            myStack1.Pop();
            Console.WriteLine($"\nAfter 2 more Pop()s, the new top item is: {myStack1.Peek()}");
            myStack1.Pop();
            myStack1.Pop();
            myStack1.Pop();
            // this last one will cause an Exception to be thrown because the Stack is empty
            // ms1.Pop();

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("***** Exercises: CopyToQueue, CopyToStack, and Reverse *****");
            Console.WriteLine("\nUse DEBUG to see CopyToQueue(myStack2) and CopyToStack(myQueue1) execute.");
            Stack<string> myStack2 = new Stack<string>(5);
            myStack2.Push("one");
            myStack2.Push("two");
            myStack2.Push("three");
            myStack2.Push("four");
            myStack2.Push("five");
            Queue<string> myQueue1 = CopyToQueue(myStack2);
            DisplayStringQueue(myQueue1, "myQueue1 created by copying from myStack2");
            Stack<string> myStack3 = CopyToStack(myQueue1);
            DisplayStack(myStack3, "myStack3 created by copying from myQueue1");

            Console.ReadLine();
            Console.Clear();

            // reverse a queue
            Queue<string> myQueue2 = new Queue<string>(5);
            myQueue2.Enqueue("alpha");
            myQueue2.Enqueue("bravo");
            myQueue2.Enqueue("charlie");
            myQueue2.Enqueue("delta");
            myQueue2.Enqueue("foxtrot");
            DisplayStringQueue(myQueue2, "Phonetics Stack before reversal");
            Reverse(myQueue2);  // built-in operations will empty myQueue2 and display the temp Stack so both empty after execution

            Console.ReadLine();
            Console.Clear();

            // remove last have of queue
            myQueue2.Enqueue("alpha");
            myQueue2.Enqueue("bravo");
            myQueue2.Enqueue("charlie");
            myQueue2.Enqueue("delta");
            myQueue2.Enqueue("echo");
            myQueue2.Enqueue("foxtrot");
            myQueue2.Enqueue("golf");
            myQueue2.Enqueue("hotel");
            myQueue2.Enqueue("india");
            myQueue2.Enqueue("juliet");
            myQueue2.Enqueue("kilo");
            myQueue2.Enqueue("lima");   
            myQueue2.Enqueue("mike");   // 13
            myQueue2.Enqueue("november");
            myQueue2.Enqueue("oscar");
            myQueue2.Enqueue("papa");
            myQueue2.Enqueue("quebec");
            myQueue2.Enqueue("roger");
            myQueue2.Enqueue("sierra");
            myQueue2.Enqueue("tango");
            myQueue2.Enqueue("uniform");
            myQueue2.Enqueue("victor");
            myQueue2.Enqueue("whiskey");
            myQueue2.Enqueue("x-ray");
            myQueue2.Enqueue("yankee"); // 25
            //myQueue2.Enqueue("zulu");   // 26
            DisplayStringQueue(myQueue2, "myQueue2 before RemoveLastHalf()");
            RemoveLastHalf(myQueue2);

            Console.ReadLine();
            Console.Clear();

            // merge two queues into one
            Console.WriteLine("***** Merge Two Queues *****");
            Queue<int> myQueue3 = new Queue<int>(3);
            Queue<int> myQueue4 = new Queue<int>(5);
            myQueue3.Enqueue(1);
            myQueue3.Enqueue(2);
            myQueue3.Enqueue(3);
            myQueue3.Enqueue(4);
            myQueue3.Enqueue(5);
            myQueue4.Enqueue(10);
            myQueue4.Enqueue(20);
            myQueue4.Enqueue(30);
            DisplayIntQueue(myQueue3, "myQueue3");
            DisplayIntQueue(myQueue4, "myQueue4");
            
            DisplayIntQueue(Merge(myQueue3, myQueue4), "Merged myQueue3 and myQueue4");

            Console.Write("\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
        // DONE: Merge two queue into a single queue to return
        //    merge by alternating between q1 and q2
        //    an item from q1 then an item from q2, then back and forth
        //    the two q's don't have to be of the same size
        // DONE: Re-write the Merge() method using WHILE loops instead of FOR loops with IF/THEN conditionals
        //       and use as few resources as possible
        static Queue<int> Merge(Queue<int> queue1, Queue<int> queue2)
        {
            int max_size = 0;
            int q1_count = queue1.Count;
            int q2_count = queue2.Count;
            if (q1_count >= q2_count)
            {
                max_size = q1_count;
            }
            else
            {
                max_size = q2_count;
            }
            Queue<int> mergedQueue = new Queue<int>(max_size);
            while (queue1.Count > 0 && queue2.Count > 0)
            {
                mergedQueue.Enqueue(queue1.Dequeue());
                mergedQueue.Enqueue(queue2.Dequeue());
            }
            while (queue1.Count > 0)
            {
                mergedQueue.Enqueue(queue1.Dequeue());
            } while (queue2.Count > 0)
            {
                mergedQueue.Enqueue(queue2.Dequeue());
            }
            return mergedQueue;
        }
        // DONE: Write a method that removes last half of a Queue
        // DONE: Re-write this so that a temp object is not used (fewer resources)
        // DONE: Be sure to handle both odd & even number queue lengths
        static void RemoveLastHalf(Queue<string> queue)
        {
            // example queue has 10 items alpha through kilo
            // get the size of the source Collection
            // DONE: Remove "int q_size = queue.Count;" (not needed)
            // find the mid-point to use as a stop marker
            int mid_point = queue.Count / 2;    // by forcing mid_point to be an int a rounding is accomplished
            Console.WriteLine("===>>> Executing RemoveLastHalf() method.");
            while(queue.Count > mid_point)
            {
                Console.WriteLine(queue.Dequeue());
                // Example Queue & Dequeue:
                //          <type> item = queue.Dequeue();
                //          queue.Enqueue(item);
            }
            // for this exercise it is _not_ necessary to return or display the results (just use a breakpoint to watch it)
            Console.WriteLine();
        }

        // write a method that copies a stack to a queue
        // at the end stack is empty and the queue would hold the original content
        //    in such a way that the top of the stack be the first in the queue
        static Queue<string> CopyToQueue(Stack<string> stack)
        {
            int initial_size = stack.Count;
            Queue<string> q1 = new Queue<string>(initial_size);
            for(int i=0; i < initial_size; i++)
            {
                q1.Enqueue(stack.Pop());
            }
            return q1;
        }
        // copy content of a queue to a stack, at the end the queue become empty, return the stack
        static Stack<string> CopyToStack(Queue<string> queue)
        {
            int initial_size = queue.Count;
            Stack<string> s1 = new Stack<string>(initial_size);
            for(int i=0; i < initial_size; i++)
            {
                s1.Push(queue.Dequeue());
            }
            return s1;
        }
        // DONE: create a Method that returns Type MyStack
        // TODO: now test it
        static MyStack CopyToMyStack(Queue<string> queue)
        {
            MyStack ms1 = new MyStack(queue.Count);
            while (queue.Count > 0)
            {
                ms1.Push(queue.Dequeue());
            }
            return ms1;
        }
        // reverse a queue using a stack as a helper
        static void Reverse(Queue<string> queue)
        {
            // DONE: FIX THIS -- don't re-use the existing Methods() in this exercise!
            // take the queue and copy it to a Stack
            // print-out the queue contents
            int initial_size = queue.Count;
            Stack<string> temp_stack = new Stack<string>(initial_size);
            while (queue.Count > 0)
            {
                temp_stack.Push(queue.Dequeue());
            }
            Console.WriteLine($"\n===>>> Reverse ordered Stack follows...");
            while (temp_stack.Count > 0)
            {
                Console.WriteLine(temp_stack.Pop());
            }
            Console.WriteLine();
        }
        static void DisplayMyStack(MyStack stack, string comment="Displaying a MyStack")
        {
            Console.WriteLine($"\n***** {comment} *****");
            foreach(object item in stack)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine();
        }
        // below is legacy code that does not take advantage of DotNet's IEnumerable interface
        // static void Display(object[] arr)
        //{
        //    Console.WriteLine("Contents of MyStack");
        //    Console.WriteLine("===================");
        //    foreach(object data in arr)
        //    {
        //        Console.WriteLine(data);
        //    }
        //}
        static void DisplayStack(Stack<string> stack, string comment = "Displaying a Stack<string>")
        {   // This helper function created to handle Type Stack<> stacks
            Console.WriteLine($"\n***** {comment} *****");
            foreach (object item in stack)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine();
        }
        static void DisplayIntQueue(Queue<int> a_queue, string comment="Displaying a Queue<int>")
        {
            Console.WriteLine($"\n***** {comment} *****");
            Array temp = a_queue.ToArray();
            int limit = temp.Length;
            for (int i=0; i<limit; i++)
            {
                Console.WriteLine(temp.GetValue(i));
            }
            Console.WriteLine();
        }
        static void DisplayStringQueue(Queue<string> a_queue, string comment="Displaying a Queue<string>")
        {
            Console.WriteLine($"\n***** {comment} *****");
            Array temp = a_queue.ToArray();
            int limit = temp.Length;
            for (int i=0; i<limit; i++)
            {
                Console.WriteLine(temp.GetValue(i));
            }
            Console.WriteLine();
        }
    }
}
