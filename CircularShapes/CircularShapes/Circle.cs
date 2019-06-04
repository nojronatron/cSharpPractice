using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularShapes
{
    class Circle
    {
        // Fields
        private double _radius; // underscore _ makes the CTOR Parameter distinguishable from the Field
        // CTORs
        public Circle() { }
        public Circle(double radius) // parameter 'radius'
        {
            _radius = radius;
        }
        // Properties
        public double Radius
        {
            get { return _radius; }
        }
        // Methods
        public virtual double Perimeter()
        {
            // Parent: Virtual; Child: Override
            return 2 * Math.PI * _radius;
        }
        public virtual double Area()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }
        public virtual double Volume()
        {
            return 0; // no 3D space calculation for a 2D object
        }
        public override string ToString()
        {
            return $"{GetType(),-15} radius: {_radius,-10} perimeter: {Perimeter().ToString(),-15} area: {Area().ToString(),-15} volume: {Volume().ToString(),-15}";
        }
    }
}
