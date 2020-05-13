using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataObjects;

namespace LogicLayer
{
    public interface IFacilityManager
    {
        List<Facility> RetrieveAllFacilitiesByActive(bool active = true);
        bool AddFacility(Facility facility);
        bool EditFacility(Facility oldFacility, Facility newFacility);
    }
}
