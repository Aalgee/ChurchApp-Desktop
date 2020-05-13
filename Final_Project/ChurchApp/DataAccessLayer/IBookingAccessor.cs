using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayer
{
    public interface IBookingAccessor
    {
        List<BookingVM> SelectBookingsByActive(bool active);
        int UpdateBooking(Booking oldBooking, Booking newBooking);
        int UpdateBookingCheckOut(int bookingID, DateTime newCheckOut);
        int UpdateBookingCheckIn(int bookingID, DateTime newCheckIn);
        int InsertBooking(Booking booking);
        List<BookingVM> SelectBookingsByPersonID(int personID, bool active);
    }
}
