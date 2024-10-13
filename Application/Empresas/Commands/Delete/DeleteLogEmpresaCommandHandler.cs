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
            return await _entityRepository.DeleteAsync(request.Id);
        }
    }
}
