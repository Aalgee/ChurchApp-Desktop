using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataObjects;

namespace LogicLayer
{
    public class GroupManager : IGroupManager
    {
        IGroupAccessor _groupAccessor;

        // This is the no argument constructor.
        public GroupManager()
        {
            _groupAccessor = new GroupAccessor();
        }

        // This is the full constructor
        public GroupManager(IGroupAccessor groupAccessor)
        {
            _groupAccessor = groupAccessor;
        }

        // This calls the accessor method that inserts an unapproved person group into the database.
        public bool AddUnapprovedPersonGroup(int personID, string groupID)
        {
            bool result = false;
            try
            {
                result = (1 == _groupAccessor.InsertUnapprovedPersonGroup(personID, groupID));
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Person Group not added.", ex);
            }
            return result;
        }

        // This calls the accessor method that updates a person group as approved.
        public bool EditPersonGroupAsApproved(int personID, string groupID)
        {
            bool result = false;
            try
            {
                result = (1 == _groupAccessor.UpdatePersonGroupAsApproved(personID, groupID));
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Person Group not Edited.", ex);
            }
            return result;
        }

        // This calls the accessor method that selects a list of group activity view models by groupID.
        public List<GroupActivityVM> RetrieveActivitiesByGroupID(string groupID)
        {
            List<GroupActivityVM> activities = null;
            try
            {
                activities = _groupAccessor.SelectActivitiesByGroupID(groupID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Activity not found!", ex);
            }
            return activities;
        }

        // This calls the accessor method that selects a list of groups by activityID;
        public List<string> RetrieveGroupsByActivityID(int activityID)
        {
            List<string> groups = null;
            try
            {
                groups = _groupAccessor.SelectGroupsByActivityID(activityID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Group not found!", ex);
            }
            return groups;
        }

        // This calls the accessor method that selects a list of unapproved person groups by personID.
        public List<string> RetriveUnapprovedPersonGroups(int personID)
        {
            List<string> groups = null;
            try
            {
                groups = _groupAccessor.SelectUnapprovedPersonGroups(personID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Group not found!", ex);
            }
            return groups;
        }
    }
}
