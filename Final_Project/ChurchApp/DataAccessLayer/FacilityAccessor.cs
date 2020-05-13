using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using System.Data;

namespace DataAccessLayer
{
    public class FacilityAccessor : IFacilityAccessor
    {
        // This inserts a facility into the database
        public int InsertFacility(Facility facility)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_facility", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FacilityName", facility.FacilityName);
            cmd.Parameters.AddWithValue("@Description", facility.Description);
            cmd.Parameters.AddWithValue("@PricePerHour", facility.PricePerHour);
            cmd.Parameters.AddWithValue("@FacilityType", facility.FacilityType);
            
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

        // This selects a list of Facilities from the database. It only selects active facilities.
        public List<Facility> SelectAllFacilitiesByActive(bool active)
        {
            List<Facility> facilities = new List<Facility>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_facilities_by_active", conn);
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
                        Facility facility = new Facility();

                        facility.FacilityID = reader.GetInt32(0);
                        facility.FacilityName = reader.GetString(1);
                        facility.Description = reader.GetString(2);
                        facility.PricePerHour = reader.GetDecimal(3);
                        facility.FacilityType = reader.GetString(4);
                        facility.Active = reader.GetBoolean(5);

                        facilities.Add(facility);
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


            return facilities;
        }

        // This updates a facility that is in the databse.
        public int UpdateFacility(Facility oldFacility, Facility newFacility)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_facility", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FacilityID", oldFacility.FacilityID);

            cmd.Parameters.AddWithValue("@OldFacilityName", oldFacility.FacilityName);
            cmd.Parameters.AddWithValue("@OldDescription", oldFacility.Description);
            cmd.Parameters.AddWithValue("@OldPricePerHour", oldFacility.PricePerHour);
            cmd.Parameters.AddWithValue("@OldFacilityType", oldFacility.FacilityType);

            cmd.Parameters.AddWithValue("@NewFacilityName", newFacility.FacilityName);
            cmd.Parameters.AddWithValue("@NewDescription", newFacility.Description);
            cmd.Parameters.AddWithValue("@NewPricePerHour", newFacility.PricePerHour);
            cmd.Parameters.AddWithValue("@NewFacilityType", newFacility.FacilityType);

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
