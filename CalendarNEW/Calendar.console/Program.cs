using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar.Api;
using Calendar.test;

namespace Calendar.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var z = new DayliRecurringTest();
            z.PerformTest();
            Console.WriteLine("");
            var x = new DailyEveryWeekdayControllerTest();
            x.PerformTest();
            Console.WriteLine("");
            var y = new WeeklyRecurringTest();
            y.PerformTest();
            
        }
    }
}
