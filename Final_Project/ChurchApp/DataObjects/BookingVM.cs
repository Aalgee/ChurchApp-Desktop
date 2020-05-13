using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    // This class inherits from the Booking class and represents the human readable fields associated with
    // it. This is used primarily for viewing selectied items from a database.
    public class BookingVM : Booking
    {
        public string FacilityName { get; set; }
        public string FacilityDescription { get; set; }
        public decimal PricePerHour { get; set; }
        public string FacilityType { get; set; }
        public string PersonFirstName { get; set; }
        public string PersontLastName { get; set; }
        public string PersonPhoneNumber { get; set; }
        public string PersonEmail { get; set; }
    }
}
