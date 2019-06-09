using System;

namespace ClassProject_BankAccounts
{
    class Program
    {
        static void Main(string[] args)
        {
            Account a1 = new Account(123456789, 10_000, "Bank of the NorthWest", "Joseph");
            Account a2 = a1;

            Account a3 = new Account(234567891, 20_000, "Northwest Bank of the PNW", "Clara");
            Account a4 = new Account(234567891, 20_000, "Northwest Bank of the PNW", "Pen");

            Account a5 = new Account(345678912, 30_000, "Great First Sea Bank");
            Account a6 = new Account(456789123, 40_000, "Sea First PNW Bank");

            Display(a1);
            Display(a2);

            Display(a3);
            Display(a4);

            Display(a5);
            Display(a6);

            DisplayComparison(a1, a2);
            DisplayComparison(a3, a4);
            DisplayComparison(a5, a6);



            Console.WriteLine("\n\n\n");
            Console.ReadLine();
        }
        public static void Display(Account acct)
        {
            Console.WriteLine($"{acct.ToString()}");
        }
        public static void DisplayComparison(Account acct1, Account acct2)
        {
            string output;
            bool result = acct1.Equals(acct2);
            // TODO: Use a TryCatch instead of boolean to test for custom FriendlyName
            try
            {
                if ((acct1.FriendlyName).Length < 1)
                {
                    output = $"The Bank Accounts {acct1.GetHashCode()} and {acct2.GetHashCode()} are Equal: {result}.";
                }
                else
                {
                    output = $"The Bank Accounts {acct1.FriendlyName} and {acct2.FriendlyName} are Equal: {result}.";
                }
            }
                catch (Exception ex)
            {
                output = $"An error occurred: {ex}.";
            }
            Console.WriteLine($"\n{output}\n");
        }
    }
}
