using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparable_IComparer_Interfaces
{
    class Account : IComparable<Account>
    {
        private long accountNumber;
        private decimal balance;
        public Account(long acctNumber, decimal initialBalance)
        {
            AccountNumber = acctNumber;
            Balance = initialBalance;
        }
        public Account() { }
        public long AccountNumber
        {
            get { return this.accountNumber; }
            set { this.accountNumber = value; }
        }
        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }
        public void Withdrawl(decimal amount)
        {
            // reduces amount from balance if balance lt or eq withdrawl value
            if (amount <= Balance) Balance -= amount;
            else Console.WriteLine($"Error! Cannot withdraw {amount} from balance {Balance}.");
        }
        public void Deposit(decimal amount)
        {
            // adds amount to balance
            Balance += amount;
        }
        public int CompareTo(Account other)
        {
            if (this.Balance > other.Balance)
            {
                return 1;
            }
            if (this.Balance < other.Balance)
            {
                return -1;
            }
            return 0;
            // A shortcut to this is to use ComparTo via the primitive type in the Account object
            //    e.g.: return this.Balance.CompareTo(other.Balance);
        }
        public override string ToString()
        {
            return $"{AccountNumber,-10}{Balance,-10}";
        }
        public class AccountComparer : IComparer<Account>
        {
            // There is no limit on the number of Nested Classes that can be programmed 
            // Make this public because this class needs to be called directly to utilize it
            // As a nested Class, it will always come-along with Box.cs
            public int Compare(Account acc1, Account acc2)
            {
                if (acc1.AccountNumber > acc2.AccountNumber)
                {
                    return 1;
                }
                if (acc1.AccountNumber < acc2.AccountNumber)
                {
                    return -1;
                }
                return 0;
                // that is ALL this nested class needs to do; provide a way to compare, so Sort() can do its job
            }
        }
    }
}
