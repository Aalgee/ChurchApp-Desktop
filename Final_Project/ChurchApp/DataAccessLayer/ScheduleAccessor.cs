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
    public class ScheduleAccessor : IScheduleAccessor
    {
        // This deactivates a schedule that is in the database
        public int DeactivateSchedule(int scheduleID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_deactivate_schedule", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ScheduleID", scheduleID);

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

        // This inserts a schedule into the database
        public int InsertSchedule(Schedule schedule)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_schedule", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PersonID", schedule.PersonID);
            cmd.Parameters.AddWithValue("@ActivityID", schedule.ActivityID);
            cmd.Parameters.AddWithValue("@Type", schedule.Type);
            cmd.Parameters.AddWithValue("@ActivitySchedule", schedule.ActivitySchedule);
            cmd.Parameters.AddWithValue("@Start", schedule.Start);
            cmd.Parameters.AddWithValue("@End", schedule.End);
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

        // This selects a list of Person Schedule view models from the database. They are selected based upon the
        // supplied PersonID.
        public List<PersonScheduleVM> SelectSchedulesByPersonID(int personID)
        {
            List<PersonScheduleVM> personSchedules = new List<PersonScheduleVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_schedule_by_person_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", personID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        var personSchedule = new PersonScheduleVM();

                        personSchedule.PersonID = reader.GetInt32(0);
                        personSchedule.ScheduleID = reader.GetInt32(1);
                        personSchedule.FirstName = reader.GetString(2);
                        personSchedule.LastName = reader.GetString(3);
                        personSchedule.Type = reader.GetString(4);
                        personSchedule.Start = reader.GetDateTime(5);
                        personSchedule.End = reader.GetDateTime(6);
                        personSchedule.ActivityName = reader.GetString(7);
                        personSchedule.Description = reader.GetString(8);
                        personSchedule.ActivityID = reader.GetInt32(9);
                        personSchedule.LocationName = reader.GetString(10);
                        personSchedule.Address1 = reader.GetString(11);
                        personSchedule.Address2 = reader.GetString(12);
                        personSchedule.City = reader.GetString(13);
                        personSchedule.State = reader.GetString(14);
                        personSchedule.Zip = reader.GetString(15);
                        personSchedule.ActivityTypeID = reader.GetString(16);

                        personSchedules.Add(personSchedule);
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

            return personSchedules;
        }

        // This selects a list of Person Schedule view models from the database. They are selected based upon and activityID, 
        // scheduleType, and if they are active.
        public List<PersonScheduleVM> SelectUserScheduleByActivityID(int activityID, string scheduleType, bool active)
        {
            List<PersonScheduleVM> personSchedules = new List<PersonScheduleVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_user_schedule_by_activity_id_and_type", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ActivityID", activityID);
            cmd.Parameters.AddWithValue("@Type", scheduleType);
            cmd.Parameters.AddWithValue("@Active", active);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var personSchedule = new PersonScheduleVM();

                        personSchedule.PersonID = reader.GetInt32(0);
                        
                        personSchedule.FirstName = reader.GetString(1);
                        personSchedule.LastName = reader.GetString(2);
                        personSchedule.ScheduleID = reader.GetInt32(3);
                        personSchedule.ActivityID = reader.GetInt32(4);
                        personSchedule.Start = reader.GetDateTime(5);
                        personSchedule.End = reader.GetDateTime(6);
                        personSchedule.Type = reader.GetString(7);

                        personSchedules.Add(personSchedule);
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

            return personSchedules;
        }

        // This selects a list of Activity view models from the database They are selected based upon and personID, 
        // scheduleType, and if they are active.
        public List<ActivityVM> SelectUserSchedulesByUserIDAndType(int personID, string scheduleType, bool active)
        {
            List<ActivityVM> activities = new List<ActivityVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_user_schedules_by_user_id_and_type", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", personID);
            cmd.Parameters.AddWithValue("@Type", scheduleType);
            cmd.Parameters.AddWithValue("@Active", active);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var activity = new ActivityVM();

                        activity.ActivityID = reader.GetInt32(0);
                        activity.ActivityName = reader.GetString(1);
                        activity.ActivityTypeID = reader.GetString(2);
                        activity.Type = reader.GetString(3);
                        activity.LocationName = reader.GetString(4);
                        activity.Address1 = reader.GetString(5);
                        activity.Address2 = reader.GetString(6);
                        activity.City = reader.GetString(7);
                        activity.State = reader.GetString(8);
                        activity.Zip = reader.GetString(9);
                        activity.Description = reader.GetString(10);
                        activity.ScheduleID = reader.GetInt32(11);
                        activity.PersonID = reader.GetInt32(12);
                        activity.Start = reader.GetDateTime(13);
                        activity.End = reader.GetDateTime(14);

                        activities.Add(activity);
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
            return activities;
        }

        // This updates an activity schedule in the database.
        public int UpdateActivitySchedule(ActivityVM oldSchedule, ActivityVM newSchedule)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_activity_schedule", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ScheduleID", oldSchedule.ScheduleID);

            cmd.Parameters.AddWithValue("@OldActivityID", oldSchedule.ActivityID);
            cmd.Parameters.AddWithValue("@OldStart", oldSchedule.Start);
            cmd.Parameters.AddWithValue("@OldEnd", oldSchedule.End);

            cmd.Parameters.AddWithValue("@NewActivityID", newSchedule.ActivityID);
            cmd.Parameters.AddWithValue("@NewStart", newSchedule.Start);
            cmd.Parameters.AddWithValue("@NewEnd", newSchedule.End);

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
    }
}
