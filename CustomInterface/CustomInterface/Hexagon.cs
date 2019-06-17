using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomInterface;

namespace Shapes
{
    class Hexagon:Shape, IPointy
    {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }
        public override void Draw()
        {
            // base.Draw();
            // Console.WriteLine("Drawing {0} the Hexagon", PetName);
            Console.WriteLine($"Drawing {PetName} the Hexagon (overriding abstract Shape.Draw() method).");
        }
        public byte Points
        {
            get { return 6; }
        }
        public byte GetNumberOfPoints()
        {
            // MUST be implemented
            return Points;
        }
    }
}
