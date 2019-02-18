﻿using Core.Contract.Data.Repository.Identity.User.Specification;

namespace Core.Contract.Data.Repository.Identity.User
{
    public interface IUserRepository:IBaseRepository<Domain.Identity.User>
    {
         UsersSpecificationFactory SpecificationFactory { get; }
    }
}
