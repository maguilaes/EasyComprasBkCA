using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<NegClientes> CreateAsync(NegClientes entity)
        {
            await _context.NEGClientes.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.NEGClientes
                  .Where(model => model.Id == id)
                  .ExecuteDeleteAsync();
        }

        public async Task<List<NegClientes>> GetAllAsync()
        {
            return await _context.NEGClientes.ToListAsync();
        }

        public async Task<NegClientes> GetByIdAsync(int id)
        {
            return await _context.NEGClientes.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, NegClientes data)
        {
            return await _context.NEGClientes
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, data.Id)
                    .SetProperty(m => m.Documento, data.Documento)
                    .SetProperty(m => m.Nombres, data.Nombres)
                    .SetProperty(m => m.Apellidos, data.Apellidos)
                    .SetProperty(m => m.NombreCompleto, data.NombreCompleto)
                    .SetProperty(m => m.Email, data.Email)
                    .SetProperty(m => m.IdSucursal, data.IdSucursal)
                    .SetProperty(m => m.Estado, data.Estado)
                    //.SetProperty(m => m.IdUsuarioRegistro, data.IdUsuarioRegistro)
                    //.SetProperty(m => m.FechaRegistro, data.FechaRegistro)
                    .SetProperty(m => m.IdUsuarioModificacion, data.IdUsuarioModificacion)
                    .SetProperty(m => m.FechaModificacion, data.FechaModificacion)
                  );
        }
    }
}
