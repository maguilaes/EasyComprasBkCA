using Domain.Entity;
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
            var UpdateEntity = new BaseCiudades()
            {
                Id = request.Id,
                Estado = false
            };

            return await _entityRepository.UpdateAsync(request.Id, UpdateEntity);
        }
    }
}
