using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private WebShopContext Webshopcontext;
        private IUserRepository _user;
        public IUserRepository User
        {
            get
            {
                if (User == null)
                {
                    _user = new UserRepository(Webshopcontext);
                }
                return _user;
            }
        }
        public RepositoryWrapper(WebShopContext _context)
        {
            Webshopcontext = _context;
        }
        public void Save()
        {
            Webshopcontext.SaveChanges();
        }
    }
}
