using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_with_interfaces
{
    class Circle : CircularShape
    {
        public Circle(double radius):base(radius,0)
        {
        }
        public override double Area()
        {
            return Math.PI * (Math.Pow(Radius, 2));
        }
        public override double Volume()
        {
            return 0;
        }
        public override double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }
        public override string ToString()
        {
            return $"{base.ToString()}\nArea: {Area():N2}";
        }
    }
}
