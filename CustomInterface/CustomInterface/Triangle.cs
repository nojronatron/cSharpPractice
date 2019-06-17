using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;

namespace CustomInterface
{
    class Triangle : Shape, IPointy
    {
        public Triangle() { }
        public Triangle(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine($"Drawing {PetName} the Triangle.");
        }
        public byte Points
        {
            // IPointy implementation
            get { return 3; }
        }
        public byte GetNumberOfPoints()
        {
            // all Members and Properties of an Interface MUST be implemented
            return Points;
        }
    }
}
