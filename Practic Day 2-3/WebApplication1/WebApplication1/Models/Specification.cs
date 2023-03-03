using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Specification
    {
        public Specification()
        {
            SpecProducts = new HashSet<SpecProduct>();
        }

        public int IdSpecification { get; set; }
        public string SpecName { get; set; } = null!;
        public int SpecValue { get; set; }
        public bool IsDeleated { get; set; }
        public int? IdCategories { get; set; }

        public virtual Category? IdCategoriesNavigation { get; set; }
        public virtual ICollection<SpecProduct> SpecProducts { get; set; }
    }
}
