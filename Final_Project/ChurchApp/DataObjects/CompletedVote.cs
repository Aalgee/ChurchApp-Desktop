using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class CompletedVote
    {
        public int CompletedVoteID { get; set; }
        public int PersonID { get; set; }
        public int ElectionID { get; set; }
        public bool HasVoted { get; set; }
    }
}
