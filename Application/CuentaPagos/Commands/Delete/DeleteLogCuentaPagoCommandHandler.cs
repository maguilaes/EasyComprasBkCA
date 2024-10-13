using Domain.Repository;
using MediatR;

namespace Application.CuentaPagos.Commands.Delete
{
    public class DeleteLogCuentaPagoCommandHandler : IRequestHandler<DeleteLogCuentaPagoCommand, int>
    {
        private readonly ICuentaPagoRepository _entityRepository;

        public DeleteLogCuentaPagoCommandHandler(ICuentaPagoRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<int> Handle(DeleteLogCuentaPagoCommand request, CancellationToken cancellationToken)
        {
            return await _entityRepository.DeleteAsync(request.Id);
        }
    }
}
