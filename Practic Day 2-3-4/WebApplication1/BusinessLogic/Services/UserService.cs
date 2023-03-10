using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public Task<List<User>> GetAll()
        {
            return _repositoryWrapper.User.FindAll().ToListAsync();
        }
        public Task<User> GetById(int id)
        {
            var user = _repositoryWrapper.User
            .FindByCondition(x => x.IdUser == id).First();
            return Task.FromResult(user);
        }
        public Task Create(User model)
        {
            _repositoryWrapper.User.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Update(User model)
        {
            _repositoryWrapper.User.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Delete(int id)
        {
            var user = _repositoryWrapper.User
            .FindByCondition(x => x.IdUser == id).First();
            _repositoryWrapper.User.Delete(user);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}