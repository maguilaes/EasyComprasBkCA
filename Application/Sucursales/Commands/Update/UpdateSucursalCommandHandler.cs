using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Sucursales.Commands.Update
{
    public class UpdateSucursalCommandHandler : IRequestHandler<UpdateSucursalCommand, int>
    {
        private readonly ISucursalRepository _entityRepository;

        public UpdateSucursalCommandHandler(ISucursalRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<int> Handle(UpdateSucursalCommand request, CancellationToken cancellationToken)
        {
            var UpdateEntity = new NegSucursales()
            {
                Id = request.Id,
                IdcCiudad = request.IdcCiudad,
                NombreSucursal = request.NombreSucursal,
                Estado = request.Estado,
                IdEmpresa = request.IdEmpresa,
                IdUsuarioModificacion = request.IdUsuarioModificacion,
                FechaModificacion = DateTime.Now.Date
            };

            return await _entityRepository.UpdateAsync(request.Id, UpdateEntity);
        }
    }
}
