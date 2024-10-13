using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class BaseCuentaPagoConfiguration : IEntityTypeConfiguration<NegCuentaPagos>
    {
        public void Configure(EntityTypeBuilder<NegCuentaPagos> builder)
        {
            builder.ToTable("NEGCuentaPagos");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.NroCuentaPagos).HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(c => c.BancoPagos).HasColumnType("varchar(250)").IsRequired(true);
            builder.Property(c => c.NombreTitular).HasColumnType("varchar(150)").IsRequired(true);
            builder.Property(c => c.DocumentoTitular).HasColumnType("varchar(20)").IsRequired(true);
            builder.Property(c => c.UrlQr).HasColumnType("varchar(1000)").IsRequired(true);
            builder.Property(c => c.Estado);
            builder.Property(c => c.IdSucursal).IsRequired(true);
            builder.Property(c => c.IdUsuarioRegistro).IsRequired(false);
            builder.Property(c => c.FechaRegistro).IsRequired(false);
            builder.Property(c => c.IdUsuarioModificacion).IsRequired(false);
            builder.Property(c => c.FechaModificacion).IsRequired(false);
        }
    }
}
