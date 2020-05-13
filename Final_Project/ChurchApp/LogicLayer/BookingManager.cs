using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayer;

namespace LogicLayer
{
    public class BookingManager : IBookingManager
    {
        IBookingAccessor _bookingAccesssor;

        // This is the no argument constructor.
        public BookingManager()
        {
            _bookingAccesssor = new BookingAccessor();
        }

        // This is the full constructor.
        public BookingManager(IBookingAccessor bookingAccessor)
        {
            _bookingAccesssor = bookingAccessor;
        }

        // This calls the accessor method that inserts a booking record into the database
        public bool AddBooking(Booking booking)
        {
            bool result = false;
            try
            {
                result = (1 == _bookingAccesssor.InsertBooking(booking));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        // This calls the accessor method that updates the check in field for a particular booking record.
        public bool EditBookingCheckIn(int bookingID, DateTime newCheckIn)
        {
            bool result = false;
            try
            {
                result = (1 == _bookingAccesssor.UpdateBookingCheckIn(bookingID, newCheckIn));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        // This calls the accessor method that updates the check out field for a particular booking record.
        public bool EditBookingCheckOut(int bookingID, DateTime newCheckOut)
        {
            bool result = false;
            try
            {
                result = (1 == _bookingAccesssor.UpdateBookingCheckOut(bookingID, newCheckOut));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        // This calls the accessor method that selects a list of active booking view models.
        public List<BookingVM> RetrieveBookingsByActive(bool active = true)
        {
            List<BookingVM> bookings = new List<BookingVM>();
            try
            {
                bookings = _bookingAccesssor.SelectBookingsByActive(active);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bookings;
        }

        // This calls the accessor method that selescts a list of active booking view models based upon the personID supplied.
        public List<BookingVM> RetrieveBookingsByPersonID(int personID, bool active = true)
        {
            List<BookingVM> bookings = new List<BookingVM>();
            try
            {
                bookings = _bookingAccesssor.SelectBookingsByPersonID(personID, active);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bookings;
        }
    }
}
