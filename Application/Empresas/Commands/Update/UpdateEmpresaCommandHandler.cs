using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Empresas.Commands.Update
{
    public class UpdateEmpresaCommandHandler : IRequestHandler<UpdateEmpresaCommand, int>
    {
        private readonly IEmpresaRepository _entityRepository;

        public UpdateEmpresaCommandHandler(IEmpresaRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<int> Handle(UpdateEmpresaCommand request, CancellationToken cancellationToken)
        {
            var UpdateEntity = new NegEmpresas()
            {
                Id = request.Id,
                NitEmpresa = request.NitEmpresa,
                NombreEmpresa = request.NombreEmpresa,
                Email = request.Email,
                Leyenda = request.Leyenda,
                UrlLogo = request.UrlLogo,
                NombreContacto = request.NombreContacto,
                TelefonoContacto = request.TelefonoContacto,
                IdcCategoria = request.IdcCategoria,
                Ubicacion = request.Ubicacion,
                Estado = request.Estado,
                Coordenadas = request.Coordenadas,
                IdUsuarioModificacion = request.IdUsuarioModificacion,
                FechaModificacion = DateTime.UtcNow
            };

            return await _entityRepository.UpdateAsync(request.Id, UpdateEntity);
        }
    }
}
