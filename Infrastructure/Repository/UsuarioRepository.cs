using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<SegUsuarios> CreateAsync(SegUsuarios entity)
        {
            await _context.SEGUsuarios.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.SEGUsuarios
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Estado, false));
        }

        public async Task<List<SegUsuarios>> GetAllAsync()
        {
            return await _context.SEGUsuarios.ToListAsync();
        }

        public async Task<List<SegUsuarios>> GetAllByEmpresaSucursalIdAsync(int? idempresa, int? idsucursal, int? idrol)
        {
            return await _context.SEGUsuarios
                .Where(u => u.IdEmpresa == idempresa || u.IdSucursal == idsucursal || u.IdcRol == idrol).ToListAsync();
        }

        public async Task<SegUsuarios> GetByIdAsync(int id)
        {
            return await _context.SEGUsuarios.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, SegUsuarios data)
        {
            return await _context.SEGUsuarios
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.NombreCompleto, data.NombreCompleto)
                    .SetProperty(m => m.Email, data.Email)
                    .SetProperty(m => m.Clave, data.Clave)
                    .SetProperty(m => m.IdcRol, data.IdcRol)
                    .SetProperty(m => m.IdEmpresa, data.IdEmpresa)
                    .SetProperty(m => m.IdSucursal, data.IdSucursal) 
                    .SetProperty(m => m.Estado, data.Estado)
                    .SetProperty(m => m.FechaModificacion, data.FechaModificacion)
                  );
        }
    }
}
