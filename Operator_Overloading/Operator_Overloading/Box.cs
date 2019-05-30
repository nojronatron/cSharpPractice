using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator_Overloading
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }
        public double Length { get { return this.length; } }
        public double Width { get { return this.width; } }
        public double Height { get { return this.height; } }
        public double GetVolume()
        {
            double volume = length * width * height;
            return volume;
        }
        // TODO: Provide a way to add two boxes together and return a result (e.g.:a new box)
        // There are three ways to do this: Instance Method; Static Method; Operator Overload?

        // instance method
        public Box Add(Box other)
        {
            // even though this method take a single parameter, Box 'other' is added to this box (this.Box is implied)
            // In MAIN you would write e.g.: Box box3 = box1.Add(box2);
            double length = this.length + other.length;
            double width = this.width + other.width;
            double height = this.height + other.height;
            Box box = new Box(length, width, height);
            return box;
        }

        // static method
        public static Box SAdd(Box box1, Box box2)
        {
            // the implied 'this' no longer exists
            double length = box1.length + box2.length;
            double width = box1.width + box2.width;
            double height = box1.height + box2.height;
            Box box = new Box(length, width, height);
            return box;
        }
        // operator + overload approach
        // ALWAYS PUBLIC and STATIC with a RETURN VALUE then the actual operator sign with arguments
        public static Box operator + (Box box1, Box box2)
        {
            // replaces a Method() with the operator sign
            double length = box1.length + box2.length;
            double width = box1.width + box2.width;
            double height = box1.height + box2.height;
            Box box = new Box(length, width, height);
            return box;
        }
        public static Box operator - (Box box1, Box box2)
        {
            double length = box1.length - box2.length;
            double width = box1.width - box2.width;
            double height = box1.height - box2.height;
            Box box = new Box(length, width, height);
            return box;
        }
        public static bool operator > (Box box1, Box box2)
        {
            if (box1.GetVolume() > box2.GetVolume()) { return true; }
            return false;
        }
        public static bool operator < (Box box1, Box box2)
        {
            if (box1.GetVolume() < box2.GetVolume()) { return true; }
            return false;
        }
    }
}
