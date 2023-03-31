using DataAccess.Interfaces;
using DataAccess.Wrapper;

namespace DataAccess.Wrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        void Save();
    }
}
