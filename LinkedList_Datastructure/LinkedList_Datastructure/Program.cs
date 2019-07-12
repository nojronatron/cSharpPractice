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
            try
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

                // Test Find Data
                Console.WriteLine("\nExecuting Find(50)... a findable value");
                int value = 50;
                MyLinkedListNode f1 = list1.Find(value);
                if (f1 != null)
                {
                    Console.WriteLine($"Found node {f1.data}!");
                }
                else
                {
                    Console.WriteLine($"Unable to find node with data = {value}.");
                }
                Console.WriteLine("\nExecuting Find(10)... not a findable value");
                value = 100;
                MyLinkedListNode f2 = list1.Find(value);
                if (f2 != null)
                {
                    Console.WriteLine($"Found node {f2.data}!");
                }
                else
                {
                    Console.WriteLine($"Unable to find node with data = {value}.");
                }

                Console.WriteLine("\nExecuting AddAfter(f4, 80)");
                MyLinkedListNode f3 = new MyLinkedListNode(300);
                // add data=800 after data=80
                // 1) Find Node with data:80
                // 2) Apply the AddAfter()
                MyLinkedListNode f4 = list1.Find(80);
                MyLinkedListNode addafter = list1.AddAfter(f4, 800); // f4=node to add after, 800=data for newnode
                object[] arr4 = new object[list1.Count];
                list1.CopyTo(arr4, 0);
                Display(arr4);

                // In-Class Exercise
                Console.WriteLine("Press <Enter> to see In-Class Exercise results. . .");
                Console.ReadLine();
                Console.Clear();

                MyLinkedList list2 = new MyLinkedList();
                list2.AddLast("John");
                list2.AddLast("Sandra");
                list2.AddLast("Michelle");
                list2.AddLast("Peter");
                addafter = list2.Find("Sandra");
                list2.AddAfter(addafter, "Robert");
                addafter = list2.Find("Robert");
                list2.AddAfter(addafter, "Karen");
                object[] arr5 = new object[list2.Count];
                list2.CopyTo(arr5, 0);
                Display(arr5);
                list2.RemoveFirst(); // should be John
                list2.RemoveFirst(); // should be Sandra
                object[] arr6 = new object[list2.Count];
                list2.CopyTo(arr6, 0);
                Display(arr6);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n{ex.GetType().Name} : {ex.Message}\n{ex.StackTrace}");
            }
            // End of coding
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
