using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<SegUsuarios>
    {
        public void Configure(EntityTypeBuilder<SegUsuarios> builder)
        {
            builder.ToTable("SEGUsuarios");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.NombreCompleto).HasColumnType("varchar(150)").IsRequired(true);
            builder.Property(c => c.Email).HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(c => c.Clave).HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(c => c.IdcRol).IsRequired(true);
            builder.Property(c => c.IdEmpresa).IsRequired(true);
            builder.Property(c => c.IdSucursal).IsRequired(true);
            builder.Property(c => c.Estado).IsRequired(true);
            builder.Property(c => c.FechaRegistro).IsRequired(false);
            builder.Property(c => c.FechaModificacion).IsRequired(false);

        }
    }
}
