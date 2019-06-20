using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_with_interfaces
{
    public interface IShape
    {   // The keyword Interface defines this as a Pure Abstract Class
        // Interface can NOT have Fields
        // Interface can NOT have CTORs
        // Interfaces build functionality that every child MUST have
        double Perimeter();
        double Area();
        double Volume();
    }
}
