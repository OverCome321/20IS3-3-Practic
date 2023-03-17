using DataAccess.Interfaces;
using Practic_Api_1.Models;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(WebShopContext repositoryContext) : base(repositoryContext) 
        { 
        }
    }
}
