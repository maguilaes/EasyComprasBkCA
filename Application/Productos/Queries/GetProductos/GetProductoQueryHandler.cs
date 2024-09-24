using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Productos.Queries.GetProductos
{
    public class GetProductoEmpresaQueryHandler : IRequestHandler<GetProductoQuery, List<ProductosVM>>
    {
        private readonly IProductoRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetProductoEmpresaQueryHandler(IProductoRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductosVM>> Handle(GetProductoQuery request, CancellationToken cancellationToken)
        {
            var resul = await _entityRepository.GetAllAsync();
            //var blogList =  blogs.Select(x => new BlogVm 
            //  { Author = x.Author, Name = x.Name, 
            //      Description = x.Description , Id = x.Id }).ToList();

            var resulList = _mapper.Map<List<ProductosVM>>(resul);
            return resulList;
        }
    }
}
