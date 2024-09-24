using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Empresas.Queries.GetEmpresas
{
    public class GetEmpresaQueryHandler : IRequestHandler<GetEmpresaQuery, List<EmpresasVM>>
    {
        private readonly IEmpresaRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetEmpresaQueryHandler(IEmpresaRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<List<EmpresasVM>> Handle(GetEmpresaQuery request, CancellationToken cancellationToken)
        {
            var resul = await _entityRepository.GetAllAsync();
            //var blogList =  blogs.Select(x => new BlogVm 
            //  { Author = x.Author, Name = x.Name, 
            //      Description = x.Description , Id = x.Id }).ToList();

            var resulList = _mapper.Map<List<EmpresasVM>>(resul);
            return resulList;
        }
    }
}
