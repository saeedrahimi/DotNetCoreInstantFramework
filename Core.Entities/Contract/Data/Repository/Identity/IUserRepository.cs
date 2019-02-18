using Core.Domain.Identity.Specification;

namespace Core.Domain.Contract.Data.Repository.Identity.User
{
    public interface IUserRepository:IBaseRepository<Domain.Identity.AggregateRoot.User>
    {
         UsersSpecificationFactory SpecificationFactory { get; }
    }
}
