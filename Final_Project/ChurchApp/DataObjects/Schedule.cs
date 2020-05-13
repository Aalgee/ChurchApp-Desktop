using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    // This class represents a schedule. It can bes useed to either represent a person's schedule or an activity's schedule.
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public int PersonID { get; set; }
        public int ActivityID { get; set; }
        public string Type { get; set; }
        public bool ActivitySchedule { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
