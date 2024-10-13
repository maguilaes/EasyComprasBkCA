using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly ApplicationDbContext _context;

        public EmailRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IniEmail> CreateAsync(IniEmail entity)
        {
            await _context.INIEmails.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.INIEmails
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Estado, false));
        }

        public async Task<List<IniEmail>> GetAllAsync()
        {
            return await _context.INIEmails.ToListAsync();
        }

        public async Task<IniEmail> GetByIdAsync(int id)
        {
            return await _context.INIEmails.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, IniEmail data)
        {
            return await _context.INIEmails
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Para, data.Para)
                    .SetProperty(m => m.Asunto, data.Asunto)
                    .SetProperty(m => m.Contenido, data.Contenido)
                    .SetProperty(m => m.Estado, data.Estado)
                  );
        }
    }
}
