using Application.Common.Mappings;
using Domain.Entity;

namespace Application.Productos.Queries.GetProductos
{
    public class TrxDetVenta : IMapFrom<TrxDetalleVentas>
    {
        public int Id { get; set; }
        public string CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdMedida { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; } = 0;
        public int IdVenta { get; set; }
    }
}
