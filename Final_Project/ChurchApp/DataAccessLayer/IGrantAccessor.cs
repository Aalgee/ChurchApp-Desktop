using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayer
{
    public interface IGrantAccessor
    {
        int InsertGrant(Grant grant);
        List<Grant> SelectAllGrantsByActive(bool active);
        int UpdateGrand(Grant oldGrant, Grant newGrant);
        int DeactivateGrant(Grant grant);
    }
}
