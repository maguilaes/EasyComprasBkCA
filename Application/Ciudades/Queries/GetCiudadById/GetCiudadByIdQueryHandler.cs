using Application.Ciudades.Queries.GetCiudades;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Ciudades.Queries.GetCiudadById
{
    public class GetCiudadByIdQueryHandler : IRequestHandler<GetCiudadByIdQuery, CiudadVM>
    {
        private readonly ICiudadRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetCiudadByIdQueryHandler(ICiudadRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<CiudadVM> Handle(GetCiudadByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _entityRepository.GetByIdAsync(request.CiudadId);
            return _mapper.Map<CiudadVM>(data);
        }
    }
}
