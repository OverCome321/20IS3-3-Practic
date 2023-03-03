using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int IdOrder { get; set; }
        public int IdUser { get; set; }
        public DateTime OrderDate { get; set; }
        public int IdStatus { get; set; }
        public bool IsDeleated { get; set; }

        public virtual Status IdStatusNavigation { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
