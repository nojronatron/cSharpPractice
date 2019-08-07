using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap_Sort_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] array1 = { 5, 10, 8, 20, 15 };
            //int[] array1 = { 40, 20, 15, 10, 18, 6, 8, 7, 5 };
            int[] array1 = { 15, 8, 10, 6, 20, 25, 19, 30, 35, 17, 27};
            Console.WriteLine("***** Fun with Max-Heap *****");
            Console.Write("Starting array: ");
            Display(array1);

            Console.Write("Array after MaxHeap: ");
            BuildMaxHeap(array1);
            Display(array1);

            // apply HeapSort()
            Console.Write("Array after HeapSort: ");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            HeapSort(array1);
            sw.Stop();
            Display(array1);
            Console.WriteLine($"\nElapsed Ticks: {sw.Elapsed}");

            Console.Write("Press <Enter> to Exit. . .");
            Console.ReadLine();
        }
        static void Display(int[] arr)
        {
            foreach(int item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        // heap sort
        static void HeapSort(int[] array)
        {
            BuildMaxHeap(array);    // call MaxHeap to get the result before doing search
            int heapsize = array.Length - 1;    //last index
            for(int i = heapsize; i >= 0; i--)
            {
                //swap the root with the last element in the heap
                int temp = array[0];
                array[0] = array[heapsize];
                array[heapsize] = temp;
                // decrement the heapsize
                heapsize--;
                // heapify again up to heapsize
                Heapify(array, 0, heapsize);
            }
        }
        // define a method to build a Max-Heap
        static void BuildMaxHeap(int[] array)
        {
            // will have a for loop
            // pass-in the array and it will build the MaxHeap
            int n = array.Length;
            for(int i = n/2 - 1; i>=0; i--)
            {
                // calls the Method to do the Swaps (Heapify) to satisfy the MaxHeap properties
                // Heapify method ensures that a parent node is greater than its largest child node
                Heapify(array, i, n-1); // last index in the array is n-1
            }
        }
        static void Heapify(int[] array, int i, int heapsize)
        {
            // i=index of parent node
            // heapsize is the number of nodes considered
            // 1st: compute left and right indices
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            int largest;    // will hold the index largest child node
            // if left child is greater than parent set largest to left child
            // heapsize IS the last element for consideration in the array
            if (l <= heapsize && array[l] > array[i])   // heapsize as lastIndex in array
            {
                largest = l;
            }
            else
            {
                largest = i;
            }
            // if the right child is greater than largest (between parent and left) set largest to right child
            if(r <= heapsize && array[r] > array[l])    // heapsize as lastIndex in array
            {
                largest = r;
            }
            if (largest != i)
            {
                // if node is not the largest than it must be swapped with largest
                int temp = array[i];
                array[i] = array[largest];
                array[largest ]= temp;
                // recursively move downwards to make sure this swap did not break the max heap rule
                Heapify(array, largest, heapsize);  // recursively tell Heapify to go "downward"
            }
        }
    }
}
