using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort_InClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With Partitioning *****");
            int size = 30;
            // int[] arr = { 20, 15, 35, 6, 27, 10, 39, 18, 19, 8 };
            // int[] arr = { 20, 35, 8, 12, 50, 30, 15, 18, 39, 31, 7, 17 };
            int[] arr = { };

            Random rand = new Random();
            for(int i=0; i<=size; i++)
            {
                // TODO: Fix this to fill the array with integers between 0 and size
                int next_number = rand.Next(0, size);
                arr.Append(next_number);
            }

            Console.Write($"Starting array:");
            DisplayArray(arr);

            // test the partition method
            int pivotindex = partition(arr, 0, arr.Length - 1);
            Console.WriteLine("\nArray after the first partition. . .");
            DisplayArray(arr);
            int First = 0;
            int Last = arr.Length - 1;
            QuickSort(arr, First, Last);
            Console.WriteLine("\n\narr after Quicksort. . .");
            DisplayArray(arr);
            

            Console.Write("\n\nPress <Enter> Key to Quit. . .");
            Console.ReadLine();
        }
        // helper method to display an array
        static void DisplayArray(int[] array)
        {
            foreach (int item in array)
            {
                Console.WriteLine($"{item} ");
            }
        }
        // recursive method 'quicksort' to fire-off the actual work in method Partition()
        static void QuickSort(int[] array, int First, int Last)
        {
            //  obvious base-case
            if (First >= Last)
            {
                return; // if First and Last cross each other, we are done, return
            }
            int pivotIndex = partition(array, First, Last);
            // now repeat the partitioning to the left part and the right part
            QuickSort(array, First, pivotIndex - 1);    // left-side sub-array
            QuickSort(array, pivotIndex + 1, Last);     // right-side sub-array
        }
        static int partition(int[] array, int First, int Last)  // not always index(0) and index(Count)
        {
            int Up = First;//set up an index to move left to right
            int Down = Last;//set up an index to move right to left

            if (First < Last)   // if equal then already sorted (1 element) or if gt then invalid input
            {
                int pivot = array[First]; //pick the first element as the pivot
                while (Up < Down)
                {
                    //move the Up index (pointer) to the next element that is greater than the pivot
                    while (array[Up] <= pivot && Up < Last)
                        Up++;

                    //move the Down index to the next element that is less than the pivot
                    while (array[Down] > pivot && Down > First)
                        Down--;

                    if (Up < Down)  // if the Up Index is less than Down Index then crossover has occurred
                        swap(array, Up, Down);
                }
                //at this point Up and Down have crossed each other
                //swap the pivot element (at index First) with the element at index Down
                swap(array, First, Down);
                //Now the Down index points to the pivot element. 
                //Note that all the elements to the left of pivot are less than or equal to pivot
                //and all the elements to the right of pivot are greater than pivot

                //return the new pivot index
                return Down;
            }
            return First;
        }
        static void swap(int[] array, int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
