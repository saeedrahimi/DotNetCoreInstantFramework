using Core.Entities.Identity;
using Infrastructure.Data.EF.DbMaping.EntityMap;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data.EF
{
    public class AppDbContext:DbContext
    {
    
        public  DbSet<User> Users { get; set; }
        public  DbSet<Role> Roles { get; set; }
        //public  DbSet<Token> Tokens { get; set; }



        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
        }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
            modelBuilder.ApplyConfiguration(new UserTokenMap());
        }

       
    }
}
