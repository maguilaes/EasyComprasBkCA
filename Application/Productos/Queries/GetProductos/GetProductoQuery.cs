using Application.DTOs;
using MediatR;

namespace Application.Productos.Queries.GetProductos
{
    public class GetProductoQuery : IRequest<List<ProductosDto>>
    {
    }
}
