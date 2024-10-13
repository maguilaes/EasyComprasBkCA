using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class BaseCiudadConfiguration : IEntityTypeConfiguration<BaseCiudades>
    {
        public void Configure(EntityTypeBuilder<BaseCiudades> builder)
        {
            builder.ToTable("BASCiudades");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Ciudad).HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(c => c.Estado);
            builder.Property(c => c.IdcPais);
        }
    }
}
