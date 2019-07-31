using System;
using System.Collections;
using System.Collections.Generic;

namespace Dictionary_Collection_InClassExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Account> accountDictionary = new Dictionary<int, Account>();
            Preload(accountDictionary);
            while (true)
            {
                Console.WriteLine("\n\n\t1. Display all accounts\n\t2. Search for an account\n\t3. delete an account\n\t9. Exit");
                int selection;
                int.TryParse(Console.ReadLine(), out selection);
                switch (selection)
                {
                    case 1:
                        {
                            //Display all accounts
                            Console.WriteLine("\n*** Display all accounts in the Dictionary ***");
                            foreach(KeyValuePair<int, Account> kvp in accountDictionary)
                            {
                                DisplayAccounts(kvp);
                            }
                        }
                        break;
                    case 2: //search by key
                        {
                            //get key:accountnumber from user
                            //use the Dictionary TryGet to search and return the 
                            //account with given account number
                            Console.Write("\nEnter the Account Number: ");
                            int acctNumKey;
                            int.TryParse(Console.ReadLine(), out acctNumKey);
                            if (accountDictionary.TryGetValue(acctNumKey, out Account acct))
                            {
                                KeyValuePair<int, Account> mykvp = new KeyValuePair<int, Account>(acct.AccountNumber, acct);
                                DisplayAccounts(mykvp);
                            }
                            else
                            {
                                Console.Write($"\nAccount {acctNumKey} not found!");
                            }
                        }
                        break;
                    case 3://delete(remove) by key  public bool Remove (TKey key);
                        {     //use the method:  public bool Remove (TKey key, out TValue value); if you want to
                              //get the account you want to remove
                              //get key:accountnumber from user
                            Console.Write("\nEnter the Account Number: ");
                            int acctNumKey;
                            int.TryParse(Console.ReadLine(), out acctNumKey);
                            if (accountDictionary.TryGetValue(acctNumKey, out Account acct))
                            {
                                int remAcctNum = acct.AccountNumber;
                                accountDictionary.Remove(acct.AccountNumber);
                                Console.WriteLine($"Account {remAcctNum} was removed.");
                            }
                            else
                            {
                                Console.WriteLine($"Account not found.");
                            }
                        }
                            break;
                    case 9:
                        return;

                }//end of switch
                Console.WriteLine("\n\nHit enter to continue...");
                Console.ReadLine();
                Console.Clear(); //clear screen before redisplaying the menu
            }//end of while

        }
        static void DisplayAccounts(KeyValuePair<int, Account> kvp)
        {
            // helper method for displaying results of user-selected actions like display and search
            Console.WriteLine($"Account Number: {kvp.Value.AccountNumber}");
            Console.WriteLine($"Bank Name: {kvp.Value.BankName}");
            Console.WriteLine($"Date Created: {kvp.Value.DateCreated}");
            Console.WriteLine($"Balance: {kvp.Value.Balance}");
            Console.WriteLine();
        }
        static void Preload(Dictionary<int, Account> dictionary)
        {
            string[] banknames = {"Wells Fargo","Goldman Sachs","Bank of America","Citigroup","JPMorgan Chase",
            "Morgan Stanley","U.S.Bancorp","Capital One","American Express","Ally Financial","UBS","M&T Bank",
            "Discover Financial","CIT Group","Mutual of Omaha","BankUnited","Valley National Bank",
            "PacWest Bancorp","Western Alliance Bank"};

            Random rand = new Random();
            for (int i = 1; i <= 50; i++)
            {
                int accountNumber = rand.Next(111111, 999999);
                decimal balance = rand.Next(500, 50000);
                int day = rand.Next(1, 29);
                int month = rand.Next(1, 13);
                int year = rand.Next(1970, DateTime.Now.Year - 1);
                DateTime dateCreated = new DateTime(year, month, day);
                string bankName = banknames[rand.Next(banknames.Length)];
                //create a random account
                Account account = new Account
                {
                    AccountNumber = accountNumber,
                    Balance = balance,
                    DateCreated = dateCreated,
                    BankName = bankName
                };

                //add to dictionary
                dictionary.Add(accountNumber, account);

            }
        }
    }
}
