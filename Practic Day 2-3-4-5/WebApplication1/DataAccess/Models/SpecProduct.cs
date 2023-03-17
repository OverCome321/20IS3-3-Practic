using System;
using System.Collections.Generic;

namespace Practic_Api_1.Models
{
    public partial class SpecProduct
    {
        public int SpecProdId { get; set; }
        public bool IsDeleted { get; set; }
        public int? SpecId { get; set; }
        public int? ProductsId { get; set; }

        public virtual Product? Products { get; set; }
        public virtual Specification? Spec { get; set; }
    }
}
