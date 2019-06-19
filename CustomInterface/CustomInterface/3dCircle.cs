using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomInterface;

namespace Shapes
{
    class _3dCircle : Circle, IDraw3D
    {
        // the NEW keyword can be used on any member type inheritied from a base class
        //   e.g.: Field, Constant, Static Member, or Property
        public _3dCircle() { }
        public _3dCircle(string name) : base(name) { }
        // hide PetName in the Class above me using keyword 'new'
        public new string PetName { get; set; }

        // hide any Draw() implementation above me
        public new void Draw()
        {   // NEW keyword creates a Member Shadow - required to compile
            Console.WriteLine("Drawing a 3D Circle");
            // override would only be possible if the parent class had a virtual method() rather than abstract
            // E.G.: You are attempting to extend a purchased 3rd-part DotNET Assembly, 
            //     and so there is not direct edit access to the base class
        }
        public void Draw3D()
        {
            Console.WriteLine("\nDrawing 3DCircle in 3D!");
        }
    }
}
