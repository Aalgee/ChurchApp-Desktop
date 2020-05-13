using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    // This class represents an activity that particular groups is associated with.
    public class GroupActivityVM
    {
        public int ActivityID { get; set; }
        public string ActivityName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string GroupID { get; set; }

    }
}
