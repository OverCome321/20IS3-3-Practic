using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected WebShopContext Webshopcontext { get; set; }
        public RepositoryBase(WebShopContext webShopContext)
        {
            Webshopcontext = webShopContext;
        }
        public IQueryable<T> FindAll() => Webshopcontext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            Webshopcontext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => Webshopcontext.Set<T>().Add(entity);
        public void Update(T entity) => Webshopcontext.Set<T>().Update(entity);
        public void Delete(T entity) => Webshopcontext.Set<T>().Remove(entity);
    }
}
