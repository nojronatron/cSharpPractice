using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace StringToIntATOI
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Implement atoi which converts a string to an integer.
                The function first discards as many whitespace characters as necessary until the first non-whitespace character is found. 
                Then, starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as 
                possible, and interprets them as a numerical value.
                The string can contain additional characters after those that form the integral number, which are ignored and have no effect 
                on the behavior of this function.
                If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such sequence exists 
                because either str is empty or it contains only whitespace characters, no conversion is performed.
                If no valid conversion could be performed, a zero value is returned.
                Note:
                Only the space character ' ' is considered as whitespace character.
                Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: 
                [−231,  231 − 1]. If the numerical value is out of the range of representable values, INT_MAX (231 − 1) or 
                INT_MIN (−231) is returned.

                Example 1:
                Input: "42"
                Output: 42

                Example 2:
                Input: "   -42"
                Output: -42
                Explanation: The first non-whitespace character is '-', which is the minus sign.
                             Then take as many numerical digits as possible, which gets 42.
                Example 3:
                Input: "4193 with words"
                Output: 4193
                Explanation: Conversion stops at digit '3' as the next character is not a numerical digit.

                Example 4:
                Input: "words and 987"
                Output: 0
                Explanation: The first non-whitespace character is 'w', which is not a numerical 
                             digit or a +/- sign. Therefore no valid conversion could be performed.
                Example 5:
                Input: "-91283472332"
                Output: -2147483648
                Explanation: The number "-91283472332" is out of the range of a 32-bit signed integer.
             Thefore INT_MIN (−231) is returned.
             */
            const int LISTSIZE = 15;
            List<string> exampleInputs = new List<string>(LISTSIZE);
            exampleInputs.Add("0");
            exampleInputs.Add("    ");
            exampleInputs.Add("   abc-777 xyz  ");
            exampleInputs.Add("42");
            exampleInputs.Add("    -42");
            exampleInputs.Add("4193 with words");
            exampleInputs.Add("words and 987");
            exampleInputs.Add("-91283472332");
            exampleInputs.Add("         -1");
            exampleInputs.Add("  one  ");
            exampleInputs.Add("+1");
            exampleInputs.Add("+-1");
            exampleInputs.Add("+-2");
            exampleInputs.Add("-");
            exampleInputs.Add("+");

            List<int> exampleOutputs = new List<int>(LISTSIZE);
            exampleOutputs.Add(0);
            exampleOutputs.Add(0);
            exampleOutputs.Add(0);
            exampleOutputs.Add(42);
            exampleOutputs.Add(-42);
            exampleOutputs.Add(4193);
            exampleOutputs.Add(0);
            exampleOutputs.Add(-2147483648);    // aka INT_MIN
            exampleOutputs.Add(-1);
            exampleOutputs.Add(0); // not processable so return default 0
            exampleOutputs.Add(1);
            exampleOutputs.Add(0); // non-int followed by another non-int so return 0
            exampleOutputs.Add(0); // non-int followed by another non-int so return 0
            exampleOutputs.Add(0);
            exampleOutputs.Add(0);

            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //Console.WriteLine("Awaiting timer...");
            //Thread.Sleep(5000);
            //sw.Stop();
            //sw.Reset();
            //Console.Clear();

            Console.WriteLine("***** Fun with ATOI *****");

            for (int n = 0; n < exampleInputs.Count; n++)
            {
                string s = exampleInputs[n];
                //Thread.Sleep(1000);
                //sw.Start();
                int result = doATOI(s);
                //sw.Stop();
                Console.WriteLine($"-->> Input: {s,16}  Expected: {exampleOutputs[n],11}" +
                    $"  Actual: {result,11}  Type: {(result.GetType().Name),6}"); //  Ticks: {sw.ElapsedTicks}");
                //sw.Reset();
            }

            Console.Write("\n\nPress <Enter> to Exit. . .");
            Console.ReadLine();
        }
        static int doATOI(string arg)
        {
            int result = 0;
            string strResult = "";
            try
            {
                arg = arg.Replace(" ", ""); // 1. discard whitespace characters to the 1st non-whitespace character
                if (arg.Length < 1)
                { // 4. if nothing is left after removing whitespace no conversion is performed so return 0
                    strResult = "0";
                }
                for (int index = 0; index < arg.Length; index++)
                {
                    if (arg.Substring(index, 1) == "-" && index+1 < arg.Length)
                    {
                        if (int.TryParse(arg.Substring(index + 1, 1), out int q))
                        {// 2. look for minus sign while recording digits
                            strResult += "-";
                            _ = q;  // but ignore if next character is non-int
                        }
                    }
                    else if (arg.Substring(index, 1) == "+" & index+1 < arg.Length)
                    {
                        if (int.TryParse(arg.Substring(index + 1, 1), out int p))
                        { // found a rogue plus sign in front of an integer ignore it and carry on
                            _ = p;
                        }
                        else
                        { // found a rogue plus sign in front of a non-integer so break out and return a result
                            strResult = "0";
                            break;
                        }
                    }
                    else if (int.TryParse(arg.Substring(index, 1), out int r))
                    {// 3. find only int32 type characters
                        strResult += $"{r}";   // default behavior is ToString()
                    }
                    else if (strResult.Length > 0)
                    {   // 3. trailing-edge non-numeric characters have been found break out of this to return the result
                        break;
                    }
                    else
                    {   // 4. first sequence of non-whitespace chars in str is not valid integral number
                        // 5. if no valid conversion could be performed a 0 is returned
                        strResult = "0";
                        break;
                    }
                }
                result = int.Parse(strResult);
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException was caught.");
                result = -1;
            }
            catch (OverflowException)
            {   // 6. change the result to INT_MIN or INT_MAX
                if (float.TryParse(arg, out float r))
                {
                    if (r < 0)
                    {
                        result = int.MinValue;
                    }
                    else
                    {
                        result = int.MaxValue;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something unexpected happened.\n{ex.Message}\n");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }
            return result;
        }
    }
}
