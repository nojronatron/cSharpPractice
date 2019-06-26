using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparable_IComparer_Interfaces
{
    public class Box : IComparable<Box>
    {
        //private fields
        private double length;
        private double width;
        private double height;
        private static double pricePerCubicFeet = 0.50; //50 cents a cubic feet

        //constructor
        public Box(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        //properties : get accessors
        public double Length { get { return this.length; } }
        public double Width { get { return this.width; } }
        public double Height { get { return this.height; } }
        //property the static field
        public static double PricePerCubicFeet { get { return pricePerCubicFeet; } }

        //methods
        public double Volume()
        {
            //return length + width + height;
            return length * width * height;
        }
        public double Area()
        {
            // return 2 * (Length + Width * Height);
            return (2 * (Length * Width)) + (2 * (Width * Height)) + (2 * (Height * Length));
        }
        public override string ToString()
        {
            return $"{length,-10}{width,-10}{height,-10}{Area().ToString("f"),-15}{Volume().ToString("f")}";
        }
        public int CompareTo(Box other)
        {
            // CompareTo box = this
            // Box other = other
            // Sort by VOLUME
            if (this.Volume() > other.Volume())
            {
                return 1;
            }
            if (this.Volume() < other.Volume())
            {
                return -1;
            }
            return 0; // *is* equal if neither gt nor lt :)
        }
        // using IComparer<T> interface and implementing Compare(T x, T y) requires passing-in parameters
        //    of type IComparer<T>, so using a Nested Class simplifies this effort
        public class BoxWidthComparer : IComparer<Box>
        {
            // There is no limit on the number of Nested Classes that can be programmed 
            // Make this public because this class needs to be called directly to utilize it
            // As a nested Class, it will always come-along with Box.cs
            public int Compare(Box box1, Box box2)
            {
                if (box1.Width > box2.Width)
                {
                    return 1;
                }
                if (box1.Width < box2.Width)
                {
                    return -1;
                }
                return 0;
                // that is ALL this nested class needs to do; provide a way to compare, so Sort() can do its job
            }
        }
    }
}
