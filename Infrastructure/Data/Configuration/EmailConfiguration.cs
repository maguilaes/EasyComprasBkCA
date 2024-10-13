using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class EmailConfiguration : IEntityTypeConfiguration<IniEmail>
    {
        public void Configure(EntityTypeBuilder<IniEmail> builder)
        {
            builder.ToTable("INIEmail");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Para).HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(c => c.Asunto).HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(c => c.Contenido).HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(c => c.Estado);
        }
    }
}
