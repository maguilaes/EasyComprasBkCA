using Application.DTOs;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Direcciones.Queries.GetDireccionByRelacionId
{
    public class GetDireccionByRelacionIdQueryHandler : IRequestHandler<GetDireccionByRelacionIdQuery, DireccionDto>
    {
        private readonly IDireccionRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetDireccionByRelacionIdQueryHandler(IDireccionRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<DireccionDto> Handle(GetDireccionByRelacionIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _entityRepository.GetByRelacionIdAsync(request.RelacionId);
            return _mapper.Map<DireccionDto>(data);
        }
    }
}
