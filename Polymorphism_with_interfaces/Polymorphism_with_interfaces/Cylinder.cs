using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_with_interfaces
{
    class Cylinder : CircularShape
    {
        public Cylinder(double radius, double height) : base(radius, height) { }
        public override double Area()
        {
            return (2 * Math.PI * Radius * Height) + (2 * Math.PI * Math.Pow(Radius, 2));
        }

        public override double Volume()
        {
            return Math.PI * Math.Pow(Radius,2) * Height;
        }
        public override string ToString()
        {
            return $"Radius: {Radius:N2}\nHeight: {Height:N2}\nArea: {Area():N2}\nVolume: {Volume():N2}";
        }
    }
}
