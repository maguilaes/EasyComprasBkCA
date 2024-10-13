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
            builder.Property(c => c.NitEmpresa).HasColumnType("varchar(20)").IsRequired(true);
            builder.Property(c => c.NombreEmpresa).HasColumnType("varchar(250)").IsRequired(true);
            builder.Property(c => c.Email).HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(c => c.Leyenda).HasColumnType("varchar(250)").IsRequired(false);
            builder.Property(c => c.UrlLogo).HasColumnType("varchar(1000)").IsRequired(false);
            builder.Property(c => c.NombreContacto).HasColumnType("varchar(250)").IsRequired(true);
            builder.Property(c => c.TelefonoContacto).HasColumnType("varchar(20)").IsRequired(false);
            builder.Property(c => c.IdUsuarioRegistro).IsRequired(false);
            builder.Property(c => c.FechaRegistro).IsRequired(false);
            builder.Property(c => c.IdUsuarioModificacion).IsRequired(false);
            builder.Property(c => c.FechaModificacion).IsRequired(false);
            builder.Property(c => c.IdcCategoria).IsRequired(true);
            builder.Property(c => c.Estado).IsRequired(true); ;
            builder.Property(c => c.Ubicacion).IsRequired(true);
            builder.Property(c => c.Coordenadas).HasColumnType("varchar(500)").IsRequired(false);
        }
    }
}
