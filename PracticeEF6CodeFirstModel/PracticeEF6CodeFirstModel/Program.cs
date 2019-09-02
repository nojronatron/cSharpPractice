using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;

namespace PracticeEF6CodeFirstModel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call Initialize routine - see LingoContext.cs and LingoDbInitializer.cs

            try
            {
                // query the database
                using (LingoContext dbContext = new LingoContext())
                {
                    List<LingoWord> lingoWords = (from lw in dbContext.LingoWords
                                                  select lw).ToList();
                    if (dbContext.LingoWords.Count() > 0)
                    {
                        Console.WriteLine($"Linq query results count: {dbContext.LingoWords.Count()}");
                        // display contents of the query results
                        Console.WriteLine("Linq query results:");
                        foreach (LingoWord word in lingoWords)
                        {
                            Console.WriteLine($"\t{word.Category}\t{word.Word}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Linq results returned. Initializer probably didn't run.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.Write("\n\nPress <Enter> Key to Exit. . .");
            Console.ReadLine();
        }
    }
}
