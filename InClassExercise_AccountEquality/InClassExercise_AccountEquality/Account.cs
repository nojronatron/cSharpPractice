using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClassExercise_AccountEquality
{
    public class Account
    {
        private int _accountNumber;
        private int _balance;
        private string _bank;
        public Account(int accountNumber, int balance, string bank) {
            _accountNumber = accountNumber;
            _balance = balance;
            _bank = bank;
        }
        public override string ToString()
        {
            return $"Account: {_accountNumber}\tBalance: {_balance:C2}\tBank: {_bank}";
        }
        public override bool Equals(object obj)
        {
            Account a1 = (Account)obj;
            if(this == a1) { return true; }
            if (this._accountNumber == a1._accountNumber && this._balance == a1._balance && this._bank == a1._bank) { return true; }
            else { return false; }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
