using System;
using System.Linq.Expressions;
using System.Threading;
using Core.Contract.Data.Specification;

namespace Core.Contract.Data.Repository.Identity.User.Specification
{
    public  class UsersSpecificationFactory 
    {
        private static readonly Lazy<UsersSpecificationFactory> _instance = new Lazy<UsersSpecificationFactory>(() => new UsersSpecificationFactory(), LazyThreadSafetyMode.ExecutionAndPublication);

        private UsersSpecificationFactory()
        {
        }

        public static UsersSpecificationFactory Instance => _instance.Value;




        #region Specification

        public ISpecification<Entities.Identity.User> UserPassMatchSpec(string username,string password)
        {
            return new UserPassMatchSpec(username, password);
        }
        public ISpecification<Entities.Identity.User> UserExistSpec(string username)
        {
            return new UserExistSpec(username);
        }

        #endregion



    }
       
}
