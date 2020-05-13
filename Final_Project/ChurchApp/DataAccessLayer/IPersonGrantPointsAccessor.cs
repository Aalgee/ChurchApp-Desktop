using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayer
{
    interface IPersonGrantPointsAccessor
    {
        int InsertPersonGrantPoints();
        PersonGrantPointsVM SelectPersonGrantPointsByPersonID(int personID);
        int UpdatePersonGrantPoints(PersonGrantPoints oldPersonGrantPoints, PersonGrantPoints newPersonGrantPoints);

    }
}
