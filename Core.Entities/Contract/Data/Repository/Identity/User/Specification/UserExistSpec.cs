using Core.Domain.Contract.Data.Specification;

namespace Core.Domain.Contract.Data.Repository.Identity.User.Specification
{
    public class UserExistSpec : BaseSpecification<Domain.Identity.AggregateRoot.User>
    {

        public UserExistSpec(string username)
        {
            Criteria = x => x.Email == username.Trim() || x.Mobile == username.Trim();
        }
    }
}
