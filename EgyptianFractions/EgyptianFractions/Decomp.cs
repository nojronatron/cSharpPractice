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
            StringBuilder results = new StringBuilder();
            if (nrStr != string.Empty && drStr != string.Empty && nrStr != "0")
            {
                if (decimal.TryParse(nrStr, out decimal numerator))
                {
                    if (decimal.TryParse(drStr, out decimal denominator))
                    {
                        if (numerator > denominator)
                        {
                            decimal mixed = numerator / denominator;
                            return $"[{ mixed.ToString() }]";
                        }
                        Queue<decimal> denominators = new Queue<decimal>();
                        GreedyAlgo(numerator, denominator, denominators);
                        results.Append("[");
                        while(denominators.Count > 0)
                        {
                            decimal thisDenominator = denominators.Dequeue();
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
        public static Queue<decimal> GreedyAlgo(decimal x, decimal y, Queue<decimal> ExpandedDenominators)
        {
            decimal expandedDenominator = Math.Floor(y / x) + 1;
            ExpandedDenominators.Enqueue(expandedDenominator);
            decimal remainderNumerator = Difference(x, y, 1, expandedDenominator, out decimal remainderDenominator);
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

        public static decimal Difference(decimal x, decimal y, decimal x2, decimal y2, out decimal denominator)
        {
            decimal productDenominator = y * y2;
            decimal newFirstNumerator = x * y2;
            decimal newSecondNumerator = x2 * y;
            decimal differenceNumerator;
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
