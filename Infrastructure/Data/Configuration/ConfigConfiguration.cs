using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ConfigConfiguration : IEntityTypeConfiguration<IniConfig>
    {
        public void Configure(EntityTypeBuilder<IniConfig> builder)
        {
            builder.ToTable("INIConfig");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Recurso).HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(c => c.Propiedad).HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(c => c.Valor).HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(c => c.Estado);
        }
    }
}
