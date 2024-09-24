using AutoMapper;
using Domain.BASDireccion;
using MediatR;

namespace Application.Direcciones.Queries.GetDirecciones
{
    public class GetDireccionQueryHandler : IRequestHandler<GetDireccionQuery, List<DireccionVM>>
    {
        private readonly IDireccionRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetDireccionQueryHandler(IDireccionRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<List<DireccionVM>> Handle(GetDireccionQuery request, CancellationToken cancellationToken)
        {
            var resul = await _entityRepository.GetAllAsync();
            //var blogList =  blogs.Select(x => new BlogVm 
            //  { Author = x.Author, Name = x.Name, 
            //      Description = x.Description , Id = x.Id }).ToList();

            var resulList = _mapper.Map<List<DireccionVM>>(resul);
            return resulList;
        }
    }
}
