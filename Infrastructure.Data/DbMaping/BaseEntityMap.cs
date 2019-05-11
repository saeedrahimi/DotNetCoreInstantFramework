using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.DbMaping
{
    public abstract class BaseEntityMap<T> : IEntityTypeConfiguration<T> where T : class
    {

        internal readonly ValueConverter<string, string> EncryptedConverter;
        //internal readonly ValueConverter<DateTime, string> DateTimeConverter;


        public BaseEntityMap()
        {
            EncryptedConverter = new ValueConverter<string, string>(
                convertToProviderExpression: v => new string(v.Reverse().ToArray()), // encrypt
                convertFromProviderExpression: v => new string(v.Reverse().ToArray()) // decrypt
            );

            //DateTimeConverter = new ValueConverter<DateTime, string>(
            //    convertToProviderExpression: v => new string(""), //to shamsi
            //    convertFromProviderExpression: v => new DateTime(2012,01,01) // to miladi
            //);
        }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable($"tbl_{typeof(T).Name}");
        }


        
    }
}
