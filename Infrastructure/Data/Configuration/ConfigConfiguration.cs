using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ConfigConfiguration : IEntityTypeConfiguration<IniConfig>
    {
        public void Configure(EntityTypeBuilder<IniConfig> builder)
        {
            builder.ToTable("IniConfig");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Recurso).HasMaxLength(50);
            builder.Property(c => c.Propiedad);
            builder.Property(c => c.Valor);
            builder.Property(c => c.Estado);
        }
    }
}
