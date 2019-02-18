using System;
using System.Threading;
using Core.Domain.Contract.Data.Specification;

namespace Core.Domain.Contract.Data.Repository.Identity.User.Specification
{
    public  class UsersSpecificationFactory 
    {
        private static readonly Lazy<UsersSpecificationFactory> _instance = new Lazy<UsersSpecificationFactory>(() => new UsersSpecificationFactory(), LazyThreadSafetyMode.ExecutionAndPublication);

        private UsersSpecificationFactory()
        {
        }

        public static UsersSpecificationFactory Instance => _instance.Value;




        #region Specification

        public ISpecification<Domain.Identity.AggregateRoot.User> UserPassMatchSpec(string username,string password)
        {
            return new UserPassMatchSpec(username, password);
        }
        public ISpecification<Domain.Identity.AggregateRoot.User> UserExistSpec(string username)
        {
            return new UserExistSpec(username);
        }

        #endregion



    }
       
}
