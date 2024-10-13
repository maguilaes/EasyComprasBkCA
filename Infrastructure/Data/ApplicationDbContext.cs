using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            try
            {
                var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if(dbCreator != null)
                {
                    if (!dbCreator.CanConnect())
                        dbCreator.Create();
                    if (!dbCreator.HasTables())
                        dbCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public DbSet<BaseTipos> BASTipos { get; set; }
        public DbSet<BaseClasificadores> BASClasificadores { get; set; }
        public DbSet<BaseDirecciones> BASDirecciones { get; set; }
        public DbSet<BaseCiudades> BASCiudades { get; set; }
        public DbSet<IniConfig> INIConfigs { get; set; }
        public DbSet<IniEmail> INIEmails { get; set; }
        public DbSet<NegClientes> NEGClientes { get; set; }
        public DbSet<NegEmpresas> NEGEmpresas { get; set; }
        public DbSet<NegSucursales> NEGSucursales { get; set; }
        public DbSet<NegProductos> NEGProductos { get; set; }
        public DbSet<NegCuentaPagos> NEGCuentaPagos { get; set; }
        public DbSet<SegUsuarios> SEGUsuarios { get; set; }
        public DbSet<TrxVentas> TRXVentas { get; set; }
        public DbSet<TrxDetalleVentas> TRXDetalleVentas { get; set; }
        public DbSet<TrxVentasCredito> TRXVentasCreditos { get; set; }
        public DbSet<TrxVentasTransferencia> TRXVentasTransferencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}