using Application.Productos.Queries.GetProductos;
using MediatR;

namespace Application.Productos.Queries.GetProductoByCodigo
{
    public class GetProductoByCodigoQuery : IRequest<ProductosVM>
    {
        public string Codigo { get; set; }
    }
}
