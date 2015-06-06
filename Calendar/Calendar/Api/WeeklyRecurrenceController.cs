using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Calendar.Api
{

    public class WeeklyRecurringModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WeeklyRepeat { get; set; }

    }
    public class WeeklyRecurringController : ApiController
    {

        public List<DateTime> Post(WeeklyRecurringModel x)
        {
            var dates = new List<DateTime>();
            var i = DateTime.Compare(x.StartDate, x.EndDate);
            double numberofweeks = x.WeeklyRepeat;
            while (i <= 0)
            {

                if (x.StartDate.DayOfWeek >= DayOfWeek.Monday && x.StartDate.DayOfWeek <= DayOfWeek.Monday)
                {
                    dates.Add(x.StartDate);
                }
                x.StartDate = x.StartDate.AddDays(1);
                i = DateTime.Compare(x.StartDate, x.EndDate);
            }

            return dates;
        }

    }

}