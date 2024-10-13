using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class VentaConfiguration : IEntityTypeConfiguration<TrxVentas>
    {
        public void Configure(EntityTypeBuilder<TrxVentas> builder)
        {
            builder.ToTable("TRXVentas");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdCliente).IsRequired(true);
            builder.Property(c => c.Coordenadas).HasColumnType("varchar(250)").IsRequired(false);
            builder.Property(c => c.IdUsuarioRegistro).IsRequired(false);
            builder.Property(c => c.FechaRegistro).IsRequired(false);
            builder.Property(c => c.IdUsuarioModificacion).IsRequired(false);
            builder.Property(c => c.FechaModificacion).IsRequired(false);
            builder.Property(c => c.IdcFormaEntrega).IsRequired(true);
            builder.Property(c => c.IdcFormaPago).IsRequired(true);
            builder.Property(c => c.IdcEstadoPago).IsRequired(true);
            builder.Property(c => c.IdcEstadoVenta).IsRequired(true);
            builder.Property(c => c.IdSucursal).IsRequired(true);
            builder.Property(c => c.Estado).IsRequired(true);
            builder.Property(c => c.MontoVenta).HasColumnType("decimal(18, 2)").IsRequired(true);
        }
    }
}
