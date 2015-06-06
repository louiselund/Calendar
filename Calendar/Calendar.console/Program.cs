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
            var x = new DailyRecurringTest();
            //var x = new DailyEveryWeekdayControllerTest();
            //var x = new WeeklyRecurringTest();
            x.PerformTest();

        }
    }
}
