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
            // TODO: Rewrite console interface as a menu system
            Console.WriteLine("***** Exercise: Accounts *****");
            Console.WriteLine();

            Account one = new Account(100000000, 1000);
            one.Deposit(1000);
            //Console.WriteLine($"Account one\nAccount Number: {one.AccountNumber}\nBalance: {one.Balance}\n");
            one.DisplayStats();

            Account two = new Account(200000000, 2000);
            two.Withdrawl(1999);
            // Console.WriteLine($"Account two\nAccount Number: {two.AccountNumber}\nBalance: {two.Balance}\n");
            two.DisplayStats();

            Console.WriteLine("\nTransferring {0:C} from {1} to {2}...\n", 1, one.AccountNumber, two.AccountNumber);
            TransferFunds(one, two, 1);

            one.DisplayStats();
            two.DisplayStats();

            Console.ReadLine();
        }
        static void TransferFunds(Account acctFrom, Account acctTo, long Amount)
        {
            // transfer allowed if acctFrom.balance is ge Amount
            if (Amount >= acctFrom.Balance)
            {
                Console.WriteLine($"Error! Unable to withdrawl {Amount} from " +
                $"{acctFrom.AccountNumber} with balance of {acctFrom.Balance}.");
            }
            else
            {
                acctFrom.Withdrawl(Amount);
                acctTo.Deposit(Amount);
            }
        }
    }
}
