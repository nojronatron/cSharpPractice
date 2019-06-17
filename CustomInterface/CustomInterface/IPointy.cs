using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    interface IPointy
    {
        // an interface, by definition, is PUBLIC and ABSTRACT
        // an interface cannot define a base Class despite it inheriting from System.Object
        // an interface CAN specify base INTERFACES
        // an interface does NOT have:
        //     CTORs
        //     Fields
        // an interface only have non-implemented Members and read/read-write properties
        byte GetNumberOfPoints();
        // interfaces are pure protocol, never defining an implementatin (that is up to the supporting class or structure)
        byte Points { get; }
        // Interface types can also contain event and indexer definitions


    }
}
