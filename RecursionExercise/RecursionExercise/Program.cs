using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int left = 10;
            int right = 30;
            Console.SetCursorPosition(left, 5);
            Console.WriteLine("*");
            Console.SetCursorPosition(right, 5);
            Console.WriteLine("*");
            drawMiddleStar(left, right);

            Console.SetCursorPosition(0, 15);
            // test binary recursive search
            int[] array = { 6, 9, 14, 17, 19, 25, 29, 34, 40, 55 };
            int key = 40;
            int index = BinarySearch(array, key, 0, array.Length - 1);
            Console.WriteLine($"\n\nThe index of the key {key} is: {index}");

            // test binary recursive search with key NOT in array; expect -1
            key = 41;
            index = BinarySearch(array, key, 0, array.Length - 1);
            Console.WriteLine($"\n\nThe index of the key {key} is: {index}");

            Console.SetCursorPosition(0, 22);
            Console.Write("Press <Enter> to exit. . .");
            Console.ReadLine();
        }
        // create a method that draws a star in the middle of an interval
        static void drawMiddleStar(int left, int right)
        {
            // base condition
            if (right - left < 3)
            {
                return;
            }

            // process/action: find middle point between left and right
            int middle = (left + right) / 2;
            Console.SetCursorPosition(middle, 5);
            Console.Write("*");

            // slow down the process so it can be seen on screen
            System.Threading.Thread.Sleep(500); // sleep for 1 sec

            // recursive calls
            drawMiddleStar(left, middle);
            drawMiddleStar(middle+1, right);
        }
        // recursive binary search
        static int BinarySearch(int[] array, int key, int first, int last)
        {   // param key is used to id the item we are searching for
            // 1) check for "good" params e.g.: last > first

            // 2) base case: if first and last cross, stop
            if (first > last)
            {
                return -1;  // could not find key
            }

            // 3) compute mid point
            int mid = (first + last) / 2;
            if (key == array[mid])
            {
                return mid;
            }
            else if (key > array[mid])
            {  // search the right-half
                return BinarySearch(array, key, mid + 1, last);
            }
            else
            {  // search the left-half
                return BinarySearch(array, key, first, mid - 1);
            }
        }
    }
}
