using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Productos.Commands.UpdateStock
{
    public class UpdateProductoStockCommandHandler : IRequestHandler<UpdateProductoStockCommand, int>
    {
        private readonly IProductoRepository _entityRepository;
        private readonly IFireBaseService _firebaseService;

        public UpdateProductoStockCommandHandler(IProductoRepository entityRepository, IFireBaseService firebaseService)
        {
            _entityRepository = entityRepository;
            _firebaseService = firebaseService;
        }
        public async Task<int> Handle(UpdateProductoStockCommand request, CancellationToken cancellationToken)
        {
            var UpdateEntity = new NegProductos()
            {
                Id = request.Id,
                Codigo = request.Codigo,
                Stock = request.Stock,
                IdUsuarioModificacion = request.IdUsuarioRegistro,
                FechaModificacion = DateTime.Now.Date
            };

            return await _entityRepository.UpdateStockAsync(request.Id, UpdateEntity);
        }
    }
}
