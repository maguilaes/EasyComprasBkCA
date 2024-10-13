using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CuentaPagoRepository : ICuentaPagoRepository
    {
        private readonly ApplicationDbContext _context;

        public CuentaPagoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<NegCuentaPagos> CreateAsync(NegCuentaPagos entity)
        {
            await _context.NEGCuentaPagos.AddAsync(entity);
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

        public async Task<List<NegCuentaPagos>> GetAllAsync()
        {
            return await _context.NEGCuentaPagos.ToListAsync();
        }

        public async Task<NegCuentaPagos> GetByIdAsync(int id)
        {
            return await _context.NEGCuentaPagos.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<NegCuentaPagos>> GetByPaisIdAsync(int idsucursal)
        {
            return await _context.NEGCuentaPagos
                .Where(b => b.IdSucursal == idsucursal).ToListAsync();
        }

        public async Task<int> UpdateAsync(int id, NegCuentaPagos data)
        {
            return await _context.NEGCuentaPagos
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.NroCuentaPagos, data.NroCuentaPagos)
                    .SetProperty(m => m.BancoPagos, data.BancoPagos)
                    .SetProperty(m=> m.DocumentoTitular, data.DocumentoTitular)
                    .SetProperty(m => m.UrlQr, data.UrlQr)
                    .SetProperty(m => m.IdUsuarioModificacion, data.IdUsuarioRegistro)
                    .SetProperty(m => m.FechaModificacion, data.FechaModificacion)
                    .SetProperty(m => m.Estado, data.Estado)
                  );
        }

        public async Task<int> UpdateQrPagoAsync(int id, NegCuentaPagos data)
        {
            return await _context.NEGCuentaPagos
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.UrlQr, data.UrlQr)
                    .SetProperty(m => m.IdUsuarioModificacion, data.IdUsuarioRegistro)
                    .SetProperty(m => m.FechaModificacion, data.FechaModificacion)
                  );
        }
    }
}
