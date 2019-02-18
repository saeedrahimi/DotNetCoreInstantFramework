using System;
using System.Linq.Expressions;
using System.Threading;
using Core.Contract.Data.Specification;

namespace Core.Contract.Data.Repository.Identity.User.Specification
{
    internal sealed class UserPassMatchSpec:BaseSpecification<Domain.Identity.User>
    {     
        public UserPassMatchSpec(string username,string password)
        {
            Criteria = x => x.IsActive & (x.Email == username.Trim() || x.Mobile == username.Trim() && x.Password==password);
        }
 
    }
}
