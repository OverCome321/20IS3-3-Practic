using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Status
    {
        public Status()
        {
            Orders = new HashSet<Order>();
        }

        public int IdStatus { get; set; }
        public string StatusName { get; set; } = null!;
        public bool IsDeleated { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
