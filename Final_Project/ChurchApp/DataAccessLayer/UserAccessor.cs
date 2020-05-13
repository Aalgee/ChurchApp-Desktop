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
    public class UserAccessor : IUserAccessor
    {
        // This authenticates a user based upon their username and password
        public User AuthenticateUser(string username, string passwordHash)
        {
            User result = null; // 1 if the user is authenticated

            // Connection
            var conn = DBConnection.GetConnection();

            // Command object
            var cmd = new SqlCommand("sp_authenticate_user");
            cmd.Connection = conn;

            // set command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameters for the procedure
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 100);

            // set the values for the parameters

            cmd.Parameters["@Email"].Value = username;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            // execute the command
            try
            {
                // open connection
                conn.Open();

                if(1 == Convert.ToInt32(cmd.ExecuteScalar()))
                {
                    // if the command worked correctly get a user object
                    result = getUserByEmail(username);
                }
                else
                {
                    throw new ApplicationException("User not found.");
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
            return result;
        }
        
        // This returns a list of roles from the databse based upon the PersonID provided.
        public List<string> SelectRolesByPersonID(int personID)
        {
            List<string> roles = new List<String>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_roles_by_person_id");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PersonID", SqlDbType.Int);
            cmd.Parameters["@PersonID"].Value = personID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        string role = reader.GetString(0);

                        roles.Add(role);
                    }
                }
            }
            catch (Exception up)
            {

                throw up;
            }
            finally
            {
                conn.Close();
            }

            return roles;
        }

        // This returns a list of active users from the database.
        public List<User> SelectUsersByActive(bool active = true)
        {
            List<User> users = new List<User>();

            var conn = DBConnection.GetConnection();
            var cmd1 = new SqlCommand("sp_select_users_by_active");
            var cmd2 = new SqlCommand("sp_select_roles_by_person_id");
            var cmd3 = new SqlCommand("sp_select_groups_by_person_id");

            cmd1.Connection = conn;
            cmd2.Connection = conn;
            cmd3.Connection = conn;

            cmd1.CommandType = CommandType.StoredProcedure;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd3.CommandType = CommandType.StoredProcedure;

            cmd1.Parameters.Add("@Active", SqlDbType.Bit);
            cmd1.Parameters["@Active"].Value = active;

            cmd2.Parameters.Add("@PersonID", SqlDbType.Int);

            cmd3.Parameters.Add("@PersonID", SqlDbType.Int);
            int userCount = 0;

            try
            {
                conn.Open();
                var reader1 = cmd1.ExecuteReader();
                
                

                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {

                        var user = new User();
                        List<string> roles = new List<string>();
                        List<string> groups = new List<string>();

                        user.PersonID = reader1.GetInt32(0);
                        user.FirstName = reader1.GetString(1);
                        user.LastName = reader1.GetString(2);
                        if (!reader1.IsDBNull(3))
                        {
                            user.Dob = reader1.GetDateTime(3);
                        }
                        if (!reader1.IsDBNull(4))
                        {
                            user.PhoneNumber = reader1.GetString(4);
                        }
                        user.Email = reader1.GetString(5);
                        if (!reader1.IsDBNull(6))
                        {
                            user.Address1 = reader1.GetString(6);
                        }
                        if (!reader1.IsDBNull(7))
                        {
                            user.Address2 = reader1.GetString(7);
                        }
                        if (!reader1.IsDBNull(8))
                        {
                            user.City = reader1.GetString(8);
                        }
                        if (!reader1.IsDBNull(9))
                        {
                            user.State = reader1.GetString(9);
                        }
                        if (!reader1.IsDBNull(10))
                        {
                            user.Zip = reader1.GetString(10);
                        }
                            
                        user.Active = reader1.GetBoolean(11);

                        reader1.Close();

                        cmd2.Parameters["@PersonID"].Value = user.PersonID;
                        var reader2 = cmd2.ExecuteReader();
                        if (reader2.HasRows)
                        {
                            while(reader2.Read())
                            {
                                
                                var role = reader2.GetString(0);
                                roles.Add(role);                                
                            }
                        }
                        reader2.Close();
                        user.Roles = roles;

                        cmd3.Parameters["@PersonID"].Value = user.PersonID;
                        var reader3 = cmd3.ExecuteReader();
                        if (reader3.Read())
                            while(reader3.Read())
                            {
                                cmd3.Parameters["@PersonID"].Value = user.PersonID;
                                var group = reader3.GetString(0);
                                groups.Add(group);
                            }

                        user.Groups = groups;
                        reader3.Close();
                        users.Add(user);
                        userCount += 1;
                        reader1 = cmd1.ExecuteReader();
                        for (int i = 0; i < userCount; i++)
                        {
                            reader1.Read();
                        }
                        
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
            return users;
        }

        // This updates thae password hash of a user in the datatabase
        public bool UpdatePasswordHash(int personID, string oldPasswordHash, string newPasswordHash)
        {
            bool updateSuccess = false;

            // connection
            var conn = DBConnection.GetConnection();

            //cmd
            var cmd = new SqlCommand("sp_update_password");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@PersonID", SqlDbType.Int);
            cmd.Parameters.Add("@OldPasswordHash", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@NewPasswordHash", SqlDbType.NVarChar, 100);

            // values
            cmd.Parameters["@PersonID"].Value = personID;
            cmd.Parameters["@OldPasswordHash"].Value = oldPasswordHash;
            cmd.Parameters["@NewPasswordHash"].Value = newPasswordHash;

            // execute command

            try
            {
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                updateSuccess = (rows == 1);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return updateSuccess;
        }

        // This returns a user based upon an email that is provided
        private User getUserByEmail(string email)
        {
            User user = null;

            // connection
            var conn = DBConnection.GetConnection();

            // command objects (2)
            var cmd1 = new SqlCommand("sp_select_person_by_email");
            var cmd2 = new SqlCommand("sp_select_roles_by_person_id");

            cmd1.Connection = conn;
            cmd2.Connection = conn;

            cmd1.CommandType = CommandType.StoredProcedure;
            cmd2.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd1.Parameters.Add("@Email", SqlDbType.NVarChar, 250);
            cmd1.Parameters["@Email"].Value = email;

            cmd2.Parameters.Add("@PersonID", SqlDbType.NVarChar, 250);
            // we cannot set the value of this parameter yet

            try
            {
                // Open Connection
                conn.Open();

                // execute the first command
                var reader1 = cmd1.ExecuteReader();

                if(reader1.Read())
                {
                    user = new User();

                    user.PersonID = reader1.GetInt32(0);
                    user.FirstName = reader1.GetString(1);
                    user.LastName = reader1.GetString(2);
                    user.PhoneNumber = reader1.GetString(3);
                    user.Email = email;
                }
                else
                {
                    throw new ApplicationException("User not found.");
                }
                reader1.Close(); // this is no longer needed

                cmd2.Parameters["@PersonID"].Value = user.PersonID;
                var reader2 = cmd2.ExecuteReader();

                List<string> roles = new List<string>();
                while (reader2.Read())
                {
                    string role = reader2.GetString(0);
                    roles.Add(role);
                }
                user.Roles = roles;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return user;
        }

        // This returns a list of groups based upon the PersonID provided
        public List<string> SelectGroupsByPersonID(int personID)
        {
            List<string> groups = new List<string>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_groups_by_person_id");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PersonID", SqlDbType.Int);
            cmd.Parameters["@PersonID"].Value = personID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string group = reader.GetString(0);
                        groups.Add(group);
                    }
                }
            }
            catch (Exception up)
            {

                throw up;
            }
            finally
            {
                conn.Close();
            }
            return groups;
        }
        
        // This returns all the roles there are from the database
        public List<string> SelectAllRoles()
        {
            List<string> roles = new List<string>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_roles");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        string role = reader.GetString(0);
                        roles.Add(role);
                    }
                }
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return roles;
        }

        // This returns all the groups there are from the database.
        public List<string> SelectAllGroups()
        {
            List<string> groups = new List<string>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_groups");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

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
            catch(Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return groups;
        }
        
        // This updates a user in the database.
        public int UpdatePerson(User oldUser, User newUser)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_update_person", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PersonID", oldUser.PersonID);
            cmd.Parameters.AddWithValue("@OldFirstName", oldUser.FirstName);
            cmd.Parameters.AddWithValue("@OldLastName", oldUser.LastName);
            cmd.Parameters.AddWithValue("@OldDob",oldUser.Dob);
            cmd.Parameters.AddWithValue("@OldPhoneNumber", oldUser.PhoneNumber);
            cmd.Parameters.AddWithValue("@OldEmail", oldUser.Email);
            cmd.Parameters.AddWithValue("@OldAddress1", oldUser.Address1);
            cmd.Parameters.AddWithValue("@OldAddress2", oldUser.Address2);
            cmd.Parameters.AddWithValue("@OldCity", oldUser.City);
            cmd.Parameters.AddWithValue("@OldState", oldUser.State);
            cmd.Parameters.AddWithValue("@OldZip", oldUser.Zip);

            cmd.Parameters.AddWithValue("@NewFirstName", newUser.FirstName);
            cmd.Parameters.AddWithValue("@NewLastName", newUser.LastName);
            cmd.Parameters.AddWithValue("@NewDob", newUser.Dob);
            cmd.Parameters.AddWithValue("@NewPhoneNumber", newUser.PhoneNumber);
            cmd.Parameters.AddWithValue("@NewEmail", newUser.Email);
            cmd.Parameters.AddWithValue("@NewAddress1", newUser.Address1);
            cmd.Parameters.AddWithValue("@NewAddress2", newUser.Address2);
            cmd.Parameters.AddWithValue("@NewCity", newUser.City);
            cmd.Parameters.AddWithValue("@NewState", newUser.State);
            cmd.Parameters.AddWithValue("@NewZip", newUser.Zip);

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

        // This inserts a user into the datatbase.
        public int InsertPerson(User user)
        {
            int personID = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_person", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@Dob", user.Dob);
            cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Address1", user.Address1);
            cmd.Parameters.AddWithValue("@Address2", user.Address2);
            cmd.Parameters.AddWithValue("@City", user.City);
            cmd.Parameters.AddWithValue("@State", user.State);
            cmd.Parameters.AddWithValue("@Zip", user.Zip);

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

        // This activates a user in the database.
        public int ActivatePerson(int personID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_reactivate_person", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", personID);

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

        // This deactivates a user in the database.
        public int DeactivatePerson(int personID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_deactivate_person", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", personID);

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

        // This either inserts or deletes a user's role from the database.
        public int InsertOrDeletePersonRole(int personID, string role, bool delete = false)
        {
            int rows = 0;
            string cmdText = delete ? "sp_delete_person_role" : "sp_insert_person_role";
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", personID);
            cmd.Parameters.AddWithValue("@RoleID", role);
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

        // This either inserts or deletes a user's group from the database.
        public int InsertOrDeletePersonGroup(int personID, string group, bool delete = false)
        {
            int rows = 0;
            string cmdText = delete ? "sp_delete_person_group" : "sp_insert_person_group";
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", personID);
            cmd.Parameters.AddWithValue("@GroupID", group);
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

        // This returns a list of users from the database based upon what activityID is associated with them.
        public List<User> SelectUsersByActivity(int activityID)
        {
            List<User> users = new List<User>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_person_by_activity", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ActivityID", activityID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();



                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var person = new User();

                        person.PersonID = reader.GetInt32(0);
                        person.FirstName = reader.GetString(1);
                        person.LastName = reader.GetString(2);

                        users.Add(person);
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


            return users;
        }

        // This returns a list of users from the database based upon what groupID is associated with them.
        public List<User> SelectUsersByGroupID(string groupID)
        {
            List<User> users = new List<User>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_users_by_group_id", conn);
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
                        var user = new User();
                        user.PersonID = reader.GetInt32(0);
                        user.FirstName = reader.GetString(1);
                        user.LastName = reader.GetString(2);

                        users.Add(user);
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

            return users;
        }

        // This returns a list of users from the database that have applied for, but are yet unapproved for,
        // a particular group
        public List<User> SelectUnapprovedUsersByGroupID(string groupID)
        {
            List<User> users = new List<User>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_unapproved_users_by_group_id", conn);
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
                        var user = new User();
                        user.PersonID = reader.GetInt32(0);
                        user.FirstName = reader.GetString(1);
                        user.LastName = reader.GetString(2);

                        users.Add(user);
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

            return users;
        }

        // This updates a persons role as approved. It is used primarily to approve users a volunteers.
        public int UpdatePersonRoleAsApporved(int personID, string roleID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_person_role_as_approved", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", personID);
            cmd.Parameters.AddWithValue("@RoleID", roleID);

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

        // This updates a person role as approved. It is used primarily to let users apply to become volunteers.
        public int InsertUnapprovedPersonRole(int personID, string roleID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_unapproved_person_role", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", personID);
            cmd.Parameters.AddWithValue("@RoleID", roleID);

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

        // This selects the unapproved roles that a particular person has.
        public List<string> SelectUnapprovedPersonRoles(int personID)
        {
            List<string> roles = new List<string>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_unapproved_person_roles", conn);
            
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
                        string role = reader.GetString(0);
                        roles.Add(role);
                    }
                }
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return roles;
        }

        // This selects a list of users who are unapproved for a particular role.
        public List<User> SelectUnapprovedUsersByRoleID(string roleID)
        {
            List<User> users = new List<User>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_unapproved_users_by_role_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoleID", roleID);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var user = new User();
                        user.PersonID = reader.GetInt32(0);
                        user.FirstName = reader.GetString(1);
                        user.LastName = reader.GetString(2);

                        users.Add(user);
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

            return users;
        }

        // This selects a list of users who have a particular role, are approved, and are also active.
        public List<User> SelectUsersByRoleID(string roleID, bool isApproved = true, bool active = true)
        {
            List<User> users = new List<User>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_user_by_role_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@roleID", roleID);
            cmd.Parameters.AddWithValue("@IsApproved", isApproved);
            cmd.Parameters.AddWithValue("@Active", active);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var user = new User();
                        user.PersonID = reader.GetInt32(0);
                        user.FirstName = reader.GetString(1);
                        user.LastName = reader.GetString(2);
                        if (!reader.IsDBNull(3))
                        {
                            user.Dob = reader.GetDateTime(3);
                        }
                        if (!reader.IsDBNull(4))
                        {
                            user.PhoneNumber = reader.GetString(4);
                        }
                        user.Email = reader.GetString(5);
                        if (!reader.IsDBNull(6))
                        {
                            user.Address1 = reader.GetString(6);
                        }
                        if (!reader.IsDBNull(7))
                        {
                            user.Address2 = reader.GetString(7);
                        }
                        if (!reader.IsDBNull(8))
                        {
                            user.City = reader.GetString(8);
                        }
                        if (!reader.IsDBNull(9))
                        {
                            user.State = reader.GetString(9);
                        }
                        if (!reader.IsDBNull(10))
                        {
                            user.Zip = reader.GetString(10);
                        }
                        user.Active = reader.GetBoolean(11);

                        users.Add(user);
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
            return users;
        }
    }
    
}
