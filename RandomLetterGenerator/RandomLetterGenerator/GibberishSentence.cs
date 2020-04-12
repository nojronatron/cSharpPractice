using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomLetterGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            //  purpose: generate a random string of valid alpha characters with spaces, periods, and commas
            //      for quickly generating text without the need for any information transfer.
            //List<char> VChars1 = new List<char>(16); //  32-47
            //for(int a=32; a <= 47; a++)
            //{
            //    VChars1.Add((char)a);
            //}
            //List<char> VChars2 = new List<char>(7); //  58-64
            //for(int b=58; b<=64; b++)
            //{
            //    VChars2.Add((char)b);
            //}
            //List<char> CapitalLetters = new List<char>(26); //  65-90
            //List<char> LowercaseLetters = new List<char>(26);   //  97-122
            //  punctuation capacity is 9
            Dictionary<string, char> punctuation = new Dictionary<string, char>(9);
            punctuation.Add("space", (char)32);
            punctuation.Add("exclaimation", (char)33);
            punctuation.Add("doblequote", (char)34);
            punctuation.Add("comma", (char)44);
            punctuation.Add("dash", (char)45);
            punctuation.Add("period", (char)46);
            punctuation.Add("colon", (char)58);
            punctuation.Add("semicolon", (char)59);
            punctuation.Add("query", (char)63);

            StringBuilder output = new StringBuilder();

            int numSentances = rand.Next(2, 6);
            //  generate a few sentances
            for (int i = 1; i <= numSentances; i++)
            {
                int sentanceLength = rand.Next(5, 15);
                if (i > 1)
                {
                    output.Append(punctuation["space"]);
                }
                //  build a sentance with a number of words
                for (int j = 1; j <= sentanceLength; j++)
                {
                    int wordLength = rand.Next(1, 13);
                    if (j > 1)
                    {
                        output.Append(punctuation["space"]);
                    }
                    //  build a word
                    for (int k = 1; k <= wordLength; k++)
                    {
                        char letter = (char)rand.Next(97, 123);
                        if (j == 1 && k == 1)
                        {
                            output.Append(letter.ToString().ToUpper());
                        }
                        else
                        {
                            output.Append(letter);
                        }
                    }
                }
                output.Append(punctuation["period"]);
            }


            Console.WriteLine("Generated sentence output:\n");
            Console.WriteLine(output.ToString());


            Console.WriteLine("\n\n");
            Console.ReadLine();
        }
    }
}
