using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToObjects3
{
    class Box
    {
        //private fields
        private double length;
        private double width;
        private double height;
        private static double pricePerCubicFoot = 0.50; // 50 cents per cubic foot

        //constructor
        public Box(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        //properties a.k.a.: accessors allow access to private fields once the object is instantiated
        public double Length { get { return this.length; } }
        public double Width { get { return this.width; } }
        public double Height { get { return this.height; } }
        public static double PricePerCubicFoot { get { return pricePerCubicFoot; } }

        //methods
        public double GetVolume()
        {
            return length * width * height;
        }
        public static Box SumBoxes(Box box1, Box box2)
        {
            Box box = new Box(box1.Length + box2.Length, box1.Width + box2.Width, box1.Height + box2.Height);
            return box;
        }
    }
}
