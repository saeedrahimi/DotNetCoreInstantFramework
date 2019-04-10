using Core.Domain.Identity.Specification;
using Core.Domain._Shared.Data.Repository;

namespace Core.Domain.Identity.Repository
{
    public interface IUserRepository:IBaseRepository<AggregateRoot.User>
    {
         UsersSpecificationFactory SpecificationFactory { get; }
    }
}
