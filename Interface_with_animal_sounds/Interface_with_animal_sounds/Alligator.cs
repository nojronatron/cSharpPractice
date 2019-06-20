using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_with_animal_sounds
{
    class Alligator : IAnimal
    {
        // fields
        private string _soundFilename;
        //CTOR
        public Alligator(string filename)
        {
            _soundFilename = filename;
        }
        // property from IAnimal
        public string Habitat { get { return "Warm Water"; } } // hard-coded property
        // Method from IAnimal
        public void Sound()
        {
            SoundPlayer s = new SoundPlayer(_soundFilename);
            s.Play();
        }
    }
}
