using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Collection_InClassExercise
{
    class Account
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public DateTime DateCreated { get; set; }
        public string BankName { get; set; }
        // TODO: Add a ToString() override (does it require an IEnumerator or something?
        public override string ToString()
        {
            return $"Account Number:\t{AccountNumber}\nBank Name:\t{BankName}\nDate Created:\t{DateCreated.ToShortDateString()}\nBalance:\t{Balance:c}";
        }
    }
}
