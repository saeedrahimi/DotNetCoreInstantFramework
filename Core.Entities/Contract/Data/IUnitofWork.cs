using Core.Domain.Contract.Data.Repository.Identity.User;
using Core.Domain.Contract.Ioc;

namespace Core.Domain.Contract.Data
{
    public interface IUnitofWork//:IDisposable
    {
        [ImportProperty]
        IUserRepository UserRepository { get; set; }
        void SaveChange();

    }
}
