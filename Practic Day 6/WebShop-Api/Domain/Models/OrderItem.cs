using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class OrderItem
    {
        public int OrderItemsId { get; set; }
        public int OrderId { get; set; }
        public int ProductsId { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Products { get; set; } = null!;
    }
}
