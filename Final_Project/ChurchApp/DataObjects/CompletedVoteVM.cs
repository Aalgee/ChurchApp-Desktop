using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class CompletedVoteVM : CompletedVote
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
