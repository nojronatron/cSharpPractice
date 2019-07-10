using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_Datastructure
{
    class Program
    {
        static void Main(string[] args)
        {
            // TESTS
            // addfirst
            // addlast
            // copyto
            Console.WriteLine("Creating linked list => 10 thru 70...");
            MyLinkedList list1 = new MyLinkedList();
            list1.AddFirst(10);
            list1.AddFirst(20);
            list1.AddFirst(30);
            list1.AddFirst(40);
            list1.AddFirst(50);
            list1.AddFirst(60);
            list1.AddFirst(70);

            Console.WriteLine("Executing AddLast() => 80, 90, and 100...");
            // test AddLast()
            list1.AddLast(80);
            list1.AddLast(90);
            list1.AddLast(100);

            Console.WriteLine("Creating an Array and copying Linked List into it...");
            // make an array
            object[] arr1 = new object[list1.Count];

            // copy linked list back to an array
            list1.CopyTo(arr1, 0);

            // display the array
            Console.WriteLine("Executing static void Display() method...");
            Display(arr1);

            // test RemoveFirst, copy it to a new array, then display array
            list1.RemoveFirst();
            object[] arr2 = new object[list1.Count];
            list1.CopyTo(arr2, 0);
            Console.WriteLine("\nExecuted RemoveFirst()...");
            Display(arr2);

            // test RemoveLast, copy it to a new array, then display array
            list1.RemoveLast(); // TODO: Create RemoveLast() method in class MyLinkedList
            object[] arr3 = new object[list1.Count];
            list1.CopyTo(arr3, 0);
            Console.WriteLine("\nExecuted RemoveLast()...");
            Display(arr3);

            Console.ReadLine();
        }
        static void Display(object[] array)
        {
            foreach (object data in array)
            {
                Console.WriteLine(data);
            }
            Console.WriteLine();
        }
    }
}
