using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Candidate
    {
        public int CandidateID { get; set; }
        public int PersonID { get; set; }
        public int ElectionID { get; set; }
        public int Votes { get; set; }
        public bool Active { get; set; }
    }
}
