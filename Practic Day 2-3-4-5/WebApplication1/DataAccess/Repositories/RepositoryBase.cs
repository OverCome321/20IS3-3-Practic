using System.Linq.Expressions;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Practic_Api_1.Models;

namespace DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected WebShopContext RepositoryContext { get; set; }
        public RepositoryBase(WebShopContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
    }
}
