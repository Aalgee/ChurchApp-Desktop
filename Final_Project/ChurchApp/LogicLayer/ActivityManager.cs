using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayer;

namespace LogicLayer
{
    public class ActivityManager : IActivityManager
    {
        private IActivityAccessor _activityAccessor;

        // This is the no argument consrtuctor
        public ActivityManager()
        {
            _activityAccessor = new ActivityAccessor();
        }

        // This is the full constructor
        public ActivityManager(IActivityAccessor activityAccessor)
        {
            _activityAccessor = activityAccessor;
        }

        // This adds an activity from the presentation to the data access layer.
        public int AddActivity(ActivityVM activity)
        {
            int identity;
            try
            {
                identity = _activityAccessor.InsertActivity(activity);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Activity not Added!", ex);
            }
            return identity;
        }

        // This adds an activity schedule from the presentation to the data access layer.
        public int AddActivitySchedule(int activityID, DateTime start, DateTime end)
        {
            int identity;
            try
            {
                identity = (_activityAccessor.InsertActivitySchedule(activityID, start, end));
            }
            catch (Exception)
            {

                throw;
            }
            return identity;
        }

        // This adds a group activity from the presentation to the data access layer.
        public bool AddGroupActivity(int activityID, string groupID)
        {
            bool result = false;
            try
            {
                result = (1 == _activityAccessor.InsertGroupActivity(activityID, groupID));
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Activity not Added!", ex);
            }
            return result;
        }

        // This adds a person activity from the presentation to the data access layer.
        public bool AddPersonActivity(int personID, int activityID)
        {
            bool result = false;
            try
            {
                result = (1 == _activityAccessor.InsertPersonActivity(personID, activityID));
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Activity not Added!", ex);
            }
            return result;
        }

        // This calls the accessor method that deletes a group activity from the database.
        public bool DeleteGroupActivity(int activityID, string groupID)
        {
            bool result = false;
            try
            {
                result = (1 == _activityAccessor.DeleteGroupActivity(activityID, groupID));
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Activity not deleted!", ex);
            }
            return result;
        }

        // This calls the accessor method that deletes a person activity from the database.
        public bool DeletePersonActivity(int personID, int activityID)
        {
            bool result = false;
            try
            {
                result = (1 == _activityAccessor.DeletePersonActivity(personID, activityID));
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Activity not deleted!", ex);
            }
            return result;
        }

        // This call the accessor method that updates an activity in the database.
        public bool EditActivity(ActivityVM oldActivity, ActivityVM newActivity)
        {
            {
                bool result = false;
                try
                {
                    result = 1 == _activityAccessor.UpdateActivity(oldActivity, newActivity);
                }
                catch (Exception ex)
                {

                    throw new ApplicationException("Update failed", ex);
                }

                return result;
            }
        }

        // This calls the accessor method that returns a list of activity view models from the database.
        // They are returned based on if they are an activity schedule
        public List<ActivityVM> RetrieveActivitiesByActivitySchedule(bool activitySchedule = true)
        {
            List<ActivityVM> activities = null;
            try
            {
                activities = _activityAccessor.SelectActivitiesByActivitySchedule(activitySchedule);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return activities;
        }
        
        // This calls the accessor method that returns a list of activity view models from the database.
        // They are returned based on the personID supplied
        public List<ActivityVM> RetrieveActivitiesByPersonID(int personID, bool activitySchedule = true)
        {
            List<ActivityVM> activities = null;
            try
            {
                activities = _activityAccessor.SelectActivitiesByPersonID(personID, activitySchedule);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Activity not found!", ex);
            }
            return activities;
        }

        // This calls the accessor method that returns a list of activity view models from the database.
        // They are returned based on personID and schedule type.
        public List<ActivityVM> RetrieveActivitiesByScheduleType(int personID, string scheduleType)
        {
            List<ActivityVM> activities = null;
            try
            {
                activities = _activityAccessor.SelectActivitiesByScheduleType(personID, scheduleType);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Activity not found!", ex);
            }
            return activities; throw new NotImplementedException();
        }

        // This calls the accessor method that returns a list of all the activity view models from the database.
        public List<ActivityVM> RetrieveAllActivitySchedulesByActive()
        {
            List<ActivityVM> activities = null;
            try
            {
                activities = _activityAccessor.SelectAllActivitySchedulesByActive(true);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Activity not found!", ex);
            }
            return activities;
        }

        // This calls the accessor method that returns all activity types from the database.
        public List<string> RetrieveAllActivityTypes()
        {
            List<string> activityTypes = null;
            try
            {
                activityTypes = _activityAccessor.SelectAllActivityTypes();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Activity types not found!", ex);
            }


            return activityTypes;
        }

        // This calls the accessor method that returns a list of all the group activity view models.
        public List<GroupActivityVM> RetrieveAllGroupActivities()
        {
            List<GroupActivityVM> activities = null;
            try
            {
                activities = _activityAccessor.SelectAllGroupActivities();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Activity not found!", ex);
            }
            return activities;
        }
    }
}
