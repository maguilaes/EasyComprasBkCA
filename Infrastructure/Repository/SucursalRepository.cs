using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class SucursalRepository : ISucursalRepository
    {
        private readonly ApplicationDbContext _context;

        public SucursalRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<NegSucursales> CreateAsync(NegSucursales entity)
        {
            await _context.NEGSucursales.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.NEGSucursales
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Estado, false));
        }

        public async Task<List<NegSucursales>> GetAllAsync()
        {
            return await _context.NEGSucursales.ToListAsync();
        }

        public async Task<List<NegSucursales>> GetAllByCiudadEmpresaIdAsync(int? idciudad, int? idempresa)
        {
            return await _context.NEGSucursales
                .Where(s => s.IdcCiudad == idciudad || s.IdEmpresa == idempresa).ToListAsync();
        }

        public async Task<NegSucursales> GetByIdAsync(int id)
        {
            return await _context.NEGSucursales.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, NegSucursales data)
        {
            return await _context.NEGSucursales
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdcCiudad, data.IdcCiudad)
                    .SetProperty(m => m.Estado, data.Estado)
                    .SetProperty(m => m.IdEmpresa, data.IdEmpresa)
                    .SetProperty(m => m.IdUsuarioRegistro, data.IdUsuarioRegistro)
                    .SetProperty(m => m.FechaRegistro, data.FechaRegistro)
                    .SetProperty(m => m.IdUsuarioModificacion, data.IdUsuarioRegistro)
                    .SetProperty(m => m.FechaModificacion, data.FechaModificacion)
                  );
        }
    }
}
