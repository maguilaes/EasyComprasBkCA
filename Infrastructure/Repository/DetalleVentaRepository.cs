using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class DetalleVentaRepository : IDetVentaRepository
    {
        private readonly ApplicationDbContext _context;

        public DetalleVentaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TrxDetalleVentas> CreateAsync(TrxDetalleVentas entity)
        {
            await _context.TRXDetalleVentas.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.TRXDetalleVentas
                  .Where(model => model.Id == id)
                  .ExecuteDeleteAsync();
        }

        public async Task<List<TrxDetalleVentas>> GetAllAsync()
        {
            return await _context.TRXDetalleVentas.ToListAsync();
        }

        public async Task<TrxDetalleVentas> GetByIdAsync(int id)
        {
            return await _context.TRXDetalleVentas.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, TrxDetalleVentas data)
        {
            return await _context.TRXDetalleVentas
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, data.Id)
                    .SetProperty(m => m.CodigoProducto, data.CodigoProducto)
                    .SetProperty(m => m.Nombre, data.Nombre)
                    .SetProperty(m => m.Descripcion, data.Descripcion)
                    .SetProperty(m => m.IdMedida, data.IdMedida)
                    .SetProperty(m => m.PrecioUnitario, data.PrecioUnitario)
                    .SetProperty(m => m.Cantidad, data.Cantidad)
                    .SetProperty(m => m.SubTotal, data.SubTotal)
                    .SetProperty(m => m.IdVenta, data.IdVenta)
                  );
        }
    }
}
