using System;
using System.Runtime.InteropServices;
using Castle.DynamicProxy.Generators.Emitters.CodeBuilders;
using Core.Domain.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Win32.SafeHandles;

namespace Infrastructure.Data.EF.DbMaping
{
    public abstract class BaseEntityMap<T> : IEntityTypeConfiguration<T> where T : class
    {
        public BaseEntityMap()
        {
        }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable($"tbl_{typeof(T).Name}");
        }

    }
}
