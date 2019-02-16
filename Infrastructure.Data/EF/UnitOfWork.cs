using Core.Contract.Data;
using Core.Contract.Data.Repository.Identity;
using Core.Contract.Data.Repository.Identity.User;


namespace Infrastructure.Data.EF
{
    public class UnitOfWork : IUnitofWork
    {

        private readonly AppDbContext _dbcontext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
            
        }
      
        public IUserRepository UserRepository { get; set; }


        public void SaveChange()
        {
            _dbcontext.SaveChanges();
        }
    }
}
