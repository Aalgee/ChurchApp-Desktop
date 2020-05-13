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
    public class ActivityAccessor : IActivityAccessor
    {
        // This deletes a group activity from the database
        public int DeleteGroupActivity(int activityID, string groupID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_group_activity", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ActivityID", activityID);
            cmd.Parameters.AddWithValue("@GroupID", groupID);
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

        // This deletes a person activity from the database
        public int DeletePersonActivity(int personID, int activityID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_person_activity", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", personID);
            cmd.Parameters.AddWithValue("@ActivityID", activityID);
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

        // This inserts an activity into the database
        public int InsertActivity(ActivityVM activity)
        {
            int personID = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_activity", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ActivityName", activity.ActivityName);
            cmd.Parameters.AddWithValue("@ActivityTypeID", activity.ActivityTypeID);
            cmd.Parameters.AddWithValue("@LocationName", activity.LocationName);
            cmd.Parameters.AddWithValue("@Address1", activity.Address1);
            cmd.Parameters.AddWithValue("@Address2", activity.Address2);
            cmd.Parameters.AddWithValue("@City", activity.City);
            cmd.Parameters.AddWithValue("@State", activity.State);
            cmd.Parameters.AddWithValue("@Zip", activity.Zip);
            cmd.Parameters.AddWithValue("@Description", activity.Description);
            try
            {
                conn.Open();
                personID = Convert.ToInt32(cmd.ExecuteScalar());
                

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return personID;
        }

        // This inserts an activity schedule into the databse
        public int InsertActivitySchedule(int activityID, DateTime start, DateTime end)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_activity_schedule", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ActivityID", activityID);
            cmd.Parameters.AddWithValue("@Start", start);
            cmd.Parameters.AddWithValue("@End", end);
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

        // This inserts a group activity into the database
        public int InsertGroupActivity(int activityID, string groupID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_group_activity", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GroupID", groupID);
            cmd.Parameters.AddWithValue("@ActivityID", activityID);
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

        // This inserts a person activity into the database
        public int InsertPersonActivity(int personID, int activityID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_person_activity", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", personID);
            cmd.Parameters.AddWithValue("@ActivityID", activityID);
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

        // This selects a list of activity view models from the database. It only selects those view models that represent
        // the schedule of a given activity
        public List<ActivityVM> SelectActivitiesByActivitySchedule(bool activitySchedule)
        {
            List<ActivityVM> activities = new List<ActivityVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_activities_by_activity_schedule", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ActivitySchedule", activitySchedule);

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
                        activity.LocationName = reader.GetString(3);
                        activity.Address1 = reader.GetString(4);
                        activity.Address2 = reader.GetString(5);
                        activity.City = reader.GetString(6);
                        activity.State = reader.GetString(7);
                        activity.Zip = reader.GetString(8);
                        activity.Description = reader.GetString(9);
                        activity.Start = reader.GetDateTime(10);
                        activity.End = reader.GetDateTime(11);
                        activity.ScheduleID = reader.GetInt32(12);

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

        // This selects a list of activity view models from the databse. It selects the view models that correspond to a
        // given personID
        public List<ActivityVM> SelectActivitiesByPersonID(int personID, bool activitySchedule)
        {
            List<ActivityVM> activities = new List<ActivityVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_activities_by_person_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", personID);
            cmd.Parameters.AddWithValue("@ActivitySchedule", activitySchedule);
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
                        activity.LocationName = reader.GetString(3);
                        activity.Address1 = reader.GetString(4);
                        activity.Address2 = reader.GetString(5);
                        activity.City = reader.GetString(6);
                        activity.State = reader.GetString(7);
                        activity.Zip = reader.GetString(8);
                        activity.Description = reader.GetString(9);
                        activity.Start = reader.GetDateTime(10);
                        activity.End = reader.GetDateTime(11);
                        activity.PersonID = reader.GetInt32(12);

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

        // This selects a list of activity view models from the databse. It selects view models based on their schedule type
        // and the person ID associated with it
        public List<ActivityVM> SelectActivitiesByScheduleType(int personID, string scheduleType)
        {
            List<ActivityVM> activities = new List<ActivityVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_activities_by_schedule_type", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", personID);
            cmd.Parameters.AddWithValue("@Type", scheduleType);
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
                        activity.LocationName = reader.GetString(3);
                        activity.Address1 = reader.GetString(4);
                        activity.Address2 = reader.GetString(5);
                        activity.City = reader.GetString(6);
                        activity.State = reader.GetString(7);
                        activity.Zip = reader.GetString(8);
                        activity.Description = reader.GetString(9);
                        activity.ScheduleID = reader.GetInt32(10);
                        activity.PersonID = reader.GetInt32(11);
                        activity.Type = reader.GetString(12);
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

        // This selects a list of active activity view models from the database. 
        public List<ActivityVM> SelectAllActivitySchedulesByActive(bool active = true)
        {
            List<ActivityVM> activities = new List<ActivityVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_activity_schedules_by_active", conn);
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
                        var activity = new ActivityVM();

                        activity.ActivityID = reader.GetInt32(0);
                        activity.ActivityName = reader.GetString(1);
                        activity.ActivityTypeID = reader.GetString(2);
                        //activity.Type = reader.GetString(3);
                        activity.LocationName = reader.GetString(4);
                        activity.Address1 = reader.GetString(5);
                        activity.Address2 = reader.GetString(6);
                        activity.City = reader.GetString(7);
                        activity.State = reader.GetString(8);
                        activity.Zip = reader.GetString(9);
                        activity.Description = reader.GetString(10);
                        activity.ScheduleID = reader.GetInt32(11);
                        //activity.PersonID = reader.GetInt32(12);
                        
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

        // This selects all activity types from the database.
        public List<string> SelectAllActivityTypes()
        {
            List<string> activityTypes = new List<string>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_activity_types", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string activityType = reader.GetString(0);

                        activityTypes.Add(activityType);
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



            return activityTypes;
        }

        // This selects all the group activities from the database
        public List<GroupActivityVM> SelectAllGroupActivities()
        {
            List<GroupActivityVM> activities = new List<GroupActivityVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_group_activities", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var activity = new GroupActivityVM();

                        activity.ActivityID = reader.GetInt32(0);
                        activity.ActivityName = reader.GetString(1);
                        activity.Start = reader.GetDateTime(2);
                        activity.End = reader.GetDateTime(3);
                        //activity.GroupID = reader.GetString(4);

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

        // Thios updates an activity.
        public int UpdateActivity(ActivityVM oldActivity, ActivityVM newActivity)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_activity", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ActivityID", oldActivity.ActivityID);

            cmd.Parameters.AddWithValue("@OldActivityName", oldActivity.ActivityName);
            cmd.Parameters.AddWithValue("@OldActivityTypeID", oldActivity.ActivityTypeID);
            cmd.Parameters.AddWithValue("@OldLocationName", oldActivity.LocationName);
            cmd.Parameters.AddWithValue("@OldAddress1", oldActivity.Address1);
            cmd.Parameters.AddWithValue("@OldAddress2", oldActivity.Address2);
            cmd.Parameters.AddWithValue("@OldCity", oldActivity.City);
            cmd.Parameters.AddWithValue("@OldState", oldActivity.State);
            cmd.Parameters.AddWithValue("@OldZip", oldActivity.Zip);
            cmd.Parameters.AddWithValue("@OldDescription", oldActivity.Description);

            cmd.Parameters.AddWithValue("@NewActivityName", newActivity.ActivityName);
            cmd.Parameters.AddWithValue("@NewActivityTypeID", newActivity.ActivityTypeID);
            cmd.Parameters.AddWithValue("@NewLocationName", newActivity.LocationName);
            cmd.Parameters.AddWithValue("@NewAddress1", newActivity.Address1);
            cmd.Parameters.AddWithValue("@NewAddress2", newActivity.Address2);
            cmd.Parameters.AddWithValue("@NewCity", newActivity.City);
            cmd.Parameters.AddWithValue("@NewState", newActivity.State);
            cmd.Parameters.AddWithValue("@NewZip", newActivity.Zip);
            cmd.Parameters.AddWithValue("@NewDescription", newActivity.Description);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }

            return rows;
        }

    }
}
