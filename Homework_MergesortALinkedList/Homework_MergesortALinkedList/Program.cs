using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_MergesortALinkedList
{
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            //TODO: Exercise: Apply  the MergeSort to a linkedList
            //need to taylor the merge method code to a linked list.

            int max_size = 5;
            int[] nums = new int[5]{4, 2, 5, 1, 3};
            LinkedList<int> ll = new LinkedList<int>(nums);
            Console.WriteLine($"Linked List size: {ll.Count}");

            Console.Write("Searching for data=3: ");
            if (ll.Find(3) != null)
            {
                Console.Write("Found it!");
            }
            else
            {
                Console.Write("Unable to locate.");
            }
            Console.WriteLine("\n\n");

            // Start mergesort on Linked List
            DisplayLinkedList(ll);
            Console.WriteLine("Merge Sorting. . .");
            int first = 0;
            int last = ll.Count-1;
            MergeSort(ll, first, last);

            Console.Write("\n\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
        static void MergeSort(LinkedList<int> a, int first, int last)
        {
            if (first >= last)
            {
                return;
            }
            // TODO: Find the middle LLNode which should be (-1 + Count) / 2
            int mid = a.Count;
            mid = (mid - 1) / 2;
            LinkedListNode<int> temp_node = a.First;
            LinkedList<int> left_list = new LinkedList<int>();
            LinkedList<int> right_list = new LinkedList<int>();
            for(int i=0; i<=mid; i++)
            {
                left_list.AddLast(temp_node.Value);
                temp_node = temp_node.Next;
            }
            for(int j=mid+1; j<=last; j++)
            {
                right_list.AddLast(temp_node.Value);
                temp_node = temp_node.Next;
            }
            
            //DisplayFirstMidLastValues(first, mid, last);
            // Seems to be DONE: divide the array into 2 subarrays until each subarray would contain a single item
            MergeSort(left_list, 0, left_list.Count-1);
            MergeSort(right_list, 0, right_list.Count-1);
            // TODO: Figure out how to do the MERGE using LINKED LIST NODES
            //merge the subarrays
            Merge(a, first, mid, last);
            //DisplayFirstMidLastValues(first, mid, last);
        }
        static void Merge(LinkedList<int> a, int first, int mid, int last)
        {
            Console.WriteLine($"Merge(first={first}, mid={mid}, last={last}");
            //merging left subarray [first to mid] with right subarray [mid+1 to last]
            //initialize i and j to the start of each sub array
            int i = first;
            int j = mid + 1;
            int k = 0; //index for the temp array
            //DisplayFirstMidLastValues(i, j, last);
            //create a temp just big enough to hold the content of both sub arrays
            //what is the size of this temp array
            int[] temp = new int[last - first + 1];
            //merge
            while (i <= mid && j <= last)
            {
                if (a[i] <= a[j])
                {
                    //copy a[i] to temp
                    temp[k] = a[i];
                    i++;
                    k++;
                }
                else
                {
                    //copy a[i] to temp
                    temp[k] = a[j];
                    j++;
                    k++;
                }
            }//end of while
            //one of the subarrays on i part or j part might have some left items
            //move the left items to the temp
            while (i <= mid)
            {
                //copy a[i] to temp
                temp[k] = a[i];
                i++;
                k++;
            }
            //or move the right items to temp
            //copy a[i] to temp
            while (j <= last)
            {
                temp[k] = a[j];
                j++;
                k++;
            }
            //copy temp back into the array a (or subsection of the entire array) starting at first
            //initialize an index for the array to start at first
            int s = first;
            for (int index = 0; index < temp.Length; index++)
            {
                a[s] = temp[index];
                s++;
            }
        }
        private static void DisplayLinkedList(LinkedList<int> linkedList)
        {
            Console.WriteLine("Displaying LinkedList data:");
            LinkedListNode<int> temp = linkedList.First;
            while (temp != null)
            {
                Console.WriteLine(temp.Value);
                temp = temp.Next;
            }
        }
    }
}
