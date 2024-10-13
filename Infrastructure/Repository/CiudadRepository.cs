using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CiudadRepository : ICiudadRepository
    {
        private readonly ApplicationDbContext _context;

        public CiudadRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BaseCiudades> CreateAsync(BaseCiudades entity)
        {
            await _context.BASCiudades.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.BASCiudades
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Estado, false));
        }

        public async Task<List<BaseCiudades>> GetAllAsync()
        {
            return await _context.BASCiudades.ToListAsync();
        }

        public async Task<BaseCiudades> GetByIdAsync(int id)
        {
            return await _context.BASCiudades.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<BaseCiudades>> GetByPaisIdAsync(int idpais)
        {
            return await _context.BASCiudades
                .Where(b => b.IdcPais == idpais).ToListAsync();
        }

        public async Task<int> UpdateAsync(int id, BaseCiudades data)
        {
            return await _context.BASCiudades
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Ciudad, data.Ciudad)
                    .SetProperty(m => m.Estado, data.Estado)
                    .SetProperty(m=> m.IdcPais, data.IdcPais)
                  );
        }
    }
}
