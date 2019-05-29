using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountExercise_22May19
{
    class Account
    {
        // private long accountNumber;
        // private long balance;
        public Account(long acctNumber, long initialBalance)
        {
            AccountNumber = acctNumber;
            Balance = initialBalance;
        }
        public Account() { }
        public long AccountNumber { get; set; }
        public long Balance { get; set; }
        public void Withdrawl(long amount)
        {
            // reduces amount from balance if balance lt or eq withdrawl value
            if (amount <= Balance) Balance -= amount;
            else Console.WriteLine($"Error! Cannot withdraw {amount} from balance {Balance}.");
        }
        public void Deposit(long amount)
        {
            // adds amount to balance
            Balance += amount;
        }
        public void DisplayStats()
        {
            Console.WriteLine("\n** Account Info ***");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Account Balance: {Balance:C}\n");
        }
    }
}
