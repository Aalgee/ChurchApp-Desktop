using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IUserManager
    {
        User AuthenticateUser(string email, string password);
        bool UpdatePassword(int employeeID, string newPassword, string oldPassword);
        List<User> RetrieveUserListByActive(bool active = true);

        List<string> RetrievePersonRoles(int personID);
        List<string> RetrievePersonRoles();
        List<string> RetrievePersonGroups(int personID);
        
        List<string> RetrievePersonGroups();
        
        bool EditUser(User oldUser, User newUser);
        bool AddUser(User user);
        bool SetUserActiveStatus(bool active, int personID);
        bool DeleteUserRole(int personID, string role);
        bool DeleteUserGroup(int personID, string group);
        bool AddUserRole(int personID, string role);
        bool AddUserGroup(int personID, string group);
        List<User> SelectUsersByActivityID(int activityID);
        List<User> RetrieveUsersByGroupID(string groupID);
        List<User> RetrieveUnapprovedUsersByGroupID(string groupID);
        bool EditPersonRoleAsApproved(int personID, string roleID);
        bool AddUnapprovedPersonRole(int personID, string roleID);
        List<string> RetrieveUnnaprovedPersonRoles(int personID);
        List<User> RetrieveUnapprovedUsersByRoleID(string roleID);
        List<User> RetrieveUsersByRoleID(string roleID);
    }
}
