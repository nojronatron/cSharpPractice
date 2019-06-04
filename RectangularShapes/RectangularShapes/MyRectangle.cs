using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangularShapes
{
    class MyRectangle
    {
        // Fields
        private double _length;
        private double _width;
        //Constructors
        public MyRectangle() { }
        public MyRectangle(double length, double width)
        {
            _length = length;
            _width = width;
        }
        // Properties
        public double Length
        {
            get { return _length; }
        }
        public double Width
        {
            get { return _width; }
        }
        // Methods
        public virtual double Perimeter()
        {
            return Length * 2 + Width * 2;
        }
        public virtual double Area()
        {
            return Length * Width;
        }
        public override string ToString()
        {
            return $"\nObject: {GetType()}\n" +
                $"Length: {Length}\n" +
                $"Width: {Width}\n" +
                $"Perimeter: {Perimeter()}\n" +
                $"Area: {Area()}\n";
        }
    }
}
