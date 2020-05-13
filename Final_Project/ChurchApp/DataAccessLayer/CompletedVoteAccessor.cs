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
    class CompletedVoteAccessor : ICompletedVoteAccessor
    {
        public int DeleteCompletedVote(int completedVoteID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_completed_vote", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@completedVoteID", completedVoteID);

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

        public int InsertCompletedVote(CompletedVote completedVote)
        {
            int CompletedVoteID = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_completed_vote", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PersonID", completedVote.PersonID);
            cmd.Parameters.AddWithValue("@ElectionID", completedVote.ElectionID);
            try
            {
                conn.Open();
                CompletedVoteID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return CompletedVoteID;
        }

        public List<CompletedVoteVM> SelectAllCompletedVotes()
        {
            List<CompletedVoteVM> completedVotes = new List<CompletedVoteVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_completed_votes", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            try
            {
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var completedVote = new CompletedVoteVM();

                        completedVote.CompletedVoteID = reader.GetInt32(0);
                        completedVote.PersonID = reader.GetInt32(1);
                        completedVote.ElectionID = reader.GetInt32(2);
                        completedVote.HasVoted = reader.GetBoolean(3);
                        completedVote.FirstName = reader.GetString(4);
                        completedVote.LastName = reader.GetString(5);
                        
                        completedVotes.Add(completedVote);
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
            return completedVotes;
        }

        public CompletedVoteVM SelectCompletedVoteByCompletedVoteID(int completedVoteID)
        {
            CompletedVoteVM completedVote = new CompletedVoteVM();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_completed_vote_by_completed_vote_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompletedVoteID", completedVote);

            try
            {
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    completedVote.CompletedVoteID = reader.GetInt32(0);
                    completedVote.PersonID = reader.GetInt32(1);
                    completedVote.ElectionID = reader.GetInt32(2);
                    completedVote.HasVoted = reader.GetBoolean(3);
                    completedVote.FirstName = reader.GetString(4);
                    completedVote.LastName = reader.GetString(5);
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
            return completedVote;
        }

        public List<CompletedVoteVM> SelectCompletedVotesByElectionID(int electionID)
        {
            List<CompletedVoteVM> completedVotes = new List<CompletedVoteVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_completed_votes_by_election_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ElectionID", electionID);

            try
            {
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var completedVote = new CompletedVoteVM();

                        completedVote.CompletedVoteID = reader.GetInt32(0);
                        completedVote.PersonID = reader.GetInt32(1);
                        completedVote.ElectionID = reader.GetInt32(2);
                        completedVote.HasVoted = reader.GetBoolean(3);
                        completedVote.FirstName = reader.GetString(4);
                        completedVote.LastName = reader.GetString(5);

                        completedVotes.Add(completedVote);
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
            return completedVotes;
        }

        public int UdateCompletedVote(CompletedVote oldCompletedVote, CompletedVote newCompletedVote)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_completed_vote", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CompletedVoteID", oldCompletedVote.ElectionID);

            cmd.Parameters.AddWithValue("@OldPersonID", oldCompletedVote.PersonID);
            cmd.Parameters.AddWithValue("@OldElectionID", oldCompletedVote.ElectionID);
            cmd.Parameters.AddWithValue("@OldHasVoted", oldCompletedVote.HasVoted);

            cmd.Parameters.AddWithValue("@NewPersonID", newCompletedVote.PersonID);
            cmd.Parameters.AddWithValue("@NewElectionID", newCompletedVote.ElectionID);
            cmd.Parameters.AddWithValue("@NewHasVoted", newCompletedVote.HasVoted);
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
