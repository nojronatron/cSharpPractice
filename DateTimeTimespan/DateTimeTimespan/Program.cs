using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeTimespan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Dates and Times *****");

            // YYYY, MM, DD
            DateTime dt = new DateTime(2019, 05, 20);

            // What day of the month is this?
            Console.WriteLine($"The day of {dt.Date} is {dt.DayOfWeek}");

            // Month is now July
            dt = dt.AddMonths(2);
            Console.WriteLine($"Daylight Saving: {dt.IsDaylightSavingTime()}");

            // Constructor takes (HH, MM, SS)
            TimeSpan ts = new TimeSpan(3, 45, 56);
            Console.WriteLine($"Timespan TS is: {ts}");

            // Subtract 25 mins from current TimeSpan and print result
            Console.WriteLine($"TimeSpan minus 25 mins: {ts.Subtract(new TimeSpan(0, 25, 0))}\n");

            // Pause program execution before exiting
            Console.ReadLine();
        }
    }
}
