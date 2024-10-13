using Domain.Repository;
using MediatR;

namespace Application.Ciudades.Commands.Delete
{
    public class DeleteLogCiudadCommandHandler : IRequestHandler<DeleteLogCiudadCommand, int>
    {
        private readonly ICiudadRepository _entityRepository;

        public DeleteLogCiudadCommandHandler(ICiudadRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<int> Handle(DeleteLogCiudadCommand request, CancellationToken cancellationToken)
        {
            return await _entityRepository.DeleteAsync(request.Id);
        }
    }
}
