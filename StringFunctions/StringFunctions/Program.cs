using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = "A string is an array of characters. It has a property Length, and defines multiple methods.";
            int numCharacters = inputString.Length;
            for (int i = 0; i < numCharacters; i++)
            {
                Console.Write($" {inputString[i]}");
            }
            Console.WriteLine();

            // count the number of vowels in inputString
            int vCounter = 0;
            foreach (char character in inputString)
            {
                //  this relies on an Enumerator, which String HAS!
                if (character.ToString().ToUpper() == "A" || character.ToString() == "E" || character.ToString() == "I" || character.ToString() == "O" || character.ToString() == "U" || character.ToString() == "Y")
                {
                    vCounter++;
                }
            }
            Console.WriteLine($"\nFound {vCounter} vowels in inputString.");

            Console.WriteLine();
            usingIndexOf(inputString);
            Console.WriteLine();

            string s = "";
            //s.ToCharArray();
            char[] ss = s.ToCharArray();
            Console.WriteLine($"\ns is a {s.GetType().Name}\n");

            Console.WriteLine();
            Console.WriteLine("Press <Enter> to exit. . .");
            Console.ReadLine();
        }
        static void usingIndexOf(string s)
        {
            int index = s.IndexOf(' ');
            Console.WriteLine($"First occurrence of whatespace character found at index {index}.");
            int index2 = s.IndexOf(' ', index + 1);
            Console.WriteLine($"Second occurrence of whatespace character found at index {index2}.");

            int lIndex1 = s.LastIndexOf(' ');
            int lIndex2 = s.LastIndexOf(' ', lIndex1 - 1);
            Console.WriteLine($"Last occurrence of whitespace character found at index {lIndex1}.");
            Console.WriteLine($"Second-to-last occurrence of whitespace character found at index {lIndex2}.");
        }
        static bool testForVowel(char c)
        {
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'y' };
            for (int n = 0; n < vowels.Length; n++)
            {
                if (char.ToUpper(c) == char.ToUpper(vowels[n]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
