namespace WebShop_Api.Contracts.User
{
    public class CreateUserRequest
    {
        public string Email { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public bool IsDeleted { get; set; }
        public string Adress { get; set; } = null!;
    }
}
