﻿using Core.Domain.Identity.Poco;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.DbMaping.EntityMap
{
    public class UserTokenMap : BaseEntityMap<UserToken>
    {
        public override void Configure(EntityTypeBuilder<UserToken> builder)
        {
            base.Configure(builder);
            builder.HasKey(k => k.UserId);
        }
    }
}
