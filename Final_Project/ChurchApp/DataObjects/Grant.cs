using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Grant
    {
        public int GrantID { get; set; }
        public string GrantName { get; set; }
        public int Points { get; set; }
        public string Description { get; set; }
        public decimal AmountAskedFor { get; set; }
        public decimal AmountRecieved { get; set; }
        public bool Active { get; set; }
    }
}
