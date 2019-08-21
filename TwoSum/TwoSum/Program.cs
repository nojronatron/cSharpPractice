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
            //int[] set = new int[6] { 0, 2, 4, 6, 8, 9 };
            int[] set = new int[5] { 0, 1, 2, 3, 0 };
            int target = 6;
            Console.WriteLine($"Target sum: {target}");
            Console.Write("Starting array: ");
            PrintValues(set);

            result = TwoSum(set, target);
            Console.Write("\nSelected Indices: ");
            PrintValues(result);

            Console.Write("\nPress <Enter> to Exit. . .");
            Console.ReadLine();
        }
        static int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2] { 0, 0 };
            for (int x = nums.Length - 1; x >= 0; x--)
            {
                for (int y = nums.Length - 1; y >= 0; y--)
                {
                    if (x != y && target - nums[x] == nums[y])
                    {
                        result[0] = x;
                        result[1] = y;
                    }
                }
            }
            if (result[0] == result[1] && result[1] == 0)
            {
                return new int[2] { -1, -1 };
            }
            else
            {
                return result;
            }
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
