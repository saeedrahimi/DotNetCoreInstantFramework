using Core.Domain.Identity.AggregateRoot;
using Core.Domain.Identity.Repository;
using Core.Domain.Identity.Specification;


namespace Infrastructure.Data.EF.Repository.Identity
{
    public class UserRepository:BaseRepository<User>,IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public UsersSpecificationFactory SpecificationFactory => UsersSpecificationFactory.Instance;


      

    }
}
