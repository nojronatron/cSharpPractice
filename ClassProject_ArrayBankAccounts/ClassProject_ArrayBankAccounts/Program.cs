using System;

namespace ClassProject_ArrayBankAccounts
{
    class Program
    {
        static string[] banks = { "Bank of Juan", "Carlos 1st Bank", "Union Bank of Reid", "Jimbo Banko", "NW Bank of Jonny",
                    "Alfred Credit Union", "Credit Union de Dianna", "Bank of Lily", "Peterbank", "James banq",
                    "1st Bank of Tina", "Taco Bank" };
        static Account[] accounts = new Account[12]; // ALLOCATE (but not create) these 'account' objects -- all NULL

        static void Main(string[] args)
        {
            // Account a1 = new Account(123456789, 10_000, "1st National Union Bank", "Juan");
            // Console.WriteLine($"{a1.ToString()}");
            CreateArrayOfAccounts();
            DisplayAccounts();

            while (true)
            {
                Console.Clear();
                Menu();
                int selection;
                Console.Write("\n\tEnter your selection: ");
                int.TryParse(Console.ReadLine(), out selection);
                Console.WriteLine();
                switch (selection)
                {
                    case 1: // Deposit into an account
                        {
                            Console.Write("Enter the account number: ");
                            int.TryParse(Console.ReadLine(), out int accNum);
                            Console.Write("\nEnter the amount to deposit: ");
                            double.TryParse(Console.ReadLine(), out double amt);
                            Account selectedAccount = GetAccount(accNum);
                            if (selectedAccount != null)
                            {
                                selectedAccount.Deposit(amt);
                            }
                            Console.WriteLine($"\n{selectedAccount}");
                            break;
                        }
                    case 2: // Withdrawl from an account
                        {
                            Console.Write("Enter the account number: ");
                            int.TryParse(Console.ReadLine(), out int accNum);
                            Console.Write("\nEnter the amount to withdrawl: ");
                            double.TryParse(Console.ReadLine(), out double amt);
                            Account selectedAccount = GetAccount(accNum);
                            if(selectedAccount != null)
                            {
                                if (selectedAccount.Withdrawl(amt))
                                {
                                    Console.WriteLine($"\nThe Withdrawl succeeded.");
                                };
                            }
                            Console.WriteLine($"\n{selectedAccount}");
                            break;
                        }
                    case 3: // Show account with highest balance
                        {
                            Console.Write("The account with the highest balance is: ");
                            Account selectedAccount = GetHighestBalanceAccount();
                            if (selectedAccount != null)
                            {
                                Console.WriteLine($"\n{selectedAccount}");
                            }
                            else
                            {
                                Console.WriteLine("\nGetHighestBalanceAccount() failed!");
                            }
                            break;
                        }
                    case 4: // Show account with lowest balance
                        {
                            Console.Write("The account with the lowest balance is: ");
                            Account selectedAccount = GetLowestBalanceAcount();
                            if (selectedAccount != null)
                            {
                                Console.WriteLine($"\n{selectedAccount}");
                            }
                            else
                            {
                                Console.WriteLine("\nGetLowestBalanceAccount() failed!");
                            }
                            break;
                        }
                    case 5: // Display
                        {
                            DisplayAccounts();
                        }
                        break;
                    case 6:
                        {
                            Console.WriteLine("\nNot-implemented option");
                        break;
                        }
                    case 7:
                        {
                            Console.WriteLine("\nNot-implemented option");
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("\nNot-implemented option");
                            break;
                        }
                    case 9: // exit
                        return;
                } // end of switch
                Console.WriteLine();
                Console.WriteLine("\n\nHit <Enter> to continue. . . "); // pause screen before clearning and redisplaying the Menu
                Console.ReadLine();
            } // end of while
        }
        static Account GetLowestBalanceAcount()
        {
            Account minAccount = accounts[0];
            foreach (Account a in accounts)
            {
                if (a.Balance < minAccount.Balance)
                {
                    minAccount = a;
                }
            }
            return minAccount;
        }
        static Account GetHighestBalanceAccount()
        { // use the OBJECT, not a variable (everything comes along with it!)
            Account maxAccount = accounts[0];
            foreach (Account a in accounts)
            {
                if (a.Balance > maxAccount.Balance)
                {
                    maxAccount = a;
                }
            }
            return maxAccount;
        }
        // method to create an arroy of accounts
        // placed outside of Main() so it is available
        static void CreateArrayOfAccounts()
        {
            Random rand = new Random();
            for(int i=0; i < accounts.Length; i++)
            {
                // 1st: Make random account number
                int accountNumber = rand.Next(1111111, 9999999); // rand.Next(range_low, range_high)
                // 2nd: Make a random balance amount
                int accountBalance = rand.Next(1_000, 9_999_999);
                // 3rd: Make the bank name random
                int index = rand.Next(0, banks.Length); // an INDEX is always an INT(32)
                string bank = banks[index];
                // create Account object and add it to the array
                Account account = new Account(accountNumber, accountBalance, bank);
                // accounts[i] = account;
                accounts[i] = account;
            }
        }
        static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("\t1. Deposit to an account");
            Console.WriteLine("\t2. Withdraw from an account");
            Console.WriteLine("\t3. Get account with highest balance");
            Console.WriteLine("\t4. Get account with lowest balance");
            Console.WriteLine("\t5. Display all accounts");
            Console.WriteLine("\t6. nothing");
            Console.WriteLine("\t7. nothing");
            Console.WriteLine("\t8. nothing");
            Console.WriteLine("\t9. Exit this program");
        }
        static void DisplayAccounts()
        {
            foreach(Account a in accounts)
            {
                Console.WriteLine(a.ToString()); // must override ToString();
            }
        }
        static Account GetAccount(int accountNumber)
        {  // helper method to search for an account given an accountNumber; return Account object if found, return NULL if not found
            foreach (Account a in accounts)
            {

                if (a.AccountNumber == accountNumber)
                {
                    return a; // found!
                }
            }
            return null; // not found
        }
    }
}
