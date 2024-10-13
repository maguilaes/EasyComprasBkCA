using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ConfigRepository : IConfigRepository
    {
        private readonly ApplicationDbContext _context;

        public ConfigRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IniConfig> CreateAsync(IniConfig entity)
        {
            await _context.INIConfigs.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.INIConfigs
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Estado, false));
        }

        public async Task<List<IniConfig>> GetAllAsync()
        {
            return await _context.INIConfigs.ToListAsync();
        }

        public async Task<IniConfig> GetByIdAsync(int id)
        {
            return await _context.INIConfigs.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<IniConfig>> GetByRecursoAsync(string strRecurso)
        {
            return await _context.INIConfigs.AsNoTracking()
                .Where(b => b.Recurso== strRecurso).ToListAsync();
        }

        public async Task<int> UpdateAsync(int id, IniConfig data)
        {
            return await _context.INIConfigs
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Recurso, data.Recurso)
                    .SetProperty(m => m.Propiedad, data.Propiedad)
                    .SetProperty(m => m.Valor, data.Valor)
                    .SetProperty(m => m.Estado, data.Estado)
                  );
        }
    }
}
