using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class VentaRepository : IVentaRepository
    {
        private readonly ApplicationDbContext _context;

        public VentaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TrxVentas> CreateAsync(TrxVentas entity)
        {
            await _context.TRXVentas.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.TRXVentas
                  .Where(model => model.Id == id)
                  .ExecuteDeleteAsync();
        }

        public async Task<List<TrxVentas>> GetAllAsync()
        {
            return await _context.TRXVentas.ToListAsync();
        }

        public async Task<TrxVentas> GetByIdAsync(int id)
        {
            return await _context.TRXVentas.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, TrxVentas data)
        {
            return await _context.TRXVentas
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, data.Id)
                    .SetProperty(m => m.IdCliente, data.IdCliente)
                    .SetProperty(m => m.Coordenadas, data.Coordenadas)
                    .SetProperty(m => m.IdcFormaEntrega, data.IdcFormaEntrega)
                    .SetProperty(m => m.IdcFormaPago, data.IdcFormaPago)
                    .SetProperty(m => m.IdcEstadoPago, data.IdcEstadoPago)
                    .SetProperty(m => m.IdcEstadoVenta, data.IdcEstadoVenta)
                    .SetProperty(m => m.IdSucursal, data.IdSucursal)
                    .SetProperty(m => m.IdUsuarioRegistro, data.IdUsuarioRegistro)
                    .SetProperty(m => m.FechaRegistro, data.FechaRegistro)
                    .SetProperty(m => m.IdUsuarioModificacion, data.IdUsuarioModificacion)
                    .SetProperty(m => m.FechaModificacion, data.FechaModificacion)
                  );
        }
    }
}
