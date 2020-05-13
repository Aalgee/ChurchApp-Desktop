using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataObjects;

namespace LogicLayer
{
    public class UserManager : IUserManager
    {
        private IUserAccessor _userAccessor;

        // This is the no argument constructor
        public UserManager()
        {
            _userAccessor = new UserAccessor();
        }

        // this is the full constructor
        public UserManager(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }

        // This calls the accessor method that uses an email address and password to authenticate the user.
        public User AuthenticateUser(string email, string password)
        {
            User result = null;

            // hash the password
            var passwordHash = hashPassword(password);
            password = null;

            try
            {
                result = _userAccessor.AuthenticateUser(email, passwordHash);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Login failed!", ex);
            }

            return result;
        }

        // This calls the accessor method that selects a list of all the groups in the database.
        public List<string> RetrieveAllGroups()
        {
            try
            {
                return _userAccessor.SelectAllGroups();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Data not Found.", ex);
            }
        }

        // This calls the accessor method that selects a list of a persons groups in the database.
        public List<string> RetrievePersonGroups(int personID)
        {
            List<string> groups = null;
            try
            {
                groups = _userAccessor.SelectGroupsByPersonID(personID);
            }
            catch (Exception up)
            {

                throw new ApplicationException("Data not Found.", up);
            }
            return groups;
        }

        // This calls the accessor method that selects all of the person groups in a database.
        public List<string> RetrievePersonGroups()
        {
            List<string> groups = null;
            try
            {
                groups = _userAccessor.SelectAllGroups();
            }
            catch (Exception up)
            {

                throw new ApplicationException("Data not Found.", up);
            }
            return groups;
        }

