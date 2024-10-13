using MediatR;

namespace Application.CuentaPagos.Queries.GetCuentaPagos
{
    public class GetCuentaPagoQuery : IRequest<List<CuentaPagosVM>>
    {
    }
}
