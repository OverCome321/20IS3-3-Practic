using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Cart
    {
        public int IdCart { get; set; }
        public int IdUser { get; set; }
        public int IdProduct { get; set; }
        public int ProductCount { get; set; }
        public bool IsDeleated { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
