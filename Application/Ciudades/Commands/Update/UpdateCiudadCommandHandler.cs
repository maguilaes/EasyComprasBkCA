using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Ciudades.Commands.Update
{
    public class UpdateCiudadCommandHandler : IRequestHandler<UpdateCiudadCommand, int>
    {
        private readonly ICiudadRepository _entityRepository;

        public UpdateCiudadCommandHandler(ICiudadRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<int> Handle(UpdateCiudadCommand request, CancellationToken cancellationToken)
        {
            var UpdateEntity = new BaseCiudades()
            {
                Id = request.Id,
                Ciudad = request.Ciudad,
                IdcPais = request.IdcPais,
                Estado = request.Estado
            };

            return await _entityRepository.UpdateAsync(request.Id, UpdateEntity);
        }
    }
}
