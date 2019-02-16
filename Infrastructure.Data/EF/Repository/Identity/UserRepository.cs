using Core.Contract.Data.Repository.Identity.User;
using Core.Contract.Data.Repository.Identity.User.Specification;
using Core.Entities.Identity;


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
