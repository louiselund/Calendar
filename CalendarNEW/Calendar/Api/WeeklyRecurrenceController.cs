using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Ajax.Utilities;

namespace Calendar.Api
{
    public class WeeklyRecurringModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WeeklyRepeat { get; set; }
        public int FrequencyInterval { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

    }

    public class WeeklyRecurringController : ApiController
    {
        public List<DateTime> Post(WeeklyRecurringModel y)
        {
            //var dates = new List<DateTime>();
            //var i = DateTime.Compare(y.StartDate, y.EndDate);
            //double numberofweeks = y.WeeklyRepeat;
            List<DateTime>
                ChosenDays = new List<DateTime>();

            var date = y.StartDate;
            var i = DateTime.Compare(y.StartDate, y.EndDate);

            while (i <= 0)
            {
                if (y.Monday && date.DayOfWeek == DayOfWeek.Monday)
                {
                    ChosenDays.Add(date);
                }

                if (y.Tuesday && date.DayOfWeek == DayOfWeek.Tuesday)
                {
                    ChosenDays.Add(date);
                }

                if (y.Wednesday && date.DayOfWeek == DayOfWeek.Wednesday)
                {
                    ChosenDays.Add(date);
                }

                if (y.Thursday && date.DayOfWeek == DayOfWeek.Thursday)
                {
                    ChosenDays.Add(date);
                }

                if (y.Friday && date.DayOfWeek == DayOfWeek.Friday)
                {
                    ChosenDays.Add(date);
                }

                if (y.Saturday && date.DayOfWeek == DayOfWeek.Saturday)
                {
                    ChosenDays.Add(date);
                }

                if (y.Sunday && date.DayOfWeek == DayOfWeek.Sunday)
                {
                    ChosenDays.Add(date);
                }

                date = date.AddDays(1);
                i = DateTime.Compare(date, y.EndDate);

            }

            return ChosenDays;

       }
    }    
}
