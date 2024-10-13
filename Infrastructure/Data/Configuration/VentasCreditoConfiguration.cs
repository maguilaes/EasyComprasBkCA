using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class VentasCreditoConfiguration : IEntityTypeConfiguration<TrxVentasCredito>
    {
        public void Configure(EntityTypeBuilder<TrxVentasCredito> builder)
        {
            builder.ToTable("TRXVentasCreditos");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdcEstadoCredito).IsRequired(true);
            builder.Property(c => c.IdCliente).IsRequired(true);
            builder.Property(c => c.DeudaInicial).HasColumnType("decimal(18, 2)").IsRequired(true);
            builder.Property(c => c.MontoPagado).HasColumnType("decimal(18, 2)").IsRequired(true);
            builder.Property(c => c.DeudaActual).HasColumnType("decimal(18, 2)").IsRequired(true);
            builder.Property(c => c.Comentarios).HasColumnType("varchar(1000)").IsRequired(false);
            builder.Property(c => c.IdVenta).IsRequired(true);
            builder.Property(c => c.IdUsuarioRegistro).IsRequired(false);
            builder.Property(c => c.FechaRegistro).IsRequired(false);
            builder.Property(c => c.IdUsuarioModificacion).IsRequired(false);
            builder.Property(c => c.FechaModificacion).IsRequired(false);
            builder.Property(c => c.Estado).IsRequired(true);
        }
    }
}
