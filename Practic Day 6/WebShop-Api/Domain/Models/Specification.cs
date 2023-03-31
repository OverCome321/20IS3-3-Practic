using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Specification
    {
        public Specification()
        {
            SpecProducts = new HashSet<SpecProduct>();
        }

        public int SpecId { get; set; }
        public string Name { get; set; } = null!;
        public int Value { get; set; }
        public bool IsDeleted { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<SpecProduct> SpecProducts { get; set; }
    }
}
