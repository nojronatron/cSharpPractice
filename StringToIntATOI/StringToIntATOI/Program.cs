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
            const int LISTSIZE = 18;
            List<string> exampleInputs = new List<string>(LISTSIZE);
            exampleInputs.Add("    -42");
            exampleInputs.Add(" +0 123");
            exampleInputs.Add("1");
            exampleInputs.Add("20000000000000000000");
            exampleInputs.Add("0");
            exampleInputs.Add("    ");
            exampleInputs.Add("   abc-777 xyz  ");
            exampleInputs.Add("42");
            exampleInputs.Add("4193 with words");
            exampleInputs.Add("words and 987");
            exampleInputs.Add("-91283472332");
            exampleInputs.Add("         -1");
            exampleInputs.Add("  one  ");
            exampleInputs.Add("+1");
            exampleInputs.Add("+-1");
            exampleInputs.Add("-+2");
            exampleInputs.Add("-");
            exampleInputs.Add("+");

            List<int> exampleOutputs = new List<int>(LISTSIZE);
            exampleOutputs.Add(-42);
            exampleOutputs.Add(0);
            exampleOutputs.Add(1);
            exampleOutputs.Add(2147483647);    // aka INT_MAX
            exampleOutputs.Add(0);
            exampleOutputs.Add(0);
            exampleOutputs.Add(0);
            exampleOutputs.Add(42);
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
                string test1 = DiscardLeadingWhitespace(s);
                string test2 = GetDigitsFollowingPolaritySign(s, "-");
                string test3 = DiscardTrailingAlphaCharacters(s);
                int result = DoATOI(s);
                //sw.Stop();
                Console.WriteLine($"-->> Input: {s,20}  Expected: {exampleOutputs[n],11}" +
                    $"  Actual: {result,11}");//  Ticks: {sw.ElapsedTicks}");
                //sw.Reset();
            }

            Console.Write("\n\nPress <Enter> to Exit. . .");
            Console.ReadLine();
        }


        static string DiscardLeadingWhitespace(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            { // discard leading whitespace chars
                if (!char.IsWhiteSpace(s[i]))
                { // retain non-whitespace chars
                    sb.Append(s[i]);
                }
                else
                {
                    break;
                }
            }
            return sb.ToString();
        }
        static string GetDigitsFollowingPolaritySign(string s, string polaritySign)
        {
            int polaritySignIndex = s.IndexOf(polaritySign);
            StringBuilder sb = new StringBuilder();
            if (polaritySignIndex > -1)
            { // s contains a polarity sign
                if (char.IsDigit(s[polaritySignIndex + 1]))
                { // polarity sign is followed by at least one digit
                    if (polaritySign == "-")
                    {
                        sb.Append("-");
                    }
                    for (int i = polaritySignIndex + 1; i < s.Length; i++)
                    { // cycle through string to find remaining digits
                        if (char.IsDigit(s[i]))
                        { // add next digit to the stringbuilder
                            sb.Append(s[i]);
                        }
                        else
                        { // stop adding to stringbuilder when digits no longer found
                            break;
                        }
                    }
                }
            }
            return sb.ToString();
        }
        static string DiscardTrailingAlphaCharacters(string s)
        {
            int index = 0;
            StringBuilder sb = new StringBuilder(s);
            if (s[index].Equals("-"))
            {
                index = 1;
            }
            for (int i = index; i < s.Length; i++)
            { // discard trailing alpha-characters
                if (char.IsLetter(sb[i]))
                {
                    sb.Remove(i, sb.Length - i);
                }
            }
            return sb.ToString();
            sb.Append()
        }


        static int DoATOI(string arg)
        {
            int result = 0; // will contain return value
            int intSign = 1; // assume positive integer and -1 is negative integer
            StringBuilder sb = new StringBuilder();
            try
            {
                if (arg.Length < 1)
                { // if empty string return 0
                    return 0;
                }
                if (arg.Length == 1)
                {
                    if (char.IsDigit(arg, 0))
                    { // the only character is a digit so return it
                        return int.Parse(arg);
                    }
                }
                arg = DiscardLeadingWhitespace(arg);
                // arg = sb.ToString();
                // sb.Clear();

                arg = DiscardTrailingAlphaCharacters(arg);


                if (sb.Length < 1)
                { // input was all whitespace
                    return 0;
                }
                arg = sb.ToString(); // re-sync sb to arg
                sb.Clear();

                int negativeSign = arg.IndexOf("-");
                int positiveSign = arg.IndexOf("+");
                StringBuilder sbPos = new StringBuilder();
                StringBuilder sbNeg = new StringBuilder();

                if (negativeSign > -1)
                { // arg contains a negative sign
                    if (char.IsDigit(arg[negativeSign + 1]))
                    { // negative sign is followed by at least one digit
                      // sbNeg.Append("-");
                        for (int i = negativeSign + 1; i < arg.Length; i++)
                        { // cycle through string to find remaining digits
                            if (char.IsDigit(arg[i]))
                            { // add next digit to the stringbuilder
                                sbNeg.Append(arg[i]);
                            }
                            else
                            { // set intSign to negative and stop adding to stringbuilder
                                intSign = -1;
                                break;
                            }
                        }
                    }
                    if (sbNeg.Length > sbPos.Length)
                    {
                        sb = sbNeg;
                    }
                }
                else if (positiveSign > -1)
                { // arg contains a positive sign
                    if (char.IsDigit(arg[positiveSign + 1]))
                    { // positive sign is followed by at least one digit
                        for (int i = positiveSign + 1; i < arg.Length; i++)
                        { // cycle through string to find remaining digits
                            if (char.IsDigit(arg[i]))
                            { // add next digit to the stringbuilder
                                sbPos.Append(arg[i]);
                            }
                            else
                            { // set intSign to positive and stop adding to stringbuilder
                                intSign = 1;
                                break;
                            }
                        }
                    }
                    if(sbPos.Length > sbNeg.Length)
                    {
                        sb = sbPos;
                    }
                }
                if (sb.Length > 0)
                {
                    result = int.Parse(sb.ToString());
                }
                else
                {
                    result = int.Parse(arg);
                }
            }
            catch (OverflowException)
            {
                if (intSign == -1)
                {
                    result = int.MinValue;
                }
                else
                {
                    result = int.MaxValue;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                result = 0;
            }
            catch (FormatException fe)
            {
                Console.WriteLine($">>DEBUG>> Arg: {arg} sb: {sb}\n\n{fe}");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An uncaught exception occurred. Arg: {arg} sb: {sb}\n\n{ex}");
                Console.ReadLine();
            }
            return result;
        }
    }
}
