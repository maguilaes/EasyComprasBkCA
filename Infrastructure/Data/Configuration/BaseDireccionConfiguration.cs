using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class BaseDireccionConfiguration : IEntityTypeConfiguration<BaseDirecciones>
    {
        public void Configure(EntityTypeBuilder<BaseDirecciones> builder)
        {
            builder.ToTable("BASDirecciones");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdcPais).HasMaxLength(30);
            builder.Property(c => c.IdcCiudad).HasMaxLength(30);
            builder.Property(c => c.Telefono).HasColumnType("varchar(20)").IsRequired();
            builder.Property(c => c.Direccion).HasColumnType("varchar(150)").IsRequired(true);
            builder.Property(c => c.CodigoPostal).HasColumnType("varchar(10)").IsRequired(true);
            builder.Property(c => c.Coordenadas).HasColumnType("varchar(500)").IsRequired();
            builder.Property(c => c.Estado);
            builder.Property(c => c.IdRelacion);
        }
    }
}
