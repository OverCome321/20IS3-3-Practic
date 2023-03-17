using System;
using System.Collections.Generic;

namespace Practic_Api_1.Models
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
        }

        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public bool IsDeleted { get; set; }
        public string Adress { get; set; } = null!;

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
