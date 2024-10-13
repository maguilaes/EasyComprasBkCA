using Application.Productos.Queries.GetProductos;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Productos.Queries.GetProductoById
{
    public class GetProductoByIdQueryHandler : IRequestHandler<GetProductoByIdQuery, ProductosVM>
    {
        private readonly IProductoRepository _entityRepository;
        
        private readonly IMapper _mapper;

        public GetProductoByIdQueryHandler(IProductoRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<ProductosVM> Handle(GetProductoByIdQuery request, CancellationToken cancellationToken)
        {
            var prod = await _entityRepository.GetByIdAsync(request.ProductoId);
            return _mapper.Map<ProductosVM>(prod);
        }
    }
}
