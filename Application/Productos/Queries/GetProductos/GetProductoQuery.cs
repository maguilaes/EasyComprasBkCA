using MediatR;

namespace Application.Productos.Queries.GetProductos
{
    public class GetProductoQuery : IRequest<List<ProductosVM>>
    {
    }
}
