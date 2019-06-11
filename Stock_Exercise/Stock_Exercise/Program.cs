using System;

namespace Stock_Exercise
{
    class Program
    {
        static string[] Companies = { "MSFT", "HP", "Compaq", "IBM", "Apple",
                                      "Citrix", "LogMeIn", "ViewSonic", "Samsung", "Amazon",
                                      "NetFlix", "Activision Blizzard"};
        static Stock[] Stocks = new Stock[12];
        static void Main(string[] args)
        {
            CreateArrayOfStocks();
            DisplayStocks();

            Console.WriteLine(GetStock("MSFT"));

            Console.Write("Press <Enter> Key to exit. . .");
            Console.ReadLine();
        }
        static Stock GetStock(string name)
        {
            // retreive a particular company's stock
            foreach(Stock s in Stocks)
            {
                if (s.CompanyName == name)
                {
                    return s;
                }
            }
            return null;
        }
        static void CreateArrayOfStocks()
        {
            Random rand = new Random();
            for(int i=0; i<Stocks.Length; i++)
            {
                int index = rand.Next(0, Companies.Length);
                string name = Companies[index];
                int numShares = rand.Next(0, 100);
                double price = rand.Next(0, 1000);
                Stock stock = new Stock(name, numShares, price);
                Stocks[i] = stock;
            }
        }
        static void DisplayStocks()
        {
            Console.WriteLine($"***** Your portfolio of stocks *****");
            foreach(Stock s in Stocks)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }
    }
}
