using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class VentasTransferenciaConfiguration : IEntityTypeConfiguration<TrxVentasTransferencia>
    {
        public void Configure(EntityTypeBuilder<TrxVentasTransferencia> builder)
        {
            builder.ToTable("TRXVentasTransferencia");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdcEstadoTransferencia).IsRequired(true);
            builder.Property(c => c.IdCliente).IsRequired(true);
            builder.Property(c => c.MontoTransferencia).HasColumnType("decimal(18, 2)").IsRequired(true);
            builder.Property(c => c.UrlComprobante).HasColumnType("varchar(1000)").IsRequired(false);
            builder.Property(c => c.MontoRecibido).HasColumnType("decimal(18, 2)").IsRequired(true);
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
