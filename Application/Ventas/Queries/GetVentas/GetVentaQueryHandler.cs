using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Ventas.Queries.GetVentas
{
    internal class GetVentaQueryHandler : IRequestHandler<GetVentaQuery, List<VentasVM>>
    {
        private readonly IClienteRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetVentaQueryHandler(IClienteRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<List<VentasVM>> Handle(GetVentaQuery request, CancellationToken cancellationToken)
        {
            var resul = await _entityRepository.GetAllAsync();
            //var blogList =  blogs.Select(x => new BlogVm 
            //  { Author = x.Author, Name = x.Name, 
            //      Description = x.Description , Id = x.Id }).ToList();

            var resulList = _mapper.Map<List<VentasVM>>(resul);
            return resulList;
        }
    }
}
