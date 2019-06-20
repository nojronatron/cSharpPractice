using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_with_interfaces
{
    abstract class CircularShape : IShape
    {
        // Fields
        private double _radius; // underscore _ makes the CTOR Parameter distinguishable from the Field
        private double _height;
        // CTORs
        public CircularShape() { }
        public CircularShape(double radius, double height) // parameter 'radius'
        {
            _radius = radius;
            _height = height;
        }
        // Properties
        public double Radius
        {
            get { return _radius; }
        }
        public double Height { get { return _height; } }
        // Methods
        // MUST implement the methods in the Interface
        public virtual double Perimeter()
        {   // since we are expecting this class to have inheritors
            //     make it virtual so it can be overridden
            return 2 * Math.PI * _radius;
        }
        // implementation CANNOT be fulfilled for this class so method() must be abstract
        public abstract double Area();
        // implementation CANNOT be fulfilled for this class so method() must be abstract
        public abstract double Volume();
        public override string ToString()
        {
            return $"Radius: {Radius:N2}\nPerimeter: {Perimeter():N2}";
        }
    }
}
