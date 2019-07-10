using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BinarySearchAlgorithm_alpha
{
    class Program
    {
        static void Main(string[] args)
        {
            const int SIZE = 100_000_000;
            const int VALUE = SIZE - 1;
            int[] array1 = new int[SIZE];
            int[] array2 = new int[SIZE];

            // initialize a SORTED array
            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = i; // guaranteed sorted and we will know last element value
            }

            // search worst case: Last element's value

            // Sequential Search
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            int index = Seq_Search(array1, VALUE);
            sw1.Stop();
            Console.WriteLine($"\nSequential search: found at index: {index}\t\tElapsed time: {sw1.Elapsed}");

            
            // Binary Search
            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            index = Bin_Search(array1, VALUE);
            sw2.Stop();
            Console.WriteLine($"\nBinary search: found at index: {index}\t\tElapsed time: {sw2.Elapsed}");

            Console.Read();
        }
        // binary search
        static int Bin_Search(int[] array, int value)
        {
            int first = 0;
            int last = array.Length;
            while (first <= last)  // should be <= because that space should be interrogated and cross-over should exit
            {
                int mid_point = (first + last) / 2;
                if (value == array[mid_point])
                {
                    return mid_point;
                }
                else if (value > array[mid_point])
                {
                    first = mid_point + 1;
                }
                else
                {
                    last = mid_point - 1;
                }
            }
            return -1;
        }

        // sequential search: return index of found value or -1 if not found
        static int Seq_Search(int[] array, int value) // array of integers, value being searched for
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                if (array[i] == value)
                {
                    return i;
                }
            }
            // couldn't find value in array
            return -1;

            // T(n) = 1 + n + n + n + 1 = 3n +1 = 3n
            // ...for very large values of n: T(n)=3n; O(n) :: Linear growth
        }
        // 	1) compute the mid-point using first and last index (len(array)-1) e.g.: (array[first_index] + array[last_index]) / 2
        //  2) mid MUST be an INT because it is an index
        //  3) if array(mid_index).value == search_value: done
        //      elseif search_value < array[last]: last_index = mid_index - 1
        //   this "shrinks" the array to the left-side of the array from mid
        //      else array[first] = mid_index + 1
        //  4) Loop back to 1 and perform 1 - 4 again so long as "WHILE" first has not crossed last
        //  5) first crossed last: Exit "not found"
    }
}
