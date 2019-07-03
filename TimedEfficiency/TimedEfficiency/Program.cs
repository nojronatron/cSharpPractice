using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimedEfficiency
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test SelectionSort
            int[] array1 = {10, 2, 8, 6, 3, 9, 28, 11, 19};
            Console.WriteLine("array before sorting: ");
            Display(array1);
            // sort the array
            //SelectionSort(array1);
            //Console.WriteLine("\narray after sorting: ");
            //Display(array1);

            // TODO: insertionSort, does it work?
            SelectionSort(array1);
            Console.WriteLine("\narray after Insertion Sort: ");
            Display(array1);

            // TODO: time it (in the other project)


            Console.ReadLine(); // pause
        }
        // write a method that takes an array and returns the index of the smallest value
        static int GetIndexOfSmallestValue(int[] array)
        {                                           // Time Efficiency numbers
            int minIndex = 0;                       // 1
            for(int i = 1; i < array.Length; i++)   // 1 + n + n
            {
                if (array[i] < array[minIndex])     // n
                {
                    minIndex = i;                   // n
                }
            }
            return minIndex;                        // 1
        }                      // Time Efficiency T(n) 4n + 3 => Linear growth, so: For n^(infinity) O(n)
        
        // selection sort algorithm
        // use the GetIndexOfSmallestValue() method and run it over-and-over again until the array is sorted
        // using a swapping method
        static void SelectionSort(int[] array)
        {
            int n = array.Length;                                                                                           // 1
            // outside loop that moves the needle down the array starting at 0
            for(int j=0; j < n - 1; j++)    // stop ONE BEFORE the last item because there is no comparison to do below it  // 1, n, n
            {                               // i always points to top so swap min with i
                                            // locate the minValue by Index (minIndex()) and swap it with the value at i
                int minIndex = j;           // must initialize the index WHEREVER THE STARTING POINT IS                     // n
                for (int i = j+1; i < array.Length; i++)                                                                    // n + n^n + n^n
                {
                    if (array[i] < array[minIndex])                                                                         // n^n
                    {
                        minIndex = i;                                                                                       // n^n
                    }
                }
                // swap value minIndex with value at i (the top of the index)
                // create a 3rd "cup" to use as a placeholder
                int temp = array[j];        // save value at j                                                              // n
                array[j] = array[minIndex]; // overwrite value at j with value at i                                         // n
                array[minIndex] = temp;     // overwrite value at minIndex and overwrite it with value that WAS at j        // n
            }                                                                                                               // 4n^2 + 7n + 2
        }                                                           // T(n) non-linear (quadratic) growth: For n^(infi) =>T(4n^2) => O(n2)

        // Insertion Sort
        static void InsertionSort(int[] array){
            int n = array.Length;
            for(int i=1; i<n; i++)
            {
                // insert value at i to the left
                int temp = array[i];
                int j = i - 1;
                while(j>=0 && temp<array[j])
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = temp;
            }
        }

        // helper method to display an array
        static void Display(int[] array)
        {
            Console.WriteLine();
            foreach (int i in array)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }
}
