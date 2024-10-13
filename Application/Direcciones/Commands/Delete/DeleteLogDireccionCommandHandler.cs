using Domain.Repository;
using MediatR;

namespace Application.Direcciones.Commands.Delete
{
    public class DeleteLogDireccionCommandHandler : IRequestHandler<DeleteLogDireccionCommand, int>
    {
        private readonly IDireccionRepository _entityRepository;

        public DeleteLogDireccionCommandHandler(IDireccionRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<int> Handle(DeleteLogDireccionCommand request, CancellationToken cancellationToken)
        {
            return await _entityRepository.DeleteAsync(request.Id);
        }
    }
}
