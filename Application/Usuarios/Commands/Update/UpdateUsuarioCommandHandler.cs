using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Usuarios.Commands.Update
{
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _entityRepository;
        private readonly IHashService _hash;

        public UpdateUsuarioCommandHandler(IUsuarioRepository entityRepository, IHashService hash)
        {
            _entityRepository = entityRepository;
        }
        public async Task<int> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var UpdateEntity = new SegUsuarios()
            {
                Id = request.Id,
                NombreCompleto = request.NombreCompleto,
                Clave = _hash.ConvertirSha256(request.Clave),
                Email = request.Email,
                IdcRol = request.IdcRol,
                IdEmpresa = request.IdEmpresa,
                IdSucursal = request.IdSucursal,
                //IdUsuarioModificacion = request.IdUsuarioModificacion,
                FechaModificacion = DateTime.Now.Date,
                Estado = request.Estado
            };

            return await _entityRepository.UpdateAsync(request.Id, UpdateEntity);
        }
    }
}
