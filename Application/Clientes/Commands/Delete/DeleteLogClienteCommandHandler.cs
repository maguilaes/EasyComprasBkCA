using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Clientes.Commands.Delete
{
    public class DeleteLogClienteCommandHandler : IRequestHandler<DeleteLogClienteCommand, int>
    {
        private readonly IClienteRepository _entityRepository;

        public DeleteLogClienteCommandHandler(IClienteRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<int> Handle(DeleteLogClienteCommand request, CancellationToken cancellationToken)
        {
            var UpdateEntity = new NegClientes()
            {
                Id = request.Id,
                Estado = false
            };

            return await _entityRepository.UpdateAsync(request.Id, UpdateEntity);
        }
    }
}
