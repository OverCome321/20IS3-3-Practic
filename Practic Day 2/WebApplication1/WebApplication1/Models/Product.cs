using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
            SpecProducts = new HashSet<SpecProduct>();
        }

        public int IdProduct { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsDeleated { get; set; }
        public int? IdCategories { get; set; }

        public virtual Category? IdCategoriesNavigation { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<SpecProduct> SpecProducts { get; set; }
    }
}
