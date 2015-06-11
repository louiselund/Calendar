using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calendar.Models
{
    public class WeeklyEvent
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int Recur { get; set; }

        public bool NoEndDate { get; set; }

        public int NumberOfOccurence {get; set;}

        public bool EveryWeekDay { get; set; }
    }
}
