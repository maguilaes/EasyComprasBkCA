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
            builder.Property(c => c.Telefono).HasMaxLength(20);
            builder.Property(c => c.Direccion).HasMaxLength(150);
            builder.Property(c => c.CodigoPostal).HasMaxLength(10);
            builder.Property(c => c.Coordenadas).HasMaxLength(500);
            builder.Property(c => c.Estado);
            builder.Property(c => c.IdRelacion);
        }
    }
}
