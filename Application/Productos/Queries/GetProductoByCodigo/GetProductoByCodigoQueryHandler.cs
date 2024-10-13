using Application.Productos.Queries.GetProductos;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Productos.Queries.GetProductoByCodigo
{
    public class GetProductoByCodigoQueryHandler : IRequestHandler<GetProductoByCodigoQuery, ProductosVM>
    {
        private readonly IProductoRepository _entityRepository;

        private readonly IMapper _mapper;

        public GetProductoByCodigoQueryHandler(IProductoRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<ProductosVM> Handle(GetProductoByCodigoQuery request, CancellationToken cancellationToken)
        {
            var prod = await _entityRepository.GetByCodigoAsync(request.Codigo);
            return _mapper.Map<ProductosVM>(prod);
        }
    }
}
