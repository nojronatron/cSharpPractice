using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given a 32-bit signed integer, reverse digits of an integer.
            //Example 1:
            //Input: 123
            //Output: 321

            //Example 2:
            //Input: -123
            //Output: -321

            //Example 3:
            //Input: 120
            //Output: 21
            //Note:
            //Assume we are dealing with an environment which could only store integers within the 32 bit signed integer range:
            //[−231, 231 − 1].For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.

            List<int> exampleInputs = new List<int>(3);
            exampleInputs.Add(123);
            exampleInputs.Add(-123);
            exampleInputs.Add(120);
            exampleInputs.Add(-2_147_483_648);
            List<int> expectedOutputs = new List<int>(3);
            expectedOutputs.Add(321);
            expectedOutputs.Add(-321);
            expectedOutputs.Add(21);
            expectedOutputs.Add(0);


            Console.WriteLine("***** Fun With Reverse Int'neering *****");
            for (int i=0;i<exampleInputs.Count;i++)
            {
                int result = Reverse(exampleInputs[i]);
                Console.WriteLine($"Input: {exampleInputs[i]}\tExpected: {expectedOutputs[i]}\tActual: {result}");
            }


            Console.Write("Press <Enter> to Exit. . .");
            Console.ReadLine();
        }
        static int Reverse(int x)
        {
            string result="";
            string myStr;
            int intResult;
            try
            {
                myStr = Math.Abs(x).ToString();
                if (x < 0)
                {
                    result += "-";
                }
                for (int y = myStr.Length - 1; y >= 0; y--)
                {
                    result += $"{myStr.Substring(y, 1)}";
                }
                intResult = int.Parse(result);
            }
            catch (OverflowException)
            {
                intResult = 0;
            }
            return intResult;
        }
    }
}
