using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class EmailConfiguration : IEntityTypeConfiguration<IniEmail>
    {
        public void Configure(EntityTypeBuilder<IniEmail> builder)
        {
            builder.ToTable("IniEmail");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Para).HasMaxLength(50);
            builder.Property(c => c.Asunto);
            builder.Property(c => c.Contenido);
            builder.Property(c => c.Estado);
        }
    }
}
