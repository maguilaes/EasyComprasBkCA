using MediatR;

namespace Application.CuentaPagos.Commands.Delete
{
    public class DeleteLogCuentaPagoCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