        // This calls the accessor method that selects a list of a persons roles from the database.
        public List<string> RetrievePersonRoles(int personID)
        {
            List<string> roles = null;
            try
            {
                roles = _userAccessor.SelectRolesByPersonID(personID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Data not Found.", ex);
            }
            return roles;
        }

        // This calls the accessor method that selects all person roles from the database.
        public List<string> RetrievePersonRoles()
        {
            List<string> roles = null;
            try
            {
                roles = _userAccessor.SelectAllRoles();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Data not Found.", ex);
            }
            return roles;

        }

        // This calls the accessor method that selects all the roles from the database.
        public List<User> RetrieveUserListByActive(bool active = true)
        {
            try
            {
                return _userAccessor.SelectUsersByActive(active);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Data not Found.", ex);
            }
        }

        // This calls the accessor method that updates a particular users password.
        public bool UpdatePassword(int personID, string newPassword, string oldPassword)
        {
            bool isUpdated = false;

            string newPasswordHash = hashPassword(newPassword);
            string oldPasswordHash = hashPassword(oldPassword);

            try
            {
                isUpdated = _userAccessor.UpdatePasswordHash(personID, oldPasswordHash, newPasswordHash);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Update Failed", ex);
            }

            return isUpdated;
        }

        // This calls the accessor method that updates a user in the database.
        public bool EditUser(User oldUser, User newUser)
        {
            bool result = false;
            try
            {
                result = _userAccessor.UpdatePerson(oldUser, newUser) == 1;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Update failed", ex);
            }

            return result;
        }

        // This takes in a password and returns it as a hash value.
        private string hashPassword(string source)
        {
            // use sha256
            string result = null;

            // we need a byte array bc cryptography is bits and bytes
            byte[] data;

            // create a hash provider object
            using (SHA256 sha256hash = SHA256.Create())
            {
                // hash the input
                data = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }
            // build a string from the result
            var s = new StringBuilder();

            // loop through the bytes to build a string
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            result = s.ToString().ToUpper();

            return result;
        }

        // This calls the accessor method that iserst a user into the database.
        public bool AddUser(User user)
        {
            bool result = true;
            try
            {
                result = _userAccessor.InsertPerson(user) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("User not Added", ex);
            }
            return result;
        }

        // This calls the accessor method that sets a users status as active or inactive in the database.
        public bool SetUserActiveStatus(bool active, int personID)
        {
            bool result = false;
            try
            {
                if (active)
                {
                    result = 1 == _userAccessor.ActivatePerson(personID);
                }
                else
                {
                    result = 1 == _userAccessor.DeactivatePerson(personID);
                }
                if (result == false)
                {
                    throw new ApplicationException("Person record not updated.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update failed!", ex);
            }
            return result;
        }

        // This calls the accessor method that deletes a user's role in the database.
        public bool DeleteUserRole(int personID, string role)
        {
            bool result = false;
            try
            {
                result = (1 == _userAccessor.InsertOrDeletePersonRole(personID, role, delete: true));
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Role not added!", ex);
            }
            return result;
        }

        // This calls the accessor method that deletes a user's group in the database.
        public bool DeleteUserGroup(int personID, string group)
        {
            bool result = false;
            try
            {
                result = (1 == _userAccessor.InsertOrDeletePersonGroup(personID, group, delete: true));
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Role not added!", ex);
            }
            return result;
        }

        // This calls the accessor method that inserts a user's role in the database.
        public bool AddUserRole(int personID, string role)
        {
            bool result = false;
            try
            {
                result = (1 == _userAccessor.InsertOrDeletePersonRole(personID, role));
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Role not added!", ex);
            }
            return result;
        }

        // This calls the accessor method that inserts a user's group in the database.
        public bool AddUserGroup(int personID, string group)
        {
            bool result = false;
            try
            {
                result = (1 == _userAccessor.InsertOrDeletePersonGroup(personID, group));
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Role not added!", ex);
            }
            return result;
        }

        // This calls the accessor method that selects a list of users from the database based on activityID.
        public List<User> SelectUsersByActivityID(int activityID)
        {
            List<User> users = null;
            try
            {
                users = _userAccessor.SelectUsersByActivity(activityID);
            }
            catch (Exception up)
            {

                throw new ApplicationException("Data not Found.", up);
            }
            return users;
        }

        // This calls the accessor method that selects a list of users from the database based on groupID.
        public List<User> RetrieveUsersByGroupID(string groupID)
        {
            var users = new List<User>();
            try
            {
                users = _userAccessor.SelectUsersByGroupID(groupID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Users not Found", ex);
            }
            return users;
        }

        // This calls the accessor method that selects users from the database that have applied, but are
        // currently unapproved for a particular group.
        public List<User> RetrieveUnapprovedUsersByGroupID(string groupID)
        {
            var users = new List<User>();
            try
            {
                users = _userAccessor.SelectUnapprovedUsersByGroupID(groupID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Users not Found", ex);
            }
            return users;   
        }

        // This calls the accessor method that updates a role that person has as approved.
        public bool EditPersonRoleAsApproved(int personID, string roleID)
        {
            bool result = false;
            try
            {
                result = (1 == _userAccessor.UpdatePersonRoleAsApporved(personID, roleID));
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Role not edited!", ex);
            }
            return result;
        }

        // This calls the accessor method that adds an uapproved role to a person.
        public bool AddUnapprovedPersonRole(int personID, string roleID)
        {
            bool result = false;
            try
            {
                result = (1 == _userAccessor.InsertUnapprovedPersonRole(personID, roleID));
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Role not added!", ex);
            }
            return result;
        }

        // This calls the accessor method that selects unapproved roles for a person.
        public List<string> RetrieveUnnaprovedPersonRoles(int personID)
        {
            var roles = new List<string>();
            try
            {
                roles = _userAccessor.SelectUnapprovedPersonRoles(personID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Roles not Found", ex);
            }
            return roles;
        }

        // This calls the accessor method that selects users from the database that have applied, but are
        // currently unapproved for a particular roles.
        public List<User> RetrieveUnapprovedUsersByRoleID(string roleID)
        {
            var users = new List<User>();
            try
            {
                users = _userAccessor.SelectUsersByRoleID(roleID, false);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Users not Found", ex);
            }
            return users;
        }

        // This calls the accessor method that selects user's based upon roles have assigned to them.
        public List<User> RetrieveUsersByRoleID(string roleID)
        {
            var users = new List<User>();
            try
            {
                users = _userAccessor.SelectUsersByRoleID(roleID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Users not Found", ex);
            }
            return users;
        }
    }
}
