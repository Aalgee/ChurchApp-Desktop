using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataObjects;

namespace DataAccessLayer
{
    public class GroupAccessor : IGroupAccessor
    {
        // This inserts a person groups for someone that will be placed on waitlis. They later will be either
        // approved or denied for group membership
        public int InsertUnapprovedPersonGroup(int personID, string groupID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_unapproved_person_group", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", personID);
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

        // This selects a list of group activity view models. They are selected based upon their group ID.
        public List<GroupActivityVM> SelectActivitiesByGroupID(string groupID)
        {
            List<GroupActivityVM> activities = new List<GroupActivityVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_activities_by_group_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@GroupID", groupID);
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
                        activity.GroupID = reader.GetString(4);

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
        
        // This selects a list of groups that are associated with a particular activity
        public List<string> SelectGroupsByActivityID(int activityID)
        {
            List<string> groups = new List<string>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_groups_by_activity_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ActivityID", activityID);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        string group = reader.GetString(0);

                        groups.Add(group);
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
            return groups;
        }

        // This selects a list of groups that a particular person is yet to be approved for.
        public List<string> SelectUnapprovedPersonGroups(int personID)
        {
            List<string> groups = new List<string>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_unapproved_person_groups", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PersonID", personID);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string group = reader.GetString(0);

                        groups.Add(group);
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
            return groups;
        }

        // This updates a persons group as approved. Its used in order to approve a user for membership in a group.
        public int UpdatePersonGroupAsApproved(int personID, string groupID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_person_group_as_approved", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", personID);
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
    }
}
