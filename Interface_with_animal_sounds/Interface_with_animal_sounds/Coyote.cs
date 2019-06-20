using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_with_animal_sounds
{
    class Coyote : IAnimal
    {
        private string _soundFilename;
        public Coyote(string filename)
        {
            _soundFilename = filename;
        }
        public string Habitat { get { return "Backyards"; } }

        public void Sound()
        {
            SoundPlayer s = new SoundPlayer(_soundFilename);
            s.Play();
        }
    }
}
