using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data
{
    class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer("Server=.;Database=DotNetCoreInstantFramework;User Id=sa;Password=1234");
            
            return new AppDbContext(builder.Options);
        }
    }
}
