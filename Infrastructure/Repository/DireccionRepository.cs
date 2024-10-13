using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class DireccionRepository : IDireccionRepository
    {
        private readonly ApplicationDbContext _context;

        public DireccionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BaseDirecciones> CreateAsync(BaseDirecciones entity)
        {
            await _context.BASDirecciones.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.BASDirecciones
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Estado, false));
        }

        public async Task<List<BaseDirecciones>> GetAllAsync()
        {
            return await _context.BASDirecciones.ToListAsync();
        }

        public async Task<BaseDirecciones> GetByIdAsync(int id)
        {
            return await _context.BASDirecciones.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<BaseDirecciones> GetByRelacionIdAsync(string idrelacion)
        {
            return await _context.BASDirecciones.AsNoTracking()
                .FirstOrDefaultAsync(b => b.IdRelacion == idrelacion);
        }

        public async Task<int> UpdateAsync(int id, BaseDirecciones data)
        {
            return await _context.BASDirecciones
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdcPais, data.IdcPais)
                    .SetProperty(m => m.IdcCiudad, data.IdcCiudad)
                    .SetProperty(m => m.Direccion, data.Direccion)
                    .SetProperty(m => m.CodigoPostal, data.CodigoPostal)
                    .SetProperty(m => m.Coordenadas, data.Coordenadas) 
                    .SetProperty(m => m.Estado, data.Estado)
                    .SetProperty(m=> m.IdRelacion, data.IdRelacion)
                  );
        }

        public async Task<List<BaseDirecciones>> GetAllByPaisCiudadIdAsync(int idpais, int idciudad)
        {
            return await _context.BASDirecciones.AsNoTracking()
                .Where(b => b.Estado == true).ToListAsync();// 
        }
    }
}
