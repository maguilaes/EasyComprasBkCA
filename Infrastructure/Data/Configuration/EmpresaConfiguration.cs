using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<NegEmpresas>
    {
        public void Configure(EntityTypeBuilder<NegEmpresas> builder)
        {
            builder.ToTable("NEGEmpresas");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.NitEmpresa).HasMaxLength(15);
            builder.Property(c => c.NombreEmpresa).HasMaxLength(250);
            builder.Property(c => c.Email).HasMaxLength(50).IsRequired(true);
            builder.Property(c => c.Leyenda).HasMaxLength(250);
            builder.Property(c => c.UrlLogo).HasMaxLength(1000);
            builder.Property(c => c.NombreContacto).HasMaxLength(250);
            builder.Property(c => c.TelefonoContacto).HasMaxLength(15);
            builder.Property(c => c.IdUsuarioRegistro).IsRequired(false);
            builder.Property(c => c.FechaRegistro).IsRequired(false);
            builder.Property(c => c.IdUsuarioModificacion).IsRequired(false);
            builder.Property(c => c.FechaModificacion).IsRequired(false);
            builder.Property(c => c.IdcCategoria).IsRequired(true);
            builder.Property(c => c.Estado).IsRequired(true); ;
            builder.Property(c => c.Ubicacion).IsRequired(true);
            builder.Property(c => c.Coordenadas).HasMaxLength(500);
        }
    }
}
