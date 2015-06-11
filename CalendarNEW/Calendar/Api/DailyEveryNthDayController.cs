using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Calendar.Models;

namespace Calendar.Api
{
    public class ServerModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int DayliRepeat { get; set; }
    }
    public class DailyEveryNthDayController : ApiController
    {

        // daily, every n'th day
        public List<DateTime> Post(ServerModel x)
        {
            var dates = new List<DateTime>();
            var i = DateTime.Compare(x.StartDate, x.EndDate);
            double numberofdays = x.DayliRepeat;
            while (i < 0)
            {
                dates.Add(x.StartDate);
                x.StartDate = x.StartDate.AddDays(numberofdays);
                i = DateTime.Compare(x.StartDate, x.EndDate);
            }

            return dates;
        }
    }
}