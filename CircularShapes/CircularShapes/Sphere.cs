using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularShapes
{
    internal class Sphere : Circle
    {
        // Fields
        // CTORs
        // A child CTOR ALLWAYS calls its Base Default CTOR (first thing)
        // CTOR Chain will be broken UNTIL a Default CTOR is manually added to the Base Class
        // CTORs are NOT Inherited, so this Child Class MUST have a CTOR created for it
        public Sphere(double radius) : base(radius)
        {
            // even though no Field has been defined the Sphere *has* a radius Field via Inheritance
            // therefore its CTOR *must* accept a Parameter to initialize the Field
            // Parent's private Field cannot be accessed, but with Protected keyword, child Classes can, w/o providing everyone access
            // ":base(radius)" causes the Parent Class Field to get initializead using the Child Class CTOR
        }
        // Properties
        // Methods
        public override double Area()
        {
            // Child Class OVERRIDE of Parent's Virtual Method()
            return 4*Math.PI*Math.Pow(Radius,2);
        }
        public override double Volume()
        {
            // auto-code: return base.Volume();
            // 4D and 3D force the Compiler to caste them of Type Double
            return (4D / 3D) * Math.PI * Math.Pow(Radius, 3);
        }
    }
}
