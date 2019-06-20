using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_with_animal_sounds
{
    class Program
    {
        static void Main(string[] args)
        {
            string basefilepath = "C:\\Users\\Blue\\Desktop\\Bellevue College Classes\\C Sharp Prog 2 Spring 2019\\Animal_Sounds\\";
            string alifile = $"{basefilepath}alligator3.wav";
            string coyfile = $"{basefilepath}coyote01.wav";
            string pupfile = $"{basefilepath}dog.wav";
            //Console.WriteLine(alifile);
            //Console.WriteLine(coyfile);
            //Console.ReadLine();

            Alligator Ali = new Alligator(alifile);
            Coyote Corina = new Coyote(coyfile);
            Puppy Doug = new Puppy(pupfile);

            Ali.Sound();
            Console.WriteLine($"Alligator habitat: {Ali.Habitat}");
            Console.ReadLine();
            Corina.Sound();
            Console.WriteLine($"Coyote habitat: {Corina.Habitat}");
            Console.ReadLine();
            Doug.Sound();
            Console.WriteLine($"Puppy habitat: {Doug.Habitat}");

            Console.WriteLine();
            Console.Write($"Press <Enter> to exit. . .");
            Console.ReadLine();
        }
    }
}
