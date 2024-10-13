using Application.DTOs;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Direcciones.Queries.GetDireccionByPaisCiudadId
{
    public class GetDireccionByPaisCiudadIdQueryHandler : IRequestHandler<GetDireccionByPaisCiudadIdQuery, DireccionDto>
    {
        private readonly IDireccionRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetDireccionByPaisCiudadIdQueryHandler(IDireccionRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<DireccionDto> Handle(GetDireccionByPaisCiudadIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _entityRepository.GetAllAsync();
            return _mapper.Map<DireccionDto>(data);
        }
    }
}
