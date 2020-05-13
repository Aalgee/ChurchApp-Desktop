using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    // This is the base class for representing a booking from real life. This is used as a way to
    // insert, update, and delete records from a database
    public class Booking
    {
        public int BookingID { get; set; }
        public int FacilityID { get; set; }
        public int PersonID { get; set; }
        public DateTime ScheduledCheckOut { get; set; }
        public DateTime ScheduledCheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime CheckIn { get; set; }
        public bool Active { get; set; }
    }
}
