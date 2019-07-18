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
            // object[] dataArray = ms1.ToArray();
            // display the copied stack array
            // Display(dataArray);
            DisplayStack(myStack1); // using IEnumerable's GetEnumerator is the correct way to implement this

            myStack1.Push("Steve");
            DisplayStack(myStack1);

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
            Stack<string> myStack2 = new Stack<string>(5);
            myStack2.Push("one");
            myStack2.Push("two");
            myStack2.Push("three");
            myStack2.Push("four");
            myStack2.Push("five");
            Queue<string> myQueue1 = CopyToQueue(myStack2);
            Stack<string> myStack3 = CopyToStack(myQueue1);

            // reverse a queue
            Queue<string> myQueue2 = new Queue<string>(5);
            myQueue2.Enqueue("alpha");
            myQueue2.Enqueue("bravo");
            myQueue2.Enqueue("charlie");
            myQueue2.Enqueue("delta");
            myQueue2.Enqueue("foxtrot");
            Reverse(myQueue2);
            
            // remove last have of queue
            myQueue2.Enqueue("alpha");
            myQueue2.Enqueue("bravo");
            myQueue2.Enqueue("charlie");
            myQueue2.Enqueue("delta");
            myQueue2.Enqueue("foxtrot");
            myQueue2.Enqueue("golf");
            myQueue2.Enqueue("hotel");
            myQueue2.Enqueue("india");
            myQueue2.Enqueue("juliet");
            myQueue2.Enqueue("kilo");
            RemoveLastHalf(myQueue2);

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
            Console.WriteLine($"\nMyQueue3 Contents:");
            DisplayIntQueue(myQueue3);
            Console.WriteLine($"\nMyQueue4 Contents:");
            DisplayIntQueue(myQueue4);
            Console.WriteLine("\nMerging MyQueue3 and MyQueue4. . .");
            
            DisplayIntQueue(Merge(myQueue3, myQueue4));

            Console.Write("\n\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
        // DONE: Merge two queue into a single queue to return
        //    merge by alternating between q1 and q2
        //    an item from q1 then an item from q2, then back and forth
        //    the two q's don't have to be of the same size
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
            for (int i = 0; i <= max_size; i++)
            {
                try
                {
                    if (queue1.Count > 0)
                    {
                        mergedQueue.Enqueue(queue1.Dequeue());
                    }
                    if (queue2.Count > 0)
                    {
                        mergedQueue.Enqueue(queue2.Dequeue());
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine($"Caught an exception: {ioe.Message}\n{ioe.StackTrace}");
                }
            }
            // queue1 = mergedQueue;
            return mergedQueue;
        }

        // DONE: Write a method that removes last half of a Queue
        static void RemoveLastHalf(Queue<string> queue)
        {
            // example queue has 10 items alpha through kilo
            // get the size of the source Collection
            int q_size = queue.Count;
            // find the mid-point to use as a stop marker
            int mid_point = queue.Count / 2;
            // create a temp Queue collection to store items in
            Queue<string> temp = new Queue<string>(mid_point);
            // cycle through items zero through mid_point, enqueuing them to the new queue, then stop
            for (int i=0; i < mid_point; i++)
            {
                temp.Enqueue(queue.Dequeue());
            }
            // reset the REF to queue to point to new Queue temp in memory
            queue = temp;
            Console.WriteLine($"\nResults of RemoveLastHalf() method:");
            DisplayStringQueue(queue);
            // for this exercise it is _not_ necessary to return or display the results (just use a breakpoint to watch it)
            Console.WriteLine();
        }

        // write a method that copies a stack to a queue
        //1) at the end stack is empty and the queue would hold the original content
        //    in such a way that the top of the stack be the first in teh queue
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
        // reverse a queue using a stack as a helper
        static void Reverse(Queue<string> queue)
        {
            // DONE: FIX THIS -- don't re-use the existing Methods() in this exercise!
            // take the queue and copy it to a Stack
            // print-out the queue contents
            int initial_size = queue.Count;
            Stack<string> temp_stack = new Stack<string>(initial_size);
            for (int i=0; i < initial_size; i++)
            {
                 temp_stack.Push(queue.Dequeue());
            }
            Console.WriteLine($"\nReverse ordered Stack follows...");
            for(int j=0; j < initial_size; j++)
            {
                Console.WriteLine(temp_stack.Pop());
            }
            Console.WriteLine();
        }
        static void DisplayStack(MyStack stack)
        {
            Console.WriteLine("\nCurrent contents of MyStack");
            Console.WriteLine("===========================");
            foreach(object item in stack)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine("===========================\n");
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
        static void DisplayIntQueue(Queue<int> a_queue)
        {
            Console.WriteLine("\n***** Displaying Contents of a Queue<int> *****");
            Array temp = a_queue.ToArray();
            int limit = temp.Length;
            for (int i=0; i<limit; i++)
            {
                Console.WriteLine(temp.GetValue(i));
            }
            Console.WriteLine();
        }
        static void DisplayStringQueue(Queue<string> a_queue)
        {
            Console.WriteLine("\n***** Displaying Contents of a Queue<string> *****");
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
