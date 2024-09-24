using Application.Direcciones.Queries.GetDirecciones;
using AutoMapper;
using Domain.BASDireccion;
using MediatR;

namespace Application.Direcciones.Queries.GetDireccionById
{
    public class GetDireccionByIdQueryHandler : IRequestHandler<GetDireccionByIdQuery, DireccionVM>
    {
        private readonly IDireccionRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetDireccionByIdQueryHandler(IDireccionRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<DireccionVM> Handle(GetDireccionByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _entityRepository.GetByIdAsync(request.DireccionId);
            return _mapper.Map<DireccionVM>(data);
        }
    }
}
