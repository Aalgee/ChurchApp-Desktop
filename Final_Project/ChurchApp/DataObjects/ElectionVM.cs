using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class ElectionVM : Election
    {
        public List<CandidateVM> MyProperty { get; set; }
    }
}
