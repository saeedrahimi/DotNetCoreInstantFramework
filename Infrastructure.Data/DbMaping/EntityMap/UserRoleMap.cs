using Core.Domain.Identity.Poco;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.DbMaping.EntityMap
{
    public class UserRoleMap : BaseEntityMap<UserRoles>
    {
        public override void Configure(EntityTypeBuilder<UserRoles> builder)
        {

            base.Configure(builder);

            builder.HasKey(t => new { t.UserId, t.RoleId });

            builder
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(pt => pt.UserId);

            builder
                .HasOne(pt => pt.Role)
                .WithMany(t => t.UserRoles)
                .HasForeignKey(pt => pt.RoleId);
        }
    }
}
