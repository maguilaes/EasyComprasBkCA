using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Sucursales.Commands.Delete
{
    public class DeleteLogSucursalCommandHandler : IRequestHandler<DeleteLogSucursalCommand, int>
    {
        private readonly ISucursalRepository _entityRepository;

        public DeleteLogSucursalCommandHandler(ISucursalRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<int> Handle(DeleteLogSucursalCommand request, CancellationToken cancellationToken)
        {
            return await _entityRepository.DeleteAsync(request.Id);
        }
    }
}
