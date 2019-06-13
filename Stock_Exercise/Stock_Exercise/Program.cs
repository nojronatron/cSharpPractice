using System;

namespace Stock_Exercise
{
    class Program
    {
        static string[] Companies = { "MSFT", "HP", "Compaq", "IBM", "Apple",
                                      "Citrix", "LogMeIn", "ViewSonic", "Samsung", "Amazon",
                                      "NetFlix", "Activision Blizzard"};
        static Stock[] Stocks = new Stock[6]; // Anonymous Objects in an Array of type Stock
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                DisplayMenu();
                int selection;
                int.TryParse(Console.ReadLine(), out selection);
                Console.WriteLine();
                switch(selection)
                {
                    case 0: // create Array of stocks
                        {
                            CreateArrayOfStocks();
                            DisplayStocks();
                        }
                        break;
                    case 1: // buy stocks
                        {
                            Console.Write("\nEnter the company name of the stock you want to buy: ");
                            string co = Console.ReadLine();
                            Console.Write($"\nEnter the number of {co} stocks you want to buy: ");
                            int.TryParse(Console.ReadLine(), out int num);
                            Stock stck = GetStock(co); // find the stock and use an object to utilize its members
                            if (stck != null)
                            {
                                stck.BuyShares(num);
                                Console.Write($"\nSuccessfully purchased {num} shares of {co} stock!");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.Write($"\nUnable to purchase {num} shares of {co} stock.");
                            }
                        }
                        break;
                    case 2: // sell stocks
                        {
                            Console.Write("\nEnter the company name of the stock you want to sell: ");
                            string co = Console.ReadLine();
                            Console.Write($"\nEnter the number of {co} stocks you want to sell: ");
                            int.TryParse(Console.ReadLine(), out int num);
                            Stock stck = GetStock(co); // find the stock and use an object to utilize its members
                            if (stck != null)
                            {
                                if (stck.SellShares(num))
                                {
                                    Console.Write($"\nSuccessfully sold {num} shares of {co} stock!");
                                }
                                else
                                {
                                    Console.Write($"\nUnable to sell {num} shares of {co} stock.");
                                }
                            }
                        }
                        break;
                    case 4: // search for specific stock
                        {
                            Console.WriteLine("\nEnter the compoany name of the stock you want to find: ");
                            string co = Console.ReadLine();
                            Console.WriteLine($"\nSearching for {co} stock... ");
                            Console.WriteLine(GetStock(co));
                        }
                        break;
                    case 5: // display all stocks
                        {
                            DisplayStocks();
                        }
                        break;
                    case 9: // exit
                        {
                            return;
                        }
                }
                Console.WriteLine();
                Console.Write("Press <Enter> Key to Continue. . .");
                Console.ReadLine();
            }
        }
        static void DisplayMenu()
        {
            Console.WriteLine("\t***** Menu *****\n");
            Console.WriteLine("\t0) Create Stock Portfolio");
            Console.WriteLine("\t1) Buy Stock");
            Console.WriteLine("\t2) Sell Stock");
            Console.WriteLine("\t4) Display Specific Stock");
            Console.WriteLine("\t5) Display All Stocks");
            Console.WriteLine("\t9) Exit Program\n");
            Console.WriteLine("\t****************\n");
            Console.Write("\tMake A Selection: ");
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
        //static void CreateArrayOfStocks()
        //{
        //    Random rand = new Random();
        //    for(int i=0; i<Stocks.Length; i++)
        //    {
        //        int index = rand.Next(0, Companies.Length);
        //        string name = Companies[index];
        //        int numShares = rand.Next(0, 100);
        //        double price = rand.Next(0, 1000);
        //        Stock stock = new Stock(name, numShares, price);
        //        Stocks[i] = stock;
        //    }
        //}
        static void CreateArrayOfStocks() // figure out how to do UNIQUE random selection
        {
            int numCompanies = Companies.Length;
            Double[] order = new Double[numCompanies];
            Random rand = new Random();
            for(int i=0; i<Companies.Length; i++)
            {
                order[i] = rand.NextDouble();
            }
            for(int j=0; j<Stocks.Length; j++)
            {

            }
            Array.Sort(order, Array[]);
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
