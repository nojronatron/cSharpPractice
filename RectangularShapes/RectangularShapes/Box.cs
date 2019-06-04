using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangularShapes
{
    class Box:MyRectangle
    {
        // a Box is a rectangle with a 3rd dimension of DEPTH
        // Fields
        private double _height;
        // CTORS
        public Box() { }
        public Box(double length, double width, double height):base(length, width)
        {  // chained CTOR
            // use the existing parameters in the base:Class while defining this.Class Field w/ base:Class Fields included
            _height = height;
        }
        // Properties
        public double Height
        {
            get { return _height; }
        }
        // Methods
        public override double Area()
        {
            // a cube
            if (Length == Width) { return 6 * Math.Pow(Length, 2); }
            // a box
            else return 2 * ((Length * Width) + (Width * Height) + (Height * Length));
        }
        public virtual double Volume()
        {
            return Length * Width * Height;
        }
        public override string ToString()
        {
            return $"\nObject: {GetType()}\n" +
                $"Length: {Length}\n" +
                $"Width: {Width}\n" +
                $"Height: {Height}\n" +
                $"Perimeter: {Perimeter()}\n" +
                $"Area: {Area()}\n" +
                $"Volume: {Volume()}\n";
        }
    }
}
