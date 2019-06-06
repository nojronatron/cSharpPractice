using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClassExercise_AccountEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            Account SameAccountObject1 = new Account(1234567, 10_000, "Bank of Murica");
            Account SameAccountObject2 = SameAccountObject1;
            Console.WriteLine(SameAccountObject1);
            Console.WriteLine(SameAccountObject2);
            Console.Write("SameAccountObject1 and SameAccountObject2 are the same? ");
            Console.WriteLine($"{SameAccountObject1.Equals(SameAccountObject2)}\n");

            Account SameAccountInfo1 = new Account(2345678, 20_000, "North West Southern Bank");
            Account SameAccountInfo2 = new Account(2345678, 20_000, "North West Southern Bank");
            Console.WriteLine(SameAccountInfo1);
            Console.WriteLine(SameAccountInfo2);
            Console.Write("\nSameAccountInfo1 and SameAccountInfo2 are the same? ");
            Console.WriteLine($"{SameAccountInfo1.Equals(SameAccountInfo2)}\n");

            Account SamishAccountInfo1 = new Account(1213145, 10_000, "NWSB");
            Account SamishAccountInfo2 = new Account(2324256, 10_000, "NWSB");
            Account SamishAccountInfo3 = new Account(2324256, 11_000, "NWSB");
            Account SamishAccountInfo4 = new Account(2324256, 11_000, "SNWB");
            Console.WriteLine($"{SamishAccountInfo1}\n{SamishAccountInfo2}\n{SamishAccountInfo3}\n{SamishAccountInfo4}\n");
            Console.WriteLine($"{SamishAccountInfo1.Equals(SamishAccountInfo2)}\n");
            Console.WriteLine($"{SamishAccountInfo2.Equals(SamishAccountInfo3)}\n");
            Console.WriteLine($"{SamishAccountInfo3.Equals(SamishAccountInfo4)}\n");
            Console.WriteLine($"{SamishAccountInfo4.Equals(SamishAccountInfo1)}\n");

            Account DifferentAccount1 = new Account(3456789, 30_000, "The People's Union Bank LLC");
            Account DifferentAccount2 = new Account(4567890, 35_000, "Union Bank of the People PLC");
            Console.WriteLine(DifferentAccount1);
            Console.WriteLine(DifferentAccount2);
            Console.Write("\nDifferentAccount1 and DifferentAccount2 are the same? ");
            Console.WriteLine($"{DifferentAccount1.Equals(DifferentAccount2)}\n");


            // Pause program execution before exit
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
