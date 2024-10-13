using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Clientes.Commands.Update
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, int>
    {
        private readonly IClienteRepository _entityRepository;

        public UpdateClienteCommandHandler(IClienteRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<int> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var UpdateEntity = new NegClientes()
            {
                Id = request.Id,
                Documento = request.Documento,
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                NombreCompleto = request.Nombres + " " + request.Apellidos,
                Email = request.Email,
                IdSucursal = request.IdSucursal,
                IdUsuarioModificacion = request.IdUsuarioModificacion,
                FechaModificacion = DateTime.Now.Date,
                Estado = request.Estado
            };

            return await _entityRepository.UpdateAsync(request.Id, UpdateEntity);
        }
    }
}
