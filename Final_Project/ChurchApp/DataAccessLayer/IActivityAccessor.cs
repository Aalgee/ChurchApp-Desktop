using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayer
{
    public interface IActivityAccessor
    {
        List<ActivityVM> SelectActivitiesByActivitySchedule(bool activitySchedule);

        List<ActivityVM> SelectActivitiesByPersonID(int personID, bool activitySchedule);
        int DeletePersonActivity(int personID, int activityID);
        int InsertPersonActivity(int personID, int activityID);
        List<string> SelectAllActivityTypes();
        int InsertActivity(ActivityVM activity);
        int InsertActivitySchedule(int activityID, DateTime start, DateTime end);
        int UpdateActivity(ActivityVM oldActivity, ActivityVM newActivity);
        int DeleteGroupActivity(int activityID, string groupID);
        List<GroupActivityVM> SelectAllGroupActivities();
        int InsertGroupActivity(int activityID, string groupID);
        List<ActivityVM> SelectActivitiesByScheduleType(int personID, string scheduleType);
        List<ActivityVM> SelectAllActivitySchedulesByActive(bool active = true);
    }
}
