using Application.Common.Mappings;
using Domain.Entity;

namespace Application.DTOs
{
    public class ProductosDto : IMapFrom<NegProductos>
    {
        public int Id { get; set; }
        public string CiudadOrigen { get; set; }
        public int CiudadId { get; set; }
        public string Sucursal { get; set; }
        public int SucursalId { get; set; }
        public string Categoria { get; set; }
        public int CategoriaId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public string Medida { get; set; }
        public int IdcMedida { get; set; }
        public int Stock { get; set; }
        public string UrlImagen { get; set; }
        public bool? Estado { get; set; }
    }
}
