using Application.DTOs;
using MediatR;

namespace Application.Productos.Queries.GetProductosQueryFilters
{
    public class GetAllProductosQuery : IRequest<ProductosDto>
    {
        //public int? PageNumber { get; set; }
        //public int? PageSize { get; set; }
        //public int? SucursalId { get; set; }
        //public int? CategoriaId { get; set; }
        //public string? NombreProducto { get; set; }
        //public string? UrlEndpoint { get; set; }
        //public string? NextPageUrl { get; set; }
        //public string? PreviousPageUrl { get; set; }
        public int? SucursalId { get; set; }
        public int? CategoriaId { get; set; }
        public string? NombreProducto { get; set; }
        //public string? Descripcion { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
