using Domain.Repository;
using MediatR;

namespace Application.Productos.Commands.Delete
{
    public class DeleteLogProductoCommandHandler : IRequestHandler<DeleteLogProductoCommand, int>
    {
        private readonly IProductoRepository _entityRepository;

        public DeleteLogProductoCommandHandler(IProductoRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<int> Handle(DeleteLogProductoCommand request, CancellationToken cancellationToken)
        {
            return await _entityRepository.DeleteAsync(request.Id);
        }
    }
}
