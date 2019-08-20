using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given an array of integers, return indices of the two numbers such that they add up to a specific target.
            // You may assume that each input would have exactly one solution, and you may not use the same element twice.
            // Example:
            // Given nums = [2, 7, 11, 15], target = 9,
            // Because nums[0] + nums[1] = 2 + 7 = 9,
            // return [0, 1].
            int[] result;
            //int[] set = new int[4] { 2, 7, 11, 15 };
            int[] set = new int[6] { 0, 2, 4, 6, 8, 9 };
            //int[] set = new int[5] { 0, 1, 2, 3, 0 };
            int target = 9;
            Console.Write("Starting array: ");
            PrintValues(set);

            result = TwoSum(set, target);
            Console.Write("\nResulting indices: ");
            PrintValues(result);

            Console.Write("\nPress <Enter> to Exit. . .");
            Console.ReadLine();
        }
        static int[] TwoSum(int[] nums, int target)
        {
            // plan
            // 1. Remove all numbers that are greater than target
            // 2. Find an index with value equal to target and return it if exists
            // 3. Subtract an index value from target. If an index value is equal to the difference return both *index* ints

            int[] result = new int[2] {0,0};

            // use a List to store the valid index ints
            List<int> myList = new List<int>(nums.Length);
            foreach (int i in nums)
            {
                    // store a valid index int
                    myList.Add(i);
            }

            // do difference check to get two valid indices
            for (int x = myList.Count-1; x >= 0; x--)
            {
                for (int y = myList.Count-1; y >= 0 ; y--)
                {
                    if (x!=y && target - nums[x] == nums[y])
                    {
                        // return the two VALUES as an int[] (use the discovered indices to select them)
                        //return new int[2] { x, y };
                        result[0] = x;
                        result[1] = y;
                    }
                }
            }
            //throw new NotImplementedException();
            return result;
        }
        static void PrintValues(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write($"\t{i}");
            }
            Console.WriteLine();
        }
    }
}
