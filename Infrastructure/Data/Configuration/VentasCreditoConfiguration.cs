using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class VentasCreditoConfiguration : IEntityTypeConfiguration<TrxVentasCredito>
    {
        public void Configure(EntityTypeBuilder<TrxVentasCredito> builder)
        {
            builder.ToTable("TRXVentasCredito");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdcEstadoCredito).IsRequired(true);
            builder.Property(c => c.DeudaInicial).IsRequired(true);
            builder.Property(c => c.MontoPagado).IsRequired(true);
            builder.Property(c => c.DeudaActual).IsRequired(true);
            builder.Property(c => c.IdVenta).IsRequired(true);
            builder.Property(c => c.IdUsuarioRegistro).IsRequired(false);
            builder.Property(c => c.FechaRegistro).IsRequired(false);
            builder.Property(c => c.IdUsuarioModificacion).IsRequired(false);
            builder.Property(c => c.FechaModificacion).IsRequired(false);
        }
    }
}
