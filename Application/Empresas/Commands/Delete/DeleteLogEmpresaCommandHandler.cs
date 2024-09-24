using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Empresas.Commands.Delete
{
    public class DeleteLogEmpresaCommandHandler : IRequestHandler<DeleteLogEmpresaCommand, int>
    {
        private readonly IEmpresaRepository _entityRepository;

        public DeleteLogEmpresaCommandHandler(IEmpresaRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<int> Handle(DeleteLogEmpresaCommand request, CancellationToken cancellationToken)
        {
            var UpdateEntity = new NegEmpresas()
            {
                Id = request.Id,
                Estado = false
            };

            return await _entityRepository.UpdateAsync(request.Id, UpdateEntity);
        }
    }
}
