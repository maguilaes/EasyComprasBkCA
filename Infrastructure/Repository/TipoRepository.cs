using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class TipoRepository : ITipoRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BaseTipos> CreateAsync(BaseTipos blog)
        {
            await _context.BASTipos.AddAsync(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.BASTipos
                  .Where(model => model.Id == id)
                  .ExecuteDeleteAsync();
        }

        public async Task<List<BaseTipos>> GetAllAsync()
        {
            return await _context.BASTipos.ToListAsync();
        }

        public async Task<BaseTipos> GetByIdAsync(int id)
        {
            return await _context.BASTipos.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, BaseTipos data)
        {
            return await _context.BASTipos
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, data.Id)
                    .SetProperty(m => m.Descripcion, data.Descripcion)
                  );
        }
    }
}
