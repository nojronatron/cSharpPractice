using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_with_interfaces
{
    class Rectangle_JR : RectangularShape
    {
        public Rectangle_JR(double length, double width): base(length, width, 0)
        { }
        public override double Area()
        {
            return Length * Width;
        }

        public override double Volume()
        {
            return 0;
        }
        public override string ToString()
        {
            return $"Length: {Length:N2}\nWidth: {Width:N2}\nArea: {Area():N2}";
        }

    }
}
