using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace ImportPlainTextFileToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            // goals
            // 1) read-in a plain-text file that is named with a single-word identifying a category
            //    and containing a long single-list of words separated by carriage returns (\n)
            // 2) process the file to generate an XML document <root,Schema=,Comment=><Item><Category=><Word=>
            // 3) store the XML doc in a file at same path as plain-text file (from user input)
            // 4) maintain an object instance of the XML doc for use by other apps/callers

            // get filename and path
            Console.WriteLine("Enter the path and filename to the plain-text file: ");
            string fullFileName = Console.ReadLine();
            // e.g.: C:\Users\Blue\source\repos\nojronatron\cSharpPractice\ImportPlainTextFileToXML\cSharpLingo.txt

            try
            {   // catch Exceptions to avoid having to test for lots of things
                FileInfo fi = new FileInfo(fullFileName);
                string srcDir = fi.DirectoryName;
                string srcFileName = fi.Name;
                string srcFileExt = fi.Extension;
                if (fi.Exists)
                {
                    // get Category
                    string category = fi.Name.ToString();
                    category = category.Replace(".txt", "");    // remove extention
                    int lingoStart = category.ToLower().IndexOf("lingo"); // get index of word lingo
                    category = category.Remove(lingoStart, 5);  // remove word lingo from string
                    Console.WriteLine($"Category will be named {category}");

                    // read-in file
                    LingoWord lw = null;
                    string s = "";
                    List<LingoWord> lingoWordList = new List<LingoWord>();
                    using (StreamReader sr = fi.OpenText())
                    {
                        while ((s = sr.ReadLine()) != null)
                        {
                            lw = new LingoWord
                            {
                                Category = category,
                                Word = s
                            };
                            lingoWordList.Add(lw);
                        }
                    }
                    // generate Xml Document

                    XDocument xDocInitXmlFile = new XDocument()
                    {
                        Declaration = new XDeclaration("1.0", "utf-8", "yes")
                    };
                    xDocInitXmlFile.Add(new XComment("Custom Lingo Words per user plain text input"));
                    XElement elWords = new XElement("Words");
                    xDocInitXmlFile.Add(elWords);
                    foreach (LingoWord item in lingoWordList)
                    {
                        XElement xeItem = new XElement("Item");
                        elWords.Add(xeItem);
                        xeItem.Add(new XElement("Word", item.Word));
                        xeItem.Add(new XElement("Category", category));
                    }

                    // test for existing file prior to overwriting ask for yay-nay
                    string saveAsDir = $"{srcDir}";
                    saveAsDir += @"\";
                    string saveAsFilename = $"{category}_LingoWords.xml";
                    string saveAsFullFilename = $"{saveAsDir}{saveAsFilename}";
                    FileInfo dstFi = new FileInfo(saveAsFullFilename);
                    if (dstFi.Exists)
                    {
                        Console.Write("File exists. Overwrite? (y/n) ");
                        if (Console.ReadLine().ToLower() == "n")
                        {
                            Console.WriteLine($"Unable to write to file due to conflict:\n{saveAsFullFilename}.");
                            return;
                        }
                    }
                    else
                    {
                        // store XDoc as <filename>.xml (will overwrite)
                        xDocInitXmlFile.Save(saveAsFullFilename);

                        Console.WriteLine($"\nXML file: {saveAsFullFilename}");

                        // generate a portable object that can be used by EF6 or other apps/classes/callers
                        // return List<LingoWord> lingoWordList
                    }
                }
            }
            catch (OutOfMemoryException oome)
            {
                Console.WriteLine("File read-in function ran out of memory. Choose a smaller file.");
                Console.WriteLine(oome.Message);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                Console.WriteLine($"Directory not found. {dnfe.Message}");
            }
            catch (IOException ioe)
            {
                Console.WriteLine("File read-in function could not read the file. Choose another file.");
                Console.WriteLine(ioe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something unexpected happened. {ex}");
            }

            Console.Write("Press <Enter> key to Exit. . .");
            Console.ReadLine();
        }
    }
}
