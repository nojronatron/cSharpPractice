using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_with_interfaces
{
    abstract class RectangularShape : IShape
    {
        private double _length;
        private double _width;
        private double _height;
        public RectangularShape(double length, double width, double height)
        {
            _length = length;
            _width = width;
            _height = height;
        }
        public double Length { get { return _length; } }
        public double Width { get { return _width; } }
        public double Height { get { return _height; } }
        public virtual double Perimeter()
        {   // virtual: inheritors might override this
            return Length * 2 + Width * 2;
        }
        public abstract double Area();
        public abstract double Volume();
        public override string ToString()
        {
            return $"Length: {Length:N2}\nWidth: {Width:N2}\nHeight: {Height:N2}";
        }
    }
}
