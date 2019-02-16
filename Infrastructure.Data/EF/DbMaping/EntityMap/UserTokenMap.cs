using Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EF.DbMaping.EntityMap
{
    public class UserTokenMap : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable("tbl_user_token");
            builder.HasKey(k => k.UserId);

          
        }
    }
}
