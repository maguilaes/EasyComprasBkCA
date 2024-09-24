using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ClasificadorRepository : IClasificadorRepository
    {
        private readonly ApplicationDbContext _context;

        public ClasificadorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BaseClasificadores> CreateAsync(BaseClasificadores entity)
        {
            await _context.BASClasificadores.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.BASClasificadores
                  .Where(model => model.Id == id)
                  .ExecuteDeleteAsync();
        }

        public async Task<List<BaseClasificadores>> GetAllAsync()
        {
            return await _context.BASClasificadores.ToListAsync();
        }

        public async Task<BaseClasificadores> GetByIdAsync(int id)
        {
            return await _context.BASClasificadores.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, BaseClasificadores data)
        {
            return await _context.BASClasificadores
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, data.Id)
                    .SetProperty(m => m.Descripcion, data.Descripcion)
                    .SetProperty(m => m.Estado, data.Estado)
                    .SetProperty(m => m.IdTipo, data.IdTipo)
                  );
        }
    }
}
