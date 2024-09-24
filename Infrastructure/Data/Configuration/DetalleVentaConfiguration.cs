using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class DetalleVentaConfiguration : IEntityTypeConfiguration<TrxDetalleVentas>
    {
        public void Configure(EntityTypeBuilder<TrxDetalleVentas> builder)
        {
            builder.ToTable("TRXDetalleVentas");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CodigoProducto).HasMaxLength(50).IsRequired(true);
            builder.Property(c => c.Nombre).HasMaxLength(100).IsRequired(true);
            builder.Property(c => c.Descripcion).HasMaxLength(200);
            builder.Property(c => c.IdMedida).IsRequired(true);
            builder.Property(c => c.PrecioUnitario).IsRequired(true);
            builder.Property(c => c.Cantidad).IsRequired(true);
            builder.Property(c => c.SubTotal).IsRequired(true);
            builder.Property(c => c.IdVenta).IsRequired(true);
        }
    }
}
