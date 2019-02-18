using Core.Domain.Contract.Data.Specification;

namespace Core.Domain.Identity.Specification
{
    public class UserExistSpec : BaseSpecification<Domain.Identity.AggregateRoot.User>
    {

        public UserExistSpec(string username)
        {
            Criteria = x => x.Email == username.Trim() || x.Mobile == username.Trim();
        }
    }
}
