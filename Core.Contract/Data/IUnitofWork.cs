using System;
using Core.Contract.Data.Repository.Identity.User;
using Core.Contract.Ioc;

namespace Core.Contract.Data
{
    public interface IUnitofWork//:IDisposable
    {
        [ImportProperty]
        IUserRepository UserRepository { get; set; }
        void SaveChange();

    }
}
