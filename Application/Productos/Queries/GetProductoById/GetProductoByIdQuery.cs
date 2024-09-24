using Application.Productos.Queries.GetProductos;
using MediatR;

namespace Application.Productos.Queries.GetProductoById
{
    public class GetProductoByIdQuery : IRequest<ProductosVM>
    {
        public int ProductoId { get; set; }
    }
}
