using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Xml.Linq;

namespace PracticeEF6CodeFirstModel
{   // DropCreateDatabaseAlways
    // DropCreateDatabaseIfModelChanges
    public class LingoDbInitializer : DropCreateDatabaseIfModelChanges<LingoContext>
    { // initializer strategies: https://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx
        protected override void Seed(LingoContext context)
        {
            Console.WriteLine("***** Executing Initializer custom Seed() method. *****");
            List<LingoWord> lingoWords = GetDataFromXDocument();

            using (LingoContext db = new LingoContext())
            {
                // generate entities via the LingoWord class
                foreach (LingoWord wrd in lingoWords)
                {
                    db.LingoWords.Add(wrd);
                }
                int rowsSaved = db.SaveChanges();
                base.Seed(context);
                if (rowsSaved > 0)
                {
                    Console.WriteLine($"LingoWord Entities created. {rowsSaved} rows saved.");
                }
                else
                {
                    Console.WriteLine("LingoWord Entity creation failed. Press <Enter> to Continue. . .");
                    Console.ReadLine();
                }
            }
            Console.WriteLine("End of Initialization and Seed code.");
            Console.WriteLine("Review SQL Server database 'LingoDb', table 'LingoWords'.");
        }
        private List<LingoWord> GetDataFromXDocument()
        {
            // Load data from an XML file
            XDocument xWords = XDocument.Load("xWords.xml");

            // gather 'Item' elements from xDocument into an iterable collection
            IEnumerable<XElement> itemsXml = xWords.Descendants("Item");

            // Create a generic list of Words from XML elements in the iterable itemsXml
            List<LingoWord> listWord = new List<LingoWord>(itemsXml.Count());
            LingoWord item = null;
            foreach (XElement xItem in itemsXml)
            {
                item = new LingoWord()
                {
                    Category = xItem.Element("Category").Value,
                    Word = xItem.Element("Word").Value
                };
                listWord.Add(item);
            }
            return listWord;
        }
    }
}
