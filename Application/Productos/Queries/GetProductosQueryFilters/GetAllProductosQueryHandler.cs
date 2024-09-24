using Application.DTOs;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Productos.Queries.GetProductosQueryFilters
{
    public class GetAllProductosQueryHandler : IRequestHandler<GetAllProductosQuery, List<ProductosDto>>
    {
        private readonly IProductoRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetAllProductosQueryHandler(IProductoRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductosDto>> Handle(GetAllProductosQuery request, CancellationToken cancellationToken)
        {
            var resul = await _entityRepository.GetAllAsync();
            //var blogList =  blogs.Select(x => new BlogVm 
            //  { Author = x.Author, Name = x.Name, 
            //      Description = x.Description , Id = x.Id }).ToList();

            var resulList = _mapper.Map<List<ProductosDto>>(resul);
            return resulList;
        }
    }
}
