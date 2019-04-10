using Core.Domain._Shared.Data.Specification;

namespace Core.Domain.Identity.Specification
{
    public class UserExistSpec : BaseSpecification<AggregateRoot.User>
    {

        public UserExistSpec(string username)
        {
            Criteria = x => x.Email == username.Trim() || x.Mobile == username.Trim();
        }
    }
}
