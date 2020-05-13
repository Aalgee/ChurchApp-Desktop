using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayer
{
    public interface IGroupAccessor
    {
        List<string> SelectGroupsByActivityID(int activityID);
        List<GroupActivityVM> SelectActivitiesByGroupID(string groupID);
        int InsertUnapprovedPersonGroup(int personID, string groupID);
        List<string> SelectUnapprovedPersonGroups(int personID);
        int UpdatePersonGroupAsApproved(int personID, string groupID);
    }
}
