using Core.Domain.Contract.Data.Specification;

namespace Core.Domain.Identity.Specification
{
    internal sealed class UserPassMatchSpec:BaseSpecification<Domain.Identity.AggregateRoot.User>
    {     
        public UserPassMatchSpec(string username,string password)
        {
            Criteria = x => x.IsActive & (x.Email == username.Trim() || x.Mobile == username.Trim() && x.Password==password);
        }
 
    }
}
