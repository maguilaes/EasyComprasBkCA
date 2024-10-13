using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class TipoConfiguration : IEntityTypeConfiguration<BaseTipos>
{
    public void Configure(EntityTypeBuilder<BaseTipos> builder)
    {
        builder.ToTable("BASTipos");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Descripcion).HasColumnType("varchar(150)").IsRequired(true);
        builder.Property(c => c.Estado);
    }
}
