using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class SpecProduct
    {
        public int IdSpecProduct { get; set; }
        public int Value { get; set; }
        public bool IsDeleated { get; set; }
        public int? IdSpecification { get; set; }
        public int? IdProduct { get; set; }

        public virtual Product? IdProductNavigation { get; set; }
        public virtual Specification? IdSpecificationNavigation { get; set; }
    }
}
