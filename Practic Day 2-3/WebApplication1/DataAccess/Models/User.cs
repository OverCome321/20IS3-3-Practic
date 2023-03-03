using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
        }

        public int IdUser { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }
        public int IdRole { get; set; }
        public bool IsDeleated { get; set; }

        public virtual Role IdRoleNavigation { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
