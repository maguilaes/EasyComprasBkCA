using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class SucursalConfiguration : IEntityTypeConfiguration<NegSucursales>
    {
        public void Configure(EntityTypeBuilder<NegSucursales> builder)
        {
            builder.ToTable("NEGSucursales");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.NombreSucursal).HasMaxLength(250);
            builder.Property(c => c.IdUsuarioRegistro).IsRequired(false);
            builder.Property(c => c.FechaRegistro).IsRequired(false);
            builder.Property(c => c.IdUsuarioModificacion).IsRequired(false);
            builder.Property(c => c.FechaModificacion).IsRequired(false);
            builder.Property(c => c.Estado).IsRequired(true); ;
            builder.Property(c => c.IdEmpresa).IsRequired(true);
        }
    }
}