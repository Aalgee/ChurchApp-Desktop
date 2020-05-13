using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;


namespace LogicLayer
{
    public interface IGroupManager
    {
        List<string> RetrieveGroupsByActivityID(int activityID);
        List<GroupActivityVM> RetrieveActivitiesByGroupID(string groupID);
        bool AddUnapprovedPersonGroup(int personID, string groupID);
        List<string> RetriveUnapprovedPersonGroups(int personID);
        bool EditPersonGroupAsApproved(int personID, string groupID);
    }
}
