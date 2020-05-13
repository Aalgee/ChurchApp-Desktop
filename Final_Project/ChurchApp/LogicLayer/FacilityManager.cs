using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataObjects;


namespace LogicLayer
{
    public class FacilityManager : IFacilityManager
    {
        IFacilityAccessor _facilityAccessor;

        // This is the no argument constructor.
        public FacilityManager()
        {
            _facilityAccessor = new FacilityAccessor();
        }

        // This is the full constructor.
        public FacilityManager(IFacilityAccessor facilityAccessor)
        {
            _facilityAccessor = facilityAccessor;
        }

        // This calls the accessor method that inserts a facility into the database.
        public bool AddFacility(Facility facility)
        {
            bool result = false;
            try
            {
                result = (1 == _facilityAccessor.InsertFacility(facility));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        // This calls the accessor method that updates a facility in the database.
        public bool EditFacility(Facility oldFacility, Facility newFacility)
        {
            bool result = false;
            try
            {
                result = (1 == _facilityAccessor.UpdateFacility(oldFacility, newFacility));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        // This calls the accessor method that selects a list of active facilities from the database.
        public List<Facility> RetrieveAllFacilitiesByActive(bool active = true)
        {
            List<Facility> facilities = new List<Facility>();
            try
            {
                facilities = _facilityAccessor.SelectAllFacilitiesByActive(active);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return facilities;
        }
    }
}
