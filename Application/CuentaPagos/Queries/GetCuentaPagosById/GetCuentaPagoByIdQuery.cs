using Application.CuentaPagos.Queries.GetCuentaPagos;
using MediatR;

namespace Application.CuentaPagos.Queries.GetCuentaPagosById
{
    public class GetCuentaPagoByIdQuery : IRequest<CuentaPagosVM>
    {
        public int CuentaPagoId { get; set; }
    }
}
