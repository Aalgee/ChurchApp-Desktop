using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    // This class represents a schedule that a person has.
    public class PersonScheduleVM
    {
        public string ActivityName { get; set; }
        public int ScheduleID { get; set; }
        public int PersonID { get; set; }
        public int ActivityID { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string LocationName { get; set; }
        public string Type { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ActivityTypeID { get; set; }
    }
}
