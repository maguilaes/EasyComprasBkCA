using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Sucursales.Queries.GetSucursales
{
    public class GetSucursalQueryHandler : IRequestHandler<GetSucursalQuery, List<SucursalesVM>>
    {
        private readonly IEmpresaRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetSucursalQueryHandler(IEmpresaRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<List<SucursalesVM>> Handle(GetSucursalQuery request, CancellationToken cancellationToken)
        {
            var resul = await _entityRepository.GetAllAsync();
            //var blogList =  blogs.Select(x => new BlogVm 
            //  { Author = x.Author, Name = x.Name, 
            //      Description = x.Description , Id = x.Id }).ToList();

            var resulList = _mapper.Map<List<SucursalesVM>>(resul);
            return resulList;
        }
    }
}
