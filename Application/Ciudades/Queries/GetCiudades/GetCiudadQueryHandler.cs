using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Ciudades.Queries.GetCiudades
{
    public class GetCiudadQueryHandler : IRequestHandler<GetCiudadQuery, List<CiudadVM>>
    {
        private readonly ICiudadRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetCiudadQueryHandler(ICiudadRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<List<CiudadVM>> Handle(GetCiudadQuery request, CancellationToken cancellationToken)
        {
            var resul = await _entityRepository.GetAllAsync();
            //var blogList =  blogs.Select(x => new BlogVm 
            //  { Author = x.Author, Name = x.Name, 
            //      Description = x.Description , Id = x.Id }).ToList();

            var resulList = _mapper.Map<List<CiudadVM>>(resul);
            return resulList;
        }
    }
}
