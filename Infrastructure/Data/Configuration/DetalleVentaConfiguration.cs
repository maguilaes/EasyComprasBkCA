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
            builder.Property(c => c.CodigoProducto).HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(c => c.Nombre).HasColumnType("varchar(150)").IsRequired(true);
            builder.Property(c => c.Descripcion).HasColumnType("varchar(300)").IsRequired(false);
            builder.Property(c => c.IdMedida).IsRequired(true);
            builder.Property(c => c.PrecioUnitario).HasColumnType("decimal(18, 2)").IsRequired(true);
            builder.Property(c => c.Cantidad).IsRequired(true);
            builder.Property(c => c.SubTotal).HasColumnType("decimal(18, 2)").IsRequired(true);
            builder.Property(c => c.IdVenta).IsRequired(true);
        }
    }
}
