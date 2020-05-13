using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayer;

namespace LogicLayer
{
    public class ScheduleManager : IScheduleManager
    {
        private IScheduleAccessor _scheduleAccessor;

        // This is the no argument constructor.
        public ScheduleManager()
        {
            _scheduleAccessor = new ScheduleAccessor();
        }

        // This is the full constructor
        public ScheduleManager(IScheduleAccessor scheduleAccessor)
        {
            _scheduleAccessor = scheduleAccessor;
        }

        // This calls the accessor method that inserts a schedule into the database.
        public bool AddSchedule(Schedule schedule)
        {
            bool result = false;
            try
            {
                result = (1 == _scheduleAccessor.InsertSchedule(schedule));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Schedule not Added", ex);
            }
            return result;
        }

        // This calls the accessor method that deactivates a schedule that is in the database.
        public bool DeactivateSchedule(int scheduleID)
        {
            bool result = false;
            try
            {
                result = (1 == _scheduleAccessor.DeactivateSchedule(scheduleID));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Schedule not Deactivated", ex);
            }
            return result;
        }

        // This calls the accessor method that updates an activity in the database
        public bool EditActivitySchedule(ActivityVM oldSchedule, ActivityVM newSchedule)
        {
            bool result = false;
            try
            {
                result = 1 == _scheduleAccessor.UpdateActivitySchedule(oldSchedule, newSchedule);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Activity schedule not updated", ex);
            }
            return result;
        }

        // This calls the accessor method that selects a list of activity view models from the database
        public List<ActivityVM> RetrieveAllUserSchedulesByUserIDAndType(int personID, string scheduleType)
        {
            List<ActivityVM> activities = null;
            try
            {
                activities = _scheduleAccessor.SelectUserSchedulesByUserIDAndType(personID, scheduleType, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return activities;
        }

        // This calls the accessor method that selects a list of person schedule view models by personID.
        public List<PersonScheduleVM> RetrieveSchedule(int personID)
        {
            List<PersonScheduleVM> schedules = null;
            try
            {
                schedules = _scheduleAccessor.SelectSchedulesByPersonID(personID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not Found.", ex);
            }
            return schedules;
        }

        // This calls the accessor method that selects a list of person schedule view models based upon the activityID and activity type provided.
        public List<PersonScheduleVM> RetrieveUserScheduleByActivityID(int activityID, string activityType)
        {
            List<PersonScheduleVM> schedules = null;
            try
            {
                schedules = _scheduleAccessor.SelectUserScheduleByActivityID(activityID, activityType, true);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not Found.", ex);
            }
            return schedules;
        }
    }
}
