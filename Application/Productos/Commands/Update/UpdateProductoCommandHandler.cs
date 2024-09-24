using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Productos.Commands.Update
{
    public class UpdateProductoCommandHandler : IRequestHandler<UpdateProductoCommand, int>
    {
        private readonly IProductoRepository _entityRepository;

        public UpdateProductoCommandHandler(IProductoRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<int> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
        {
            var UpdateEntity = new NegProductos()
            {
                Id = request.Id,
                IdSucursal = request.IdSucursal,
                IdcCategoria = request.IdcCategoria,
                Codigo = request.Codigo,
                NombreProducto = request.NombreProducto,
                Descripcion = request.Descripcion,
                Stock = request.Stock,
                IdcMedida = request.IdcMedida,
                PrecioCompra  = request.PrecioCompra,
                PrecioVenta = request.PrecioVenta,
                UrlImagen = request.UrlImagen,
                Estado = request.Estado,
                IdUsuarioModificacion = request.IdUsuarioModificacion,
                FechaRegistro = DateTime.UtcNow
            };

            return await _entityRepository.UpdateAsync(request.Id, UpdateEntity);
        }
    }
}
