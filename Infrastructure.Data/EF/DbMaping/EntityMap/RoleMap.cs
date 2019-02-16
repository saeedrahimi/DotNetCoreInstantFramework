
using Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EF.DbMaping.EntityMap
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("tbl_role");
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).ValueGeneratedNever();
        }
    }
}
