using Domain.Entity;
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
            var UpdateEntity = new NegProductos()
            {
                Id = request.Id,
                Estado = false
            };

            return await _entityRepository.UpdateAsync(request.Id, UpdateEntity);
        }
    }
}
