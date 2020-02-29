using System;
using System.Collections.Generic;

namespace EgyptianFractions
{
    public static class MyEgyptianFractions
    {
        public static double GreedyAlgo(double a, double b)
        {
            // takes the numerator and denominator of a fraction and converts it to a potential Egyptian Fraction, as a double
            double ba = b / a;
            double c = Math.Ceiling(ba);
            return c;
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

        public static MyFraction FractionIdentities(MyFraction fraction)
        {
            double a = fraction.Numerator;      //double.Parse(fraction.Numerator.ToString());
            double b = fraction.Denominator;   //decimal.Parse(fraction.Denominator.ToString());
            MyFraction identity;
            identity = new MyFraction(1, (b * (a * b + 1)));
            return identity;
        }

        public static List<MyFraction> IdentitiesDriver(MyFraction fraction)
        {
            List<MyFraction> fractionsList = new List<MyFraction>();    //  start the tracking list using 1 / n where n is existing denominator
            if (fraction.Numerator == 1)
            {
                fractionsList.Add(fraction);
                //return fractionsList;
            }
            MyFraction temp = new MyFraction(1, fraction.Denominator);
            fractionsList.Add(temp);                                    //  store the 1/n fraction to the list
            decimal sumTotal = fraction.DecimalEquivalent();            //  use sumTotal to discover remaining work to be done?
            sumTotal -= temp.DecimalEquivalent();                       //  decrement 1/n from sumTotal
            while (sumTotal > 0)
            {
                MyFraction differenceRemaining = fraction.Difference(temp);
                temp = FractionIdentities(differenceRemaining);
                fractionsList.Add(temp);
                sumTotal -= temp.DecimalEquivalent();                   // remove 1/n from the total
            }
            return fractionsList;   //  no more work to do since fraction is 1/n already
        }

        public static long IdentityDriver(long a)
        {
            //  long a represents the denominator
            return a;
        }

        public static MyFraction FractionSplitter(MyFraction fraction, out MyFraction outFraction)
        {
            // use Natural Numbers to split fraction into two sub-fractions a, and b
            int[] natNums =new int[] { 100, 60, 24, 20, 12, 8, 6 };
            int a = 0;
            int b = 0;
            foreach (int item in natNums) //NaturalNumbers)
            {
                // pick the highest NaturalNumber that is less than numerator and subtract from numerator creating n1 and n2
                if (MyEgyptianFractions.CompareThese((int)fraction.Numerator, item) == 1)
                {
                    a = (int)fraction.Numerator - item;
                    b = item;
                    MyFraction fraction1 = new MyFraction(a, (int)fraction.Denominator);
                    outFraction = new MyFraction(b, (int)fraction.Denominator);
                    return fraction1;
                }
            }
            outFraction = new MyFraction(0, 0);   // returns a detectible done message as a 0 value fraction
            return fraction;                    // return the orginal fraction because it is the smallest it can be
        }
        public static int CompareThese(int numerator, int integer)
        {
            // Returns the difference of numerator to integer, zero if same, throws exception if NaN or other invalid input was received
            if (numerator > integer)
            {
                return 1;
            }
            if (integer > numerator)
            {
                return -1;
            }
            if (numerator == integer)
            {
                return 0;
            }
            throw new ArgumentOutOfRangeException($"An input was invalid (numerator: {numerator} or integer: {integer}.");
        }
    }
}
