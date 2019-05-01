using Core.Domain.Identity.AggregateRoot;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.DbMaping.EntityMap
{
    public class UserMap : BaseEntityMap<User>
    {

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.Property(p => p.Mobile).HasConversion(base.EncryptedConverter);
        }
    }
}
