using System;
using System.Diagnostics;   // required for StopWatch
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithmTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            // create an array to do the timing
            Console.WriteLine("***** Selection Sort Timer *****");
            Console.Write("Enter number of elements: ");
            int n;
            string mySortType = "";
            int.TryParse(Console.ReadLine(), out n);
            int[] array1 = new int[n];
            Initialize(array1); // if we want 10_000 entries, we won't want to do it by hand.
            // start timer
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            // sort the aray
            // mySortType = "Selection Sort";
            // SelectionSort(array1);
            mySortType = "Insertion Sort";
            InsertionSort(array1);
            // stop timer
            sw1.Stop();
            // display elapsed time
            Console.WriteLine($"\n{mySortType} Sort elapsed time: {sw1.Elapsed}"); // output format: HHMMSSmm

            Console.WriteLine("\n\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }

        static void Initialize(int[] array)
        {
            Random rand = new Random();
            for(int i=0;i<array.Length; i++)
            {
                array[i] = rand.Next();
            }
        }

        // Insertion Sort
        static void InsertionSort(int[] array)
        {
            int n = array.Length;
            for (int i = 1; i < n; i++)
            {
                // insert value at i to the left
                int temp = array[i];
                int j = i - 1;
                while (j >= 0 && temp < array[j])
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = temp;
            }
        }

        static void SelectionSort(int[] array)
        {
            int n = array.Length;                                                                                           // 1
                                                                                                                            // outside loop that moves the needle down the array starting at 0
            for (int j = 0; j < n - 1; j++)    // stop ONE BEFORE the last item because there is no comparison to do below it  // 1, n, n
            {                               // i always points to top so swap min with i
                                            // locate the minValue by Index (minIndex()) and swap it with the value at i
                int minIndex = j;           // must initialize the index WHEREVER THE STARTING POINT IS                     // n
                for (int i = j + 1; i < array.Length; i++)                                                                    // n + n^n + n^n
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
    }
}
