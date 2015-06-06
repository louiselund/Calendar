using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Calendar.Api
{
    
        public class EveryWeekDayModel
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }
        public class DailyEveryWeekdayController : ApiController
        {
            
            public List<DateTime> Post(EveryWeekDayModel x)
            {
                var dates = new List<DateTime>();
                var i = DateTime.Compare(x.StartDate, x.EndDate);
                while (i <= 0)
                {

                    if (x.StartDate.DayOfWeek >= DayOfWeek.Monday && x.StartDate.DayOfWeek <= DayOfWeek.Friday)
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