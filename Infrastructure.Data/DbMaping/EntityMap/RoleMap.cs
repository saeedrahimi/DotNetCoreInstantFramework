using Core.Domain.Identity.Poco;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.DbMaping.EntityMap
{
    public class RoleMap : BaseEntityMap<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).ValueGeneratedNever();
        }
    }
}
