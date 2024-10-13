using Domain.Repository;
using MediatR;

namespace Application.Usuarios.Commands.Delete
{
    public class DeleteLogUsuarioCommandHandler : IRequestHandler<DeleteLogUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _entityRepository;

        public DeleteLogUsuarioCommandHandler(IUsuarioRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<int> Handle(DeleteLogUsuarioCommand request, CancellationToken cancellationToken)
        {
            return await _entityRepository.DeleteAsync(request.Id);
        }
    }
}
