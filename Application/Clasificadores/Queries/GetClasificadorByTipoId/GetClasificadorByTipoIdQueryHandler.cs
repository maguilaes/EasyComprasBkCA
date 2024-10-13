using Application.Clasificadores.Queries.GetClasificadores;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Clasificadores.Queries.GetClasificadorByTipoId
{
    public class GetClasificadorByTipoIdQueryHandler : IRequestHandler<GetClasificadorByTipoIdQuery, ClasficadorVM>
    {
        private readonly IClasificadorRepository _dataRepository;
        private readonly IMapper _mapper;

        public GetClasificadorByTipoIdQueryHandler(IClasificadorRepository dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }
        public async Task<ClasficadorVM> Handle(GetClasificadorByTipoIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _dataRepository.GetByIdAsync(request.TipoId);
            return _mapper.Map<ClasficadorVM>(data);
        }
    }
}
