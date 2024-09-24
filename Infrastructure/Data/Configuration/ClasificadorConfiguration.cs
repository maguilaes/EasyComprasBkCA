using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class ClasificadorConfiguration : IEntityTypeConfiguration<BaseClasificadores>
{
    public void Configure(EntityTypeBuilder<BaseClasificadores> builder)
    {
        builder.ToTable("BASClasificadores");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Descripcion).HasMaxLength(150);
        builder.Property(c => c.Estado);
        builder.Property(c => c.IdTipo);
    }
}
