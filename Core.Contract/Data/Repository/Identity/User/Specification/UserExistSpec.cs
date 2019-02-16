using System;
using System.Collections.Generic;
using System.Text;
using Core.Contract.Data.Specification;

namespace Core.Contract.Data.Repository.Identity.User.Specification
{
    public class UserExistSpec : BaseSpecification<Entities.Identity.User>
    {

        public UserExistSpec(string username)
        {
            Criteria = x => x.Email == username.Trim() || x.Mobile == username.Trim();
        }
    }
}
