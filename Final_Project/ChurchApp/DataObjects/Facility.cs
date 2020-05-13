using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    // This class represents a facility that can be reserved. This is used to create, update, and delete records from the database
    public class Facility
    {
        public int FacilityID { get; set; }
        public string FacilityName { get; set; }
        public string Description { get; set; }
        public decimal PricePerHour { get; set; }
        public string FacilityType { get; set; }
        public bool Active { get; set; }
    }
}
