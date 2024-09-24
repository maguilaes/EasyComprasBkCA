using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<NegProductos> CreateAsync(NegProductos entity)
        {
            await _context.NEGProductos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.NEGProductos
                  .Where(model => model.Id == id)
                  .ExecuteDeleteAsync();
        }

        public async Task<List<NegProductos>> GetAllAsync()
        {
            return await _context.NEGProductos.ToListAsync();
        }

        public async Task<NegProductos> GetByIdAsync(int id)
        {
            return await _context.NEGProductos.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, NegProductos data)
        {
            return await _context.NEGProductos
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, data.Id)
                    .SetProperty(m => m.IdSucursal, data.IdSucursal)
                    .SetProperty(m => m.IdcCategoria, data.IdcCategoria)
                    .SetProperty(m => m.Codigo, data.Codigo)
                    .SetProperty(m => m.NombreProducto, data.NombreProducto)
                    .SetProperty(m => m.Descripcion, data.Descripcion)
                    .SetProperty(m => m.Stock, data.Stock)
                    .SetProperty(m => m.IdcMedida, data.IdcMedida)
                    .SetProperty(m => m.PrecioCompra, data.PrecioCompra)
                    .SetProperty(m => m.PrecioVenta, data.PrecioVenta)
                    .SetProperty(m => m.UrlImagen, data.UrlImagen)
                    .SetProperty(m => m.Estado, data.Estado)
                    .SetProperty(m => m.IdUsuarioRegistro, data.IdUsuarioRegistro)
                    .SetProperty(m => m.FechaRegistro, data.FechaRegistro)
                    .SetProperty(m => m.IdUsuarioModificacion, data.IdUsuarioModificacion)
                    .SetProperty(m => m.FechaModificacion, data.FechaModificacion)
                  );
        }
    }
}
