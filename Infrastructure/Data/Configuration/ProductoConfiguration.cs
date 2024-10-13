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
            builder.Property(c => c.Codigo).HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(c => c.NombreProducto).HasColumnType("varchar(200)").IsRequired(true);
            builder.Property(c => c.Descripcion).HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(c => c.Stock).IsRequired(true);
            builder.Property(c => c.IdcMedida).IsRequired(true);
            builder.Property(c => c.PrecioCompra).HasColumnType("decimal(18, 2)").IsRequired(true);
            builder.Property(c => c.PrecioVenta).HasColumnType("decimal(18, 2)").IsRequired(true);
            builder.Property(c => c.UrlImagen).HasColumnType("varchar(1000)").IsRequired(false);
            builder.Property(c => c.IdUsuarioRegistro).IsRequired(false);
            builder.Property(c => c.FechaRegistro).IsRequired(false);
            builder.Property(c => c.IdUsuarioModificacion).IsRequired(false);
            builder.Property(c => c.FechaModificacion).IsRequired(false);
        }
    }
}
