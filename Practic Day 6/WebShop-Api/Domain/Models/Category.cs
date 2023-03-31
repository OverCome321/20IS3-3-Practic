using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
            Specifications = new HashSet<Specification>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Specification> Specifications { get; set; }
    }
}
