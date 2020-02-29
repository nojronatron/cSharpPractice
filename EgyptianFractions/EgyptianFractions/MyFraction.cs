using System;

namespace EgyptianFractions
{
    public class MyFraction
    {
        // ctors
        public MyFraction(double numerator, double denominator)
        {
            Numerator = Math.Abs(numerator);
            Denominator = Math.Abs(denominator);
        }

        public MyFraction(double number)
        {
            number = Math.Abs(number);
            if (number < 0)
            {
                Numerator = 0;
                Denominator = 0;
            }
            else if (number == 0)
            {
                Numerator = 0;
                Denominator = 1;
            }
            else if (number == 1)
            {
                Numerator = 1;
                Denominator = 1;
            }
            else
            {
                //  Euclidean
                int numberLen = number.ToString().Length; 
                double tempNumerator = number * Math.Pow(10, numberLen);
                double tempDenominator = 1 * Math.Pow(10, numberLen);
                long a = long.Parse(tempNumerator.ToString());
                long b = long.Parse(tempDenominator.ToString());
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
                if (gcd == 0)
                {
                    Numerator = 0;
                    Denominator = 1;
                }
                else
                {
                    Numerator = tempNumerator / gcd;
                    Denominator = tempDenominator / gcd;
                }
            }
        }

        public MyFraction()
        {
            Numerator = 1;
            Denominator = 1;
        }

        // properties
        public double Numerator { get; private set; }
        public double Denominator { get; private set; }
        private bool IsImproperFraction
        {
            get
            {
                if (Numerator > Denominator)
                {
                    return true;
                }
                return false;
            }
        }

        private double WholeNumber
        {
            get
            {
                return Math.Truncate(Numerator / Denominator);
            }
        }

        // methods
        public decimal DecimalEquivalent()
        {
            decimal deciNumerator = decimal.Parse(Numerator.ToString());
            decimal deciDenominator = decimal.Parse(Denominator.ToString());
            return deciNumerator / deciDenominator;
        }
        public bool IsImproper()
        {
            if (this.IsImproperFraction)
            {
                return true;
            }
            return false;
        }

        public string GetImproperFraction()
        {
            if (this.IsImproperFraction)
            {
                int reduced_numerator = Math.DivRem(Convert.ToInt32(Numerator), Convert.ToInt32(Denominator), out reduced_numerator);
                return $"{ WholeNumber } { reduced_numerator }/{ Denominator }";
            }
            return this.ToString();
        }

        public MyFraction Difference(MyFraction other)
        {
            // take two fractions e.g 2/3 and 4/5 and find the difference
            // Difference( 10/15, 12/15) => 2/15
            double productDenominator = this.Denominator * other.Denominator;
            double newFirstNumerator = this.Numerator * other.Denominator;
            double newSecondNumerator = other.Numerator * this.Denominator;
            double differenceNumerator;
            if (this.Numerator > other.Numerator)
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
            return new MyFraction(differenceNumerator, productDenominator);
        }

        // overrides
        public override string ToString()
        {
            return $"{ this.Numerator }/{ this.Denominator }";
        }
    }
}
