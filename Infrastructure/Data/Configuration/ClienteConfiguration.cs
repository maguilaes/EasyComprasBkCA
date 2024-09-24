﻿using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<NegClientes>
    {
        public void Configure(EntityTypeBuilder<NegClientes> builder)
        {
            builder.ToTable("NEGClientes");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Documento).HasMaxLength(20);
            builder.Property(c => c.Nombres).HasMaxLength(50);
            builder.Property(c => c.Apellidos).HasMaxLength(50);
            builder.Property(c => c.NombreCompleto).HasMaxLength(100);
            builder.Property(c => c.Email).HasMaxLength(50).IsRequired(true);
            builder.Property(c => c.IdUsuarioRegistro).IsRequired(false);
            builder.Property(c => c.FechaRegistro).IsRequired(false);
            builder.Property(c => c.IdUsuarioModificacion).IsRequired(false);
            builder.Property(c => c.FechaModificacion).IsRequired(false);
            builder.Property(c => c.IdSucursal).IsRequired(true);
            builder.Property(c => c.Estado).IsRequired(true);
        }
    }
}
