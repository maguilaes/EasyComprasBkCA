using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Tipos.Queries.GetTipos
{
    public class GetTipoQueryHandler : IRequestHandler<GetTipoQuery, List<TiposVM>>
    {
        private readonly ITipoRepository _tipoRepository;
        private readonly IMapper _mapper;

        public GetTipoQueryHandler(ITipoRepository tipoRepository, IMapper mapper)
        {
            _tipoRepository = tipoRepository;
            _mapper = mapper;
        }
        public async Task<List<TiposVM>> Handle(GetTipoQuery request, CancellationToken cancellationToken)
        {
            var resul = await _tipoRepository.GetAllAsync();
            //var blogList =  blogs.Select(x => new BlogVm 
            //  { Author = x.Author, Name = x.Name, 
            //      Description = x.Description , Id = x.Id }).ToList();

            var resulList = _mapper.Map<List<TiposVM>>(resul);
            return resulList;
        }
    }
}
