using Application.Ciudades.Queries.GetCiudades;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Ciudades.Queries.GetCiudadByPaisId
{
    public class GetCiudadByPaisIdQueryHandler : IRequestHandler<GetCiudadByPaisIdQuery, CiudadVM>
    {
        private readonly ICiudadRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetCiudadByPaisIdQueryHandler(ICiudadRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<CiudadVM> Handle(GetCiudadByPaisIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _entityRepository.GetByIdAsync(request.PaisId);
            return _mapper.Map<CiudadVM>(data);
        }
    }
}
