using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_with_animal_sounds
{
    public interface IAnimal
    {
        // an interface is a contract -- inheritors MUST OVERRIDE
        // properties
        string Habitat { get; }

        // methods
        void Sound();
    }
}
