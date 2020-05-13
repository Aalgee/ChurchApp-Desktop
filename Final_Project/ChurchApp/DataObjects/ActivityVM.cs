using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    // This is a rerpresentation of an activity that provides more attribute than the base Activity class.
    // This view model shows the fields for an activity that make it more human readable.
    public class ActivityVM
    {
        public int ActivityID { get; set; }
        public string ActivityName { get; set; }
        public string ActivityTypeID { get; set; }
        public string LocationName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Description { get; set; }
        public int ScheduleID { get; set; }
        public int PersonID { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        
    }
}
