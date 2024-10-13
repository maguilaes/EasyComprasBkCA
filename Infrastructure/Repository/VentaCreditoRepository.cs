using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class VentaCreditoRepository : IVentaCreditoRepository
    {
        private readonly ApplicationDbContext _context;

        public VentaCreditoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TrxVentasCredito> CreateAsync(TrxVentasCredito entity)
        {
            await _context.TRXVentasCreditos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.TRXVentasCreditos
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Estado, false));
        }

        public async Task<List<TrxVentasCredito>> GetAllAsync()
        {
            return await _context.TRXVentasCreditos.ToListAsync();
        }

        public async Task<TrxVentasCredito> GetByIdAsync(int id)
        {
            return await _context.TRXVentasCreditos.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, TrxVentasCredito data)
        {
            return await _context.TRXVentasCreditos
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdcEstadoCredito, data.IdcEstadoCredito)
                    .SetProperty(m => m.IdCliente, data.IdCliente)
                    .SetProperty(m => m.DeudaInicial, data.DeudaInicial)
                    .SetProperty(m => m.MontoPagado, data.MontoPagado)
                    .SetProperty(m => m.DeudaActual, data.DeudaActual)
                    .SetProperty(m => m.Comentarios, data.Comentarios)
                    .SetProperty(m => m.IdVenta, data.IdVenta)
                    .SetProperty(m => m.IdUsuarioRegistro, data.IdUsuarioRegistro)
                    .SetProperty(m => m.FechaRegistro, data.FechaRegistro)
                    .SetProperty(m => m.IdUsuarioModificacion, data.IdUsuarioModificacion)
                    .SetProperty(m => m.FechaModificacion, data.FechaModificacion)
                    .SetProperty(m => m.Estado, data.Estado)
                  );
        }
    }
}
