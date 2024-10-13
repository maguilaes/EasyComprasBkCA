using MediatR;

namespace Application.Ventas.Queries.GetVentas
{
    public class GetVentaQuery : IRequest<List<VentasVM>>
    {
    }
}
