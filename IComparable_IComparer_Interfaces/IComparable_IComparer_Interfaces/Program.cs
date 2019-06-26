using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparable_IComparer_Interfaces
{
    class Program
    {
        /*
        List collection defines a Sort() method that takes no parameters and a Sort(IComparer<T>) method that takes a parameter
        of type IComparer<T>.
        Goal: create 2 Lists, one of integers (primitave data type), and a List of Boxes (of type Box)
         */
        static List<int> numberList = new List<int>();
        static List<Box> boxList = new List<Box>();
        static List<Account> accountList = new List<Account>();

        static Random rand = new Random();
        static void Main(string[] args)
        {
            Preload();
            //display before sorting
            Console.WriteLine("\nDisplaying the numberList collection. . .");
            Display(numberList);
            Console.ReadLine();
            numberList.Sort(); // sorting happens without any additional information (doubles, string, int, etc)
            Console.WriteLine();
            Display(numberList);

            // sorting the boxList is a little different
            Console.WriteLine("\nDisplaying boxList before sorting.");
            Display(boxList);
            Console.ReadLine();

            // we need to figure out how to sort boxList by Volume
            boxList.Sort(); // this is actually NOT going to work without implementing a sort method in code
            Console.WriteLine("\nDisplaying boxList after sorting by Volume.");
            Display(boxList);

            // sort by Width using Sort(IComparer<T>comparer) method
            // This method take san object of type IComparer<T>
            // That means this method takes an object of a class that implements the IComparer<T> interface
            // So you need to define a class, implement the IComparer<T> interface, then add code to
            //    Compare(T x, T y) method
            // Where do we define class? Anywhere, but the best place is within the Box class
            //    so that it is part of it
            // In C# a class can be defined inside another class (nested classes)
            Console.WriteLine("\nDisplaying boxList after sorting with ICompare<T>, using Width.");
            Box.BoxWidthComparer comparer = new Box.BoxWidthComparer(); // create a new instance just like with any other Class
            boxList.Sort(comparer); // use the version that take <T>Comparer as an argument!
            Display(boxList);
            Console.ReadLine();

            // Now do the same with Accounts
            Console.WriteLine("\nDisplaying accountList before sorting.");
            Display(accountList);
            Console.ReadLine();
            Console.WriteLine("\nDisplaying accountList after sorting by Balance.");
            accountList.Sort(); // will sort by Balance
            Display(accountList);
            Console.ReadLine();
            Console.WriteLine("\nDisplaying accountList sorted by Account Number using ICompare<T> interface.");
            Account.AccountComparer accComparer = new Account.AccountComparer();
            accountList.Sort(accComparer);
            Display(accountList);
            Console.ReadLine();


            Console.Write("\n\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
        static void Preload()
        {
            //preload both list with random numbers and random boxes
            for (int i = 1; i < 25; i++)
            {
                int n = rand.Next(10, 200);
                double length = rand.Next(12, 50);
                double width = rand.Next(8, (int)length);
                double height = rand.Next(12, 70);
                Box box = new Box(length, width, height);

                int accountNumber = rand.Next(111111, 999999);
                decimal balance = rand.Next(1000, 90000);
                Account account = new Account(accountNumber, balance);

                numberList.Add(n);
                boxList.Add(box);
                accountList.Add(account);
            }
        }
        // display: a generic method that can display a list of any type
        // that's only possible if the item overrid the ToString() method
        static void Display<T>(List<T> list)
        {
            //Console.WriteLine($"{list[0].GetType().Name}");
            if (list[0].GetType().Name == "Box")
            {
                Console.WriteLine("Length\tWidth\tHeight\tArea\tVolume");
            }
            if (list[0].GetType().Name == "Account")
            {
                Console.WriteLine("Account\tBalance");
            }
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
