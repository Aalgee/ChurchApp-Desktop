using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayer
{
    public class BookingAccessor : IBookingAccessor
    {
        // This selects a list of Booking view models. This includes all the active bookings from the database.
        public List<BookingVM> SelectBookingsByActive(bool active)
        {
            List<BookingVM> bookings = new List<BookingVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_bookings_by_active", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Active", active);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var booking = new BookingVM();

                        booking.BookingID = reader.GetInt32(0);
                        booking.FacilityID = reader.GetInt32(1);
                        booking.PersonID = reader.GetInt32(2);
                        booking.ScheduledCheckOut = reader.GetDateTime(3);
                        booking.ScheduledCheckIn = reader.GetDateTime(4);

                        if (!reader.IsDBNull(5))
                        {
                            booking.CheckOut = reader.GetDateTime(5);
                        }
                        if(!reader.IsDBNull(6))
                        {
                            booking.CheckIn = reader.GetDateTime(6);
                        }

                        booking.Active = reader.GetBoolean(7);

                        booking.FacilityName = reader.GetString(8);
                        booking.FacilityDescription = reader.GetString(9);
                        booking.PricePerHour = reader.GetDecimal(10);
                        booking.FacilityType = reader.GetString(11);

                        booking.PersonFirstName = reader.GetString(12);
                        booking.PersontLastName = reader.GetString(13);
                        booking.PersonPhoneNumber = reader.GetString(14);
                        booking.PersonEmail = reader.GetString(15);

                        bookings.Add(booking);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return bookings;
        }

        // This updates the check in field of a booking
        public int UpdateBookingCheckIn(int bookingID, DateTime newCheckIn)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_booking_check_in", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BookingID", bookingID);

            //cmd.Parameters.AddWithValue("@OldCheckIn", oldCheckIn);
            cmd.Parameters.AddWithValue("@NewCheckIn", newCheckIn);
            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        // this updates a booking
        public int UpdateBooking(Booking oldBooking, Booking newBooking)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_booking", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BookingID", oldBooking.BookingID);

            cmd.Parameters.AddWithValue("@OldFacilityID", oldBooking.FacilityID);
            cmd.Parameters.AddWithValue("@OldPersonID", oldBooking.PersonID);
            cmd.Parameters.AddWithValue("@OldScheduledCheckOut", oldBooking.ScheduledCheckOut);
            cmd.Parameters.AddWithValue("@OldScheduledCheckIn", oldBooking.ScheduledCheckIn);
            cmd.Parameters.AddWithValue("@OldCheckOut", oldBooking.CheckOut);
            cmd.Parameters.AddWithValue("@OldCheckIn", oldBooking.CheckIn);
            cmd.Parameters.AddWithValue("@OldActive", oldBooking.Active);

            cmd.Parameters.AddWithValue("@NewFacilityID", newBooking.FacilityID);
            cmd.Parameters.AddWithValue("@NewPersonID", newBooking.PersonID);
            cmd.Parameters.AddWithValue("@NewScheduledCheckOut", newBooking.ScheduledCheckOut);
            cmd.Parameters.AddWithValue("@NewScheduledCheckIn", newBooking.ScheduledCheckIn);
            cmd.Parameters.AddWithValue("@NewCheckOut", newBooking.CheckOut);
            cmd.Parameters.AddWithValue("@NewCheckIn", newBooking.CheckIn);
            cmd.Parameters.AddWithValue("@NewActive", newBooking.Active);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        // this updates the check out field of a booking
        public int UpdateBookingCheckOut(int bookingID, DateTime newCheckOut)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_booking_check_out", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BookingID", bookingID);

            //cmd.Parameters.AddWithValue("@OldCheckOut", oldCheckOut);
            cmd.Parameters.AddWithValue("@NewCheckOut", newCheckOut);
            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        // This inserts a booking into the databse.
        public int InsertBooking(Booking booking)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_booking", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FacilityID", booking.FacilityID);

            cmd.Parameters.AddWithValue("@PersonID", booking.PersonID);
            cmd.Parameters.AddWithValue("@ScheduledCheckIn", booking.ScheduledCheckIn);
            cmd.Parameters.AddWithValue("@ScheduledCheckOut", booking.ScheduledCheckOut);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        // This selects a list of Booking view models. It gets all of the bookings assigned to a particular personID.
        public List<BookingVM> SelectBookingsByPersonID(int personID, bool active)
        {
            List<BookingVM> bookings = new List<BookingVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_bookings_by_person_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PersonID", personID);
            cmd.Parameters.AddWithValue("@Active", active);


            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var booking = new BookingVM();

                        booking.BookingID = reader.GetInt32(0);
                        booking.FacilityID = reader.GetInt32(1);
                        booking.PersonID = reader.GetInt32(2);
                        booking.ScheduledCheckOut = reader.GetDateTime(3);
                        booking.ScheduledCheckIn = reader.GetDateTime(4);

                        if (!reader.IsDBNull(5))
                        {
                            booking.CheckOut = reader.GetDateTime(5);
                        }
                        if (!reader.IsDBNull(6))
                        {
                            booking.CheckIn = reader.GetDateTime(6);
                        }

                        booking.Active = reader.GetBoolean(7);

                        booking.FacilityName = reader.GetString(8);
                        booking.FacilityDescription = reader.GetString(9);
                        booking.PricePerHour = reader.GetDecimal(10);
                        booking.FacilityType = reader.GetString(11);

                        booking.PersonFirstName = reader.GetString(12);
                        booking.PersontLastName = reader.GetString(13);
                        booking.PersonPhoneNumber = reader.GetString(14);
                        booking.PersonEmail = reader.GetString(15);

                        bookings.Add(booking);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return bookings;
        }
    }
}
