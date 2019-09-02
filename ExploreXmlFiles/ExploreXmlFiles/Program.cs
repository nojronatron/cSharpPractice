using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace ExploreXmlFiles
{
    class Program
    {   // seed words for initializing the DB and table(s)
        static string[] csharpLingo = {
                "method", "inheritance", "class", "object", "instance", "property", "field", "constructor",
                "dot net", "array", "main", "curly brace", "string", "boolean", "semicolon", "parse",
                "try catch", "partial", "return", "call", "override", "keyword", "get or set", "static",
                "interface", "base", "virtual", "object", "abstract", "tryparse", "encapsulation", "ADO.NET",
                "Entity Framework"
            };
        static void Main(string[] args)
        {
            // check for existing XML file
            string defaultFilename = "lingoWords.xml";
            DirectoryInfo dirInfo = new DirectoryInfo(".");
            FileInfo[] fileList = dirInfo.GetFiles(defaultFilename);
            if (fileList.Count() != 1)
            {
                if (GenerateDefaultXmlFile(defaultFilename))
                {
                    Console.WriteLine($"Created XML file {defaultFilename}.");
                }
            }
            else
            {
                // import an existing XML file
                List<LingoWords> lingoList = GetXmlFileData(defaultFilename);

                // create context class to inherit DbContext


                // Create context class to inherit DbContext
                // Run Initializer / Seed Method() and query the DB
                // Store the Entities to the DB
                // Before closing app: Re - gen XML file with any new/ updated data

            }

            Console.WriteLine("\n\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }

        private static bool GenerateDefaultXmlFile(string defaultFilename)
        {
            // run routine to initialize XML file with the built-in string[]
            try
            {
                XDocument xDocInitXmlFile = new XDocument()
                {
                    Declaration = new XDeclaration("1.0", "utf-8", "yes")
                };
                xDocInitXmlFile.Add(new XComment("Init LingoWords.xml with cSharp lingo"));
                XElement elWords = new XElement("Words");
                xDocInitXmlFile.Add(elWords);
                foreach (string item in csharpLingo)
                {
                    XElement xeItem = new XElement("Item");
                    elWords.Add(xeItem);
                    xeItem.Add(new XElement("Word", item.ToString()));
                    xeItem.Add(new XElement("Category", "C Sharp Lingo"));
                }
                xDocInitXmlFile.Save(defaultFilename);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\n***** {ex.Message} *****");
                return false;
            }
        }
        private static List<LingoWords> GetXmlFileData(string filename)
        {
            // source.xml is in <project>\bin\debug
            XDocument xDoc = XDocument.Load(filename);
            IEnumerable<XElement> itemsXml = xDoc.Descendants("Item");
            List<LingoWords> lingoList = new List<LingoWords>(itemsXml.Count());

            // Console.WriteLine($"***** Print List of Elements in {filename} *****");
            LingoWords item = null;
            foreach (XElement xItem in itemsXml)
            {
                item = new LingoWords()
                {
                    Category = xItem.Element("Category").Value,
                    Word = xItem.Element("Word").Value
                };
                lingoList.Add(item);
                //Console.WriteLine($"Added word {word.Word} to List<LingoList> lingoList.");
            }
            return lingoList;
        }
    }
    public class LingoWords
    {
        // object representing database table
        public LingoWords() { }
        public LingoWords(string word, string category)
        {
            Word = word;
            Category = category;
        }
        public string Word { get; set; }
        public string Category { get; set; }
    }
}
