using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    // This class is representative of an activity that is going on in the church.
    public class Activity
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
    }
}
