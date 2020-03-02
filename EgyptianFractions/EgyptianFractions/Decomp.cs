using System;
using System.Collections.Generic;
using System.Text;

namespace EgyptianFractions
{
    public class Decomp
    {
        /* 
        Given a rational number n
        n >= 0, with denominator strictly positive
        as a string (example: "2/3" in Ruby, Python, Clojure, JS, CS, Go) or as two strings (example: "2" "3" in Haskell, Java, CSharp, C++, Swift)
        or as a rational or decimal number (example: 3/4, 0.67 in R)
        decompose this number as a sum of rationals with numerators equal to one and without repetitions (2/3 = 1/2 + 1/6 is correct but not 
            2/3 = 1/3 + 1/3, 1/3 is repeated).
        The algorithm must be "greedy", so at each stage the new rational obtained in the decomposition must have a denominator as small as possible. 
        In this manner the sum of a few fractions in the decomposition gives a rather good approximation of the rational to decompose.
        2/3 = 1/3 + 1/3 doesn't fit because of the repetition but also because the first 1/3 has a denominator bigger than the one in 1/2 in the 
        decomposition 2/3 = 1/2 + 1/6.

        Example:
        decompose("21/23") or "21" "23" or 21/23 should return 
        ["1/2", "1/3", "1/13", "1/359", "1/644046"]
    
        Notes
        1) The decomposition of 21/23 as
        21/23 = 1/2 + 1/3 + 1/13 + 1/598 + 1/897
        is exact but don't fulfill our requirement because 598 is bigger than 359. Same for
        21/23 = 1/2 + 1/3 + 1/23 + 1/46 + 1/69 (23 is bigger than 13)
        or 
        21/23 = 1/2 + 1/3 + 1/15 + 1/110 + 1/253 (15 is bigger than 13).
        2) The rational given to decompose could be greater than one or equal to one, in which case the first "fraction" will be an integer 
            (with an implicit denominator of 1).
        3) If the numerator parses to zero the function "decompose" returns [] (or "".
        4) The number could also be a decimal which can be expressed as a rational.

        examples:
        0.6 in Ruby, Python, Clojure,JS, CS, Julia, Go
        "66" "100" in Haskell, Java, CSharp, C++, C, Swift, Scala, Kotlin
        0.67 in R.

        Ref: http://en.wikipedia.org/wiki/Egyptian_fraction
        */

        public static string Decompose(string nrStr, string drStr)
        {
            if (nrStr != string.Empty && drStr != string.Empty && nrStr != "0")
            {
                StringBuilder results = new StringBuilder();
                if (double.TryParse(nrStr, out double numerator))
                {
                    if (double.TryParse(drStr, out double denominator))
                    {
                        //  fraction IS a whole number
                        if (numerator == denominator)
                        {
                            return $"[1]";
                        }
                        //  more calculations necessary at this point
                        results.Append("[");
                        Queue<double> denominators = new Queue<double>();

                        //  reduce the remaining fraction
                        double gcd = GetGCD(numerator, denominator);
                        numerator = numerator / gcd;
                        denominator = denominator / gcd;

                        //  mixed fraction
                        if (numerator > denominator)
                        {
                            double wholeNumber = Math.Truncate(numerator / denominator);
                            //  append the whole number to the results (implied n/1)
                            results.Append($"{ wholeNumber.ToString() }");
                            //  subtract the whole number from the mixed fraction
                            numerator -= (denominator * wholeNumber);
                            if (numerator == 0)
                            {
                                results.Append($"]");
                                return results.ToString();
                            }
                            else
                            {
                                results.Append($", ");
                            };
                        }
                        //  just append 1/n remaining simplified fraction to results and finish
                        if (numerator == 1 && denominator > 1)
                        {
                            results.Append($"{ numerator.ToString() }/{ denominator.ToString() }]");
                            return results.ToString();  //  try to break out completely here
                        }
                        //  use GreedyAlgo to find next 1/m fraction(s)
                        else if (numerator > 1 && denominator > 1)
                        {
                            GreedyAlgo(numerator, denominator, denominators);
                        }

                        while (denominators.Count > 0)
                        {
                            double thisDenominator = denominators.Dequeue();
                            string toAppend = string.Empty;
                            results.Append($"1/{ thisDenominator }");
                            if (denominators.Count != 0)
                            {
                                results.Append(", ");
                            }
                        }
                        results.Append("]");
                    }
                }
                return results.ToString();
            }
            return "[]";
        }
        
        public static double GetGCD(double numer, double denomin)
        {
            //  Euclidean method to find GCD
            long a = long.Parse(numer.ToString());
            long b = long.Parse(denomin.ToString());
            double gcd = 0;
            // Pull out remainders.
            while (true)
            {
                long remainder = a % b;
                if (remainder == 0)
                {
                    gcd = b;
                    break;
                }
                a = b;
                b = remainder;
            }
            return gcd;
        }

        public static Queue<double> GreedyAlgo(double x, double y, Queue<double> ExpandedDenominators)
        {
            double expandedDenominator = Math.Floor(y / x) + 1;
            ExpandedDenominators.Enqueue(expandedDenominator);
            double remainderNumerator = Difference(x, y, 1, expandedDenominator, out double remainderDenominator);
            if (remainderNumerator > 1)
            {
                GreedyAlgo(remainderNumerator, remainderDenominator, ExpandedDenominators);
            }
            if (remainderNumerator == 1)
            {
                ExpandedDenominators.Enqueue(remainderDenominator);
            }
            return ExpandedDenominators;
        }

        public static double Difference(double x, double y, double x2, double y2, out double denominator)
        {
            double productDenominator = y * y2;
            double newFirstNumerator = x * y2;
            double newSecondNumerator = x2 * y;
            double differenceNumerator;
            if (x > x2)
            {
                differenceNumerator = newFirstNumerator - newSecondNumerator;
            }
            else
            {
                differenceNumerator = newSecondNumerator - newFirstNumerator;
            }
            if (productDenominator % differenceNumerator == 0)
            {
                productDenominator /= differenceNumerator;
                differenceNumerator = 1;
            }
            denominator = productDenominator;
            return differenceNumerator;
        }
    }
}
