using Application.Ventas.Queries.GetVentas;
using MediatR;

namespace Application.Ventas.Queries.GetById
{
    public class GetVentaByIdQuery : IRequest<VentasVM>
    {
        public int VentaId { get; set; }
    }
}
