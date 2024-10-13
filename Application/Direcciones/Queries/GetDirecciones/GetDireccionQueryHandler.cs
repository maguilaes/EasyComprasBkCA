using Application.DTOs;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Direcciones.Queries.GetDirecciones
{
    public class GetDireccionQueryHandler : IRequestHandler<GetDireccionQuery, List<DireccionDto>>
    {
        private readonly IDireccionRepository _entityRepository;
        private readonly ICiudadRepository _ciudadRepository;
        private readonly IClasificadorRepository _clasificadorRepository;
        private readonly IMapper _mapper;

        public GetDireccionQueryHandler(IDireccionRepository entityRepository, IMapper mapper, ICiudadRepository ciudadRepository, IClasificadorRepository clasificadorRepository)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
            _ciudadRepository = ciudadRepository;
            _clasificadorRepository = clasificadorRepository;
        }
        public async Task<List<DireccionDto>> Handle(GetDireccionQuery request, CancellationToken cancellationToken)
        {
            var pais = await _clasificadorRepository.GetByTipoIdAsync(2);
            var ciudad = await _ciudadRepository.GetAllAsync();
            var resul = await _entityRepository.GetAllAsync();
            //var blogList =  blogs.Select(x => new BlogVm 
            //  { Author = x.Author, Name = x.Name, 
            //      Description = x.Description , Id = x.Id }).ToList();

            var resulList = _mapper.Map<List<DireccionDto>>(resul);
            return resulList;
        }
    }
}
