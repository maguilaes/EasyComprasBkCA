using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Direcciones.Commands.Update
{
    public class UpdateDireccionCommandHandler : IRequestHandler<UpdateDireccionCommand, int>
    {
        private readonly IDireccionRepository _entityRepository;

        public UpdateDireccionCommandHandler(IDireccionRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<int> Handle(UpdateDireccionCommand request, CancellationToken cancellationToken)
        {
            var UpdateEntity = new BaseDirecciones()
            {
                Id = request.Id,
                IdcPais = request.IdcPais,
                IdcCiudad = request.IdcCiudad,
                Telefono = request.Telefono,
                Direccion = request.Direccion,
                CodigoPostal = request.CodigoPostal,
                Coordenadas = request.Coordenadas,
                Estado = request.Estado,
                IdRelacion = request.IdRelacion
            };

            return await _entityRepository.UpdateAsync(request.Id, UpdateEntity);
        }
    }
}
