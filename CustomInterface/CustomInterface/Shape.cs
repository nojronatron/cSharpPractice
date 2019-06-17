using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    abstract class Shape
    {
        public Shape(string name = "NoName") { PetName = name; }
        public string PetName { get; set; }
        //public virtual void Draw() // virtual methods MUST be public
        //{
        //    Console.WriteLine("Inside Shape.Draw()");
        //}
        public abstract void Draw();
            // abstract method forces children to define Method functionality themselves
            // abstract methods can only be defined in abstract classes
            // abstract methods() define a name, return type (if any), and parameters set (if required)
            // public abstract void Draw() basically says: if you derive from me, YOU figure out the details
            // the abstract Draw() method MUST be implemented in Circle else Circle would have to be abstract too
    }
}
