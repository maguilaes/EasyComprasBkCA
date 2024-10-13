using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Productos.Commands.UpdateStock
{
    public class UpdateProductoStockCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Stock { get; set; }
        public int IdUsuarioRegistro{ get; set; }
    }
}
