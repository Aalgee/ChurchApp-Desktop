using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ElectionAccessor : IElectionAccessor
    {
        public int DeactivateElection(Election election)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_deactivate_election", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ElectionID", election.ElectionID);

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

        public int InsertElection(Election election)
        {
            int ElectionID = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_election", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ElectionName", election.Name);
            cmd.Parameters.AddWithValue("@Description", election.Description);
            try
            {
                conn.Open();
                ElectionID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return ElectionID;
        }

        public ElectionVM SelectElectionByElectionID(int electionID)
        {
            ElectionVM election = new ElectionVM();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_election_by_election_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@active", electionID);

            try
            {
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    election.ElectionID = reader.GetInt32(0);
                    election.Name = reader.GetString(1);
                    election.Description = reader.GetString(2);
                    election.Active = reader.GetBoolean(3);
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
            return election;
        }

        public List<ElectionVM> SelectElectionsByActive(bool active)
        {
            List<ElectionVM> elections = new List<ElectionVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_elections_by_active", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@active", active);

            try
            {
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var election = new ElectionVM();

                        election.ElectionID = reader.GetInt32(0);
                        election.Name = reader.GetString(1);
                        election.Description = reader.GetString(2);
                        election.Active = reader.GetBoolean(3);

                        elections.Add(election);
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
            return elections;
        }

        public int UpdateElection(Election oldElection, Election newElection)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_election", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ElectionID", oldElection.ElectionID);

            cmd.Parameters.AddWithValue("@OldElectionName", oldElection.Name);
            cmd.Parameters.AddWithValue("@OldDescription", oldElection.Description);
            cmd.Parameters.AddWithValue("@OldActive", oldElection.Active);

            cmd.Parameters.AddWithValue("@NewElectionName", newElection.Name);
            cmd.Parameters.AddWithValue("@NewDescription", newElection.Description);
            cmd.Parameters.AddWithValue("@NewActive", newElection.Active);
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
