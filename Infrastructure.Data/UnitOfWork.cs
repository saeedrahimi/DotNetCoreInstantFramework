using Core.Domain.Identity.Repository;
using Core.Domain._Shared.Data;

namespace Infrastructure.Data
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
