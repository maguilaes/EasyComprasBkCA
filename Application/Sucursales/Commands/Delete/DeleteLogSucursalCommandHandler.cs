using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Sucursales.Commands.Delete
{
    public class DeleteLogSucursalCommandHandler : IRequestHandler<DeleteLogSucursalCommand, int>
    {
        private readonly ISucursalRepository _entityRepository;

        public DeleteLogSucursalCommandHandler(ISucursalRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<int> Handle(DeleteLogSucursalCommand request, CancellationToken cancellationToken)
        {
            var UpdateEntity = new NegSucursales()
            {
                Id = request.Id,
                Estado = false
            };

            return await _entityRepository.UpdateAsync(request.Id, UpdateEntity);
        }
    }
}
