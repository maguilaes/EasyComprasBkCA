using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class VentaTransferenciaRepository : IVentaTransferenciaRepository
    {
        private readonly ApplicationDbContext _context;

        public VentaTransferenciaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TrxVentasTransferencia> CreateAsync(TrxVentasTransferencia entity)
        {
            await _context.TRXVentasTransferencias.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.TRXVentasTransferencias
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Estado, false));
        }

        public async Task<List<TrxVentasTransferencia>> GetAllAsync()
        {
            return await _context.TRXVentasTransferencias.ToListAsync();
        }

        public async Task<TrxVentasTransferencia> GetByIdAsync(int id)
        {
            return await _context.TRXVentasTransferencias.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, TrxVentasTransferencia data)
        {
            return await _context.TRXVentasTransferencias
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdcEstadoTransferencia, data.IdcEstadoTransferencia)
                    .SetProperty(m => m.IdCliente, data.IdCliente)
                    .SetProperty(m => m.MontoTransferencia, data.MontoTransferencia)
                    .SetProperty(m => m.UrlComprobante, data.UrlComprobante)
                    .SetProperty(m => m.MontoRecibido, data.MontoRecibido)
                    .SetProperty(m => m.Comentarios, data.Comentarios)
                    .SetProperty(m => m.IdVenta, data.IdVenta)
                    .SetProperty(m => m.IdUsuarioModificacion, data.IdUsuarioRegistro)
                    .SetProperty(m => m.FechaModificacion, data.FechaRegistro)
                    .SetProperty(m => m.Estado, data.Estado)
                  );
        }

        public async Task<int> UpdateComprobanteAsync(int id, TrxVentasTransferencia data)
        {
            return await _context.TRXVentasTransferencias
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.UrlComprobante, data.UrlComprobante)
                    .SetProperty(m => m.Comentarios, data.Comentarios)
                    .SetProperty(m => m.IdVenta, data.IdVenta)
                    .SetProperty(m => m.IdUsuarioModificacion, data.IdUsuarioRegistro)
                    .SetProperty(m => m.FechaModificacion, data.FechaRegistro)
                  );
        }
    }
}
