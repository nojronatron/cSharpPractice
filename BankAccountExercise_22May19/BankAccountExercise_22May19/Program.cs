using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountExercise_22May19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Accounts Exercise *****");

            // Gather initial balances from user input
            Console.Write("Enter beginning deposit for Account #1000-10000: ");
            long.TryParse(Console.ReadLine(), out long amt); // .TryParse declares the variable and emits a value via keyword OUT
            Account one = new Account(100000000, amt);
            Console.Write("Enter beginning deposit for Account #2000-20000: ");
            amt = long.Parse(Console.ReadLine()); // long.amt already exists so just overwrite the value
            Account two = new Account(200000000, amt);

            // Create a menu system UI
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("      *** Main Menu ***\n");
                    Console.WriteLine(" 1) Deposit to account ONE");
                    Console.WriteLine(" 2) Deposit to account TWO");
                    Console.WriteLine(" 3) Withdrawl from account ONE");
                    Console.WriteLine(" 4) Withdrawl from account TWO");
                    Console.WriteLine(" 5) Display Accounts");
                    Console.WriteLine(" 6) Transfer from account ONE to account TWO");
                    Console.WriteLine(" 7) Transfer from account TWO to account ONE");
                    Console.WriteLine(" 8) Exit Program\n");
                    Console.Write(" ===> Your selection ===> ");

                    int menuSelection = int.Parse(Console.ReadLine());
                    long amount = 0;

                    if (menuSelection == 1) // had to settle for if statements until I get the hang of the switch statement (type errors)
                    {
                        Console.WriteLine("Enter deposit amount to account ONE: ");
                        amount = long.Parse(Console.ReadLine());
                        one.Deposit(amount);
                    }
                    else if (menuSelection == 2)
                    {// Deposit to account
                        Console.WriteLine("Enter deposit amount to account TWO: ");
                        amount = long.Parse(Console.ReadLine());
                        two.Deposit(amount);
                    }
                    else if (menuSelection == 3)
                    {
                        // Withdrawl from account
                        Console.WriteLine("Enter amount to withdraw from account ONE: ");
                        amount = long.Parse(Console.ReadLine());
                        one.Withdrawl(amount);
                    }
                    else if (menuSelection == 4)
                    {
                        // Withdrawl from account
                        Console.WriteLine("Enter amount to withdraw from account TWO: ");
                        amount = long.Parse(Console.ReadLine());
                        two.Withdrawl(amount);
                    }
                    else if (menuSelection == 5)
                    {
                        // Display accounts
                        // one.DisplayStats();
                        // two.DisplayStats();
                        // Console.WriteLine($"Account ONE account number: {one.AccountNumber}; Balance: {one.Balance}");
                        // Console.WriteLine($"Account TWO account number: {two.AccountNumber}; Balance: {two.Balance}");
                        ShowAccountDetails();
                    }
                    else if (menuSelection == 6)
                    {
                        // transfer funds
                        Console.WriteLine("\nEnter the amount to transfer from account ONE to account TWO: ");
                        amount = long.Parse(Console.ReadLine());
                        Console.WriteLine("\nTransferring {0:C} from {1} to {2}...\n", amount, one.AccountNumber, two.AccountNumber);
                        TransferFunds(one, two, amount);
                        // one.DisplayStats();
                        // two.DisplayStats();
                        ShowAccountDetails();
                    }
                    else if (menuSelection == 7)
                    {
                        // transfer funds
                        Console.WriteLine("\nEnter the amount to transfer from account TWO to account ONE: ");
                        amount = long.Parse(Console.ReadLine());
                        Console.WriteLine("\nTransferring {0:C} from {1} to {2}...\n", amount, two.AccountNumber, one.AccountNumber);
                        TransferFunds(two, one, amount);
                        // one.DisplayStats();
                        // two.DisplayStats();
                        ShowAccountDetails();
                    }
                    else
                    {
                        // exit program
                        Console.WriteLine("Press Enter Key to Exit. . .");
                        _ = Console.Read();
                        return;
                    }
                    Console.Write("\n\nPress Enter To Continue. . .");
                    Console.Read();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error! Invalid input!");
                    Console.WriteLine($"{ex}");
                    // _ = Console.Read();
                }
                Console.WriteLine("\nPress Enter To Continue. . .");
                // _ = Console.Read();
            } // end WHILE loop
        }
        static void TransferFunds(Account acctFrom, Account acctTo, long Amount)
        {
            // transfer allowed only if acctFrom.balance is gt Amount
            if (acctFrom.Balance > Amount)
            {
                Console.WriteLine($"Error! Unable to withdrawl {Amount} from {acctFrom.AccountNumber} with balance of {acctFrom.Balance}.");
            }
            else
            {
                acctFrom.Withdrawl(Amount);
                acctTo.Deposit(Amount);
            }
        }
        static void ShowAccountDetails()
        {
            Console.WriteLine($"Account ONE account number: {one.AccountNumber}; Balance: {one.Balance}");
            Console.WriteLine($"Account TWO account number: {two.AccountNumber}; Balance: {two.Balance}");
        }
    }
}
