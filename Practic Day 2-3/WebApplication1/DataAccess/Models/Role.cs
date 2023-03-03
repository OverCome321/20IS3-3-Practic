using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int IdRole { get; set; }
        public string? RoleName { get; set; }
        public bool IsDeleated { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
