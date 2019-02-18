using Core.Domain.Identity;
using Core.Domain.Identity.AggregateRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EF.DbMaping.EntityMap
{
    public class UserMap : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tbl_user");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();


          

        }
    }
}
