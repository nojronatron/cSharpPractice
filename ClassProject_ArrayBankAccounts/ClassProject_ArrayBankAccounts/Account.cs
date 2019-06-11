using System;
using System.Collections.Generic;
using System.Text;

namespace ClassProject_ArrayBankAccounts
{
    class Account
    {
        //Fields
        private int _accountNumber;
        private double _balance;
        private string _bank;
        private string _friendlyName;
        //CTORs
        public Account(int accountNumber, double balance, string bankName)
        {
            _accountNumber = accountNumber;
            _balance = balance;
            _bank = bankName;
            _friendlyName = "Unnamed Account"; // default value via CTOR
        }
        public Account(int accountNumber, double balance, string bankName, string friendlyName)
        {
            _accountNumber = accountNumber;
            _balance = balance;
            _bank = bankName;
            _friendlyName = friendlyName;
        }
        //Properties
        public int AccountNumber
        {
            get { return _accountNumber; }
        }
        public double Balance
        {
            get { return _balance; }
        }
        public string Bank
        {
            get { return _bank; }
        }
        public string FriendlyName
        {
            get { return _friendlyName; }
            set { _friendlyName = value; }
        }
        //Methods
        public void Deposit(double amount)
        {
            this._balance += amount;
        }
        public bool Withdrawl(double amount)
        {
            if(this._balance >= amount)
            {
                this._balance -= amount;
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            string output = $"Bank: {Bank}\t\tAccount Number: {AccountNumber}\t\tBalance: {Balance:C}";
            // if (FriendlyName != "") { return $"FriendlyName: {FriendlyName, -10}" + output; }
            // else { return output; }
            return output;
        }
        public override bool Equals(Object obj)
        {
            Account acct = (Account)obj;
            if (acct == this) { return true; } // default object comparison behavior: Are the object instances the same e.g.: acct1 == acct2
            else if (acct.AccountNumber == this.AccountNumber && acct.Balance == this.Balance && acct.Bank == this.Bank) // test properties for equality; different instances but same property values
            { return true; }
            else { return false; } // the objects are not the same (ref), and the properties of the objects are not of the same value (value)
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
