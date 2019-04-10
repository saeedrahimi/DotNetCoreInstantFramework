using Core.Domain.Identity.Repository;
using Core.Domain._Shared.Ioc;

namespace Core.Domain._Shared.Data
{
    public interface IUnitofWork//:IDisposable
    {
        [ImportProperty]
        IUserRepository UserRepository { get; set; }
        void SaveChange();

    }
}
