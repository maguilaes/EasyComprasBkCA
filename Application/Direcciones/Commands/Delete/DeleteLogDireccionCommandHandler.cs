using Domain.BASDireccion;
using Domain.Entity;
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
            var UpdateEntity = new BaseDirecciones()
            {
                Id = request.Id,
                Estado = false
            };

            return await _entityRepository.UpdateAsync(request.Id, UpdateEntity);
        }
    }
}
