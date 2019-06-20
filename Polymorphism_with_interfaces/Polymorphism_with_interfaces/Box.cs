using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_with_interfaces
{
    class Box : RectangularShape
    {   // Every class you create MUST have a CTOR
        //     Now if that class inherits, then it should reference the base CTOR
        public Box(double length, double width, double height) : base(length, width, height) { }
        public override double Area()
        {
            return 2 * (Length * Width + Length * Height + Width * Height);
        }

        public override double Volume()
        {
            return Length * Width * Height;
        }
        public override string ToString()
        {
            return $"Length: {Length:N2}\nWidth: {Width:N2}\nHeight: {Height:N2}\nArea: {Area():N2}\nVolume: {Volume():N2}";
        }
    }
}
