using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<NegProductos>
    {
        public void Configure(EntityTypeBuilder<NegProductos> builder)
        {
            builder.ToTable("NEGProductos");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdSucursal).IsRequired(true);
            builder.Property(c => c.IdcCategoria).IsRequired(true);
            builder.Property(c => c.Codigo).HasMaxLength(50).IsRequired(true);
            builder.Property(c => c.NombreProducto).HasMaxLength(100).IsRequired(true);
            builder.Property(c => c.Descripcion).HasMaxLength(200);
            builder.Property(c => c.Stock).IsRequired(true);
            builder.Property(c => c.IdcMedida).IsRequired(true);
            builder.Property(c => c.PrecioCompra).IsRequired(true);
            builder.Property(c => c.PrecioVenta).IsRequired(true);
            builder.Property(c => c.UrlImagen).IsRequired(false);
            builder.Property(c => c.IdUsuarioRegistro).IsRequired(false);
            builder.Property(c => c.FechaRegistro).IsRequired(false);
            builder.Property(c => c.IdUsuarioModificacion).IsRequired(false);
            builder.Property(c => c.FechaModificacion).IsRequired(false);
        }
    }
}
