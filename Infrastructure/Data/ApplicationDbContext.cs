using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BaseTipos> BASTipos { get; set; }
        public DbSet<BaseClasificadores> BASClasificadores { get; set; }
        public DbSet<BaseDirecciones> BASDirecciones { get; set; }
        public DbSet<BaseCiudades> BASCiudades { get; set; }
        public DbSet<NegClientes> NEGClientes { get; set; }
        public DbSet<NegEmpresas> NEGEmpresas { get; set; }
        public DbSet<NegSucursales> NEGSucursales { get; set; }
        public DbSet<NegProductos> NEGProductos { get; set; }
        public DbSet<SegUsuarios> SEGUsuarios { get; set; }
        public DbSet<TrxVentas> TRXVentas { get; set; }
        public DbSet<TrxDetalleVentas> TRXDetalleVentas { get; set; }
        public DbSet<TrxVentasCredito> TRXVentasCreditos { get; set; }
        public DbSet<IniConfig> IniConfigs { get; set; }
        public DbSet<IniEmail> iniEmails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}