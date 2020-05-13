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
    public class CandidateAccessor : ICandidateAccessor
    {
        /// <summary>
        /// This runs the deactivate canidate stored procedure
        /// </summary>
        /// <param name="candidateID"></param>
        /// <returns></returns>
        public int DeactivateCandidate(int candidateID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_deactivate_candidate", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ElectionID", candidateID);

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

        /// <summary>
        /// Runs the insert candidate stored procedure
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public int InsertCandidate(Candidate candidate)
        {
            int candidateID = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_candidate", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PersonID", candidate.PersonID);
            cmd.Parameters.AddWithValue("@ElectionID", candidate.ElectionID);
            try
            {
                conn.Open();
                candidateID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return candidateID;
        }

        /// <summary>
        /// Runs the select candidate by candidate ID stored procedure
        /// </summary>
        /// <param name="condidateID"></param>
        /// <returns></returns>
        public CandidateVM SelectCandidateByCandidateID(int condidateID)
        {
            CandidateVM candidate = new CandidateVM();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_candidate_by_candidate_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@active", condidateID);

            try
            {
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    candidate.CandidateID = reader.GetInt32(0);
                    candidate.PersonID = reader.GetInt32(1);
                    candidate.ElectionID = reader.GetInt32(2);
                    candidate.Votes = reader.GetInt32(3);
                    candidate.Active = reader.GetBoolean(4);
                    candidate.FirstName = reader.GetString(5);
                    candidate.LastName = reader.GetString(6);
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
            return candidate;
        }

        /// <summary>
        /// runs the select candidates by active stored procedure
        /// </summary>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<CandidateVM> SelectCandidatesByActive(bool active)
        {
            List<CandidateVM> candidates = new List<CandidateVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_candidates_by_active", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@active", active);

            try
            {
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var candidate = new CandidateVM();

                        candidate.CandidateID = reader.GetInt32(0);
                        candidate.PersonID = reader.GetInt32(1);
                        candidate.ElectionID = reader.GetInt32(2);
                        candidate.Votes = reader.GetInt32(3);
                        candidate.Active = reader.GetBoolean(4);
                        candidate.FirstName = reader.GetString(5);
                        candidate.LastName = reader.GetString(6);

                        candidates.Add(candidate);
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
            return candidates;
        }

        /// <summary>
        /// Returns a list of candidates by election
        /// </summary>
        /// <param name="electionID"></param>
        /// <returns></returns>
        public List<CandidateVM> SelectCandidatesByElectionID(int electionID)
        {
            List<CandidateVM> candidates = new List<CandidateVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_candidates_by_election_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@active", electionID);

            try
            {
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var candidate = new CandidateVM();

                        candidate.CandidateID = reader.GetInt32(0);
                        candidate.PersonID = reader.GetInt32(1);
                        candidate.ElectionID = reader.GetInt32(2);
                        candidate.Votes = reader.GetInt32(3);
                        candidate.Active = reader.GetBoolean(4);
                        candidate.FirstName = reader.GetString(5);
                        candidate.LastName = reader.GetString(6);

                        candidates.Add(candidate);
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
            return candidates;
        }

        /// <summary>
        /// updates a candidate
        /// </summary>
        /// <param name="oldCandidate"></param>
        /// <param name="newCandidate"></param>
        /// <returns></returns>
        public int UpdateCandidate(Candidate oldCandidate, Candidate newCandidate)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_candidate", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CandidateID", oldCandidate.CandidateID);

            cmd.Parameters.AddWithValue("@OldPersonID", oldCandidate.PersonID);
            cmd.Parameters.AddWithValue("@OldElectionID", oldCandidate.ElectionID);
            cmd.Parameters.AddWithValue("@OldVotes", oldCandidate.Votes);
            cmd.Parameters.AddWithValue("@OldActive", oldCandidate.Active);

            cmd.Parameters.AddWithValue("@NewPersonID", newCandidate.PersonID);
            cmd.Parameters.AddWithValue("@NewElectionID", newCandidate.ElectionID);
            cmd.Parameters.AddWithValue("@NewVotes", newCandidate.Votes);
            cmd.Parameters.AddWithValue("@NewActive", newCandidate.Active);
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
