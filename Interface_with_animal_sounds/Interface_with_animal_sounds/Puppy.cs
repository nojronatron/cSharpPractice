using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_with_animal_sounds
{
    class Puppy : IAnimal
    {
        public string _soundFilename;
        public Puppy(string filename)
        {
            _soundFilename = filename;
        }
        public string Habitat { get { return "Livingroom"; } }

        public void Sound()
        {
            SoundPlayer s = new SoundPlayer(_soundFilename);
            s.Play();
        }
    }
}
