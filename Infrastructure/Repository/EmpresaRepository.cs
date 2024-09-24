using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly ApplicationDbContext _context;

        public EmpresaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<NegEmpresas> CreateAsync(NegEmpresas entity)
        {
            await _context.NEGEmpresas.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.NEGEmpresas
                  .Where(model => model.Id == id)
                  .ExecuteDeleteAsync();
        }

        public async Task<List<NegEmpresas>> GetAllAsync()
        {
            return await _context.NEGEmpresas.ToListAsync();
        }

        public async Task<NegEmpresas> GetByIdAsync(int id)
        {
            return await _context.NEGEmpresas.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, NegEmpresas data)
        {
            return await _context.NEGEmpresas
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, data.Id)
                    .SetProperty(m => m.NitEmpresa, data.NitEmpresa)
                    .SetProperty(m => m.NombreEmpresa, data.NombreEmpresa)
                    .SetProperty(m => m.Email, data.Email)
                    .SetProperty(m => m.Leyenda, data.Leyenda)
                    .SetProperty(m => m.UrlLogo, data.UrlLogo)
                    .SetProperty(m => m.NombreContacto, data.NombreContacto)
                    .SetProperty(m => m.TelefonoContacto, data.TelefonoContacto)
                    .SetProperty(m => m.IdcCategoria, data.IdcCategoria)
                    .SetProperty(m => m.Estado, data.Estado)
                    .SetProperty(m => m.Ubicacion, data.Ubicacion)
                    .SetProperty(m => m.Coordenadas, data.Coordenadas)
                    //.SetProperty(m => m.IdUsuarioRegistro, data.IdUsuarioRegistro)
                    //.SetProperty(m => m.FechaRegistro, data.FechaRegistro)
                    .SetProperty(m => m.IdUsuarioModificacion, data.IdUsuarioModificacion)
                    .SetProperty(m => m.FechaModificacion, data.FechaModificacion)
                  );
        }
    }
}
