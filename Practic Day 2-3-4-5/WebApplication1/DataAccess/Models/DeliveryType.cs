using System;
using System.Collections.Generic;

namespace Practic_Api_1.Models
{
    public partial class DeliveryType
    {
        public DeliveryType()
        {
            Orders = new HashSet<Order>();
        }

        public int DeliveryTypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
