using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayer;

namespace LogicLayer
{
    public interface IScheduleManager
    {
        List<PersonScheduleVM> RetrieveSchedule(int personID);
        bool EditActivitySchedule(ActivityVM oldSchedule, ActivityVM newSchedule);
        bool AddSchedule(Schedule schedule);
        bool DeactivateSchedule(int scheduleID);
        List<PersonScheduleVM> RetrieveUserScheduleByActivityID(int activityID, string activityType);
        List<ActivityVM> RetrieveAllUserSchedulesByUserIDAndType(int personID, string scheduleType);
    }
}
