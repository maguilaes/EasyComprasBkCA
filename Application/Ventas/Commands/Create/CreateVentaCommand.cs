using Application.Ventas.Queries.GetVentas;
using MediatR;

namespace Application.Ventas.Commands.Create
{
    public class CreateVentaCommand : IRequest<VentasVM>
    {
        public int IdCliente { get; set; }
        public string Coordenadas { get; set; }
        public int IdUsuario { get; set; }
        public int IdFormaEntrega { get; set; }
        public int IdFormaPago { get; set; }
        public int IdEstadoPago { get; set; }
        public int IdEstadoVenta { get; set; }
        public int IdSucursal { get; set; }
        public bool Estado { get; set; }
        public List<Domain.Entity.Request.TrxDetalleVentas> ProductoLista { get; set; }
    }
}
