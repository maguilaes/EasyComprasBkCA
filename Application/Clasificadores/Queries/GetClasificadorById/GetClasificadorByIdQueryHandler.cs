using Application.Clasificadores.Queries.GetClasificadores;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Clasificadores.Queries.GetClasificadorById
{
    public class GetClasificadorByIdQueryHandler : IRequestHandler<GetClasificadorByIdQuery, ClasficadorVM>
    {
        private readonly IClasificadorRepository _dataRepository;
        private readonly IMapper _mapper;

        public GetClasificadorByIdQueryHandler(IClasificadorRepository dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }
        public async Task<ClasficadorVM> Handle(GetClasificadorByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _dataRepository.GetByIdAsync(request.ClasificadorId);
            return _mapper.Map<ClasficadorVM>(data);
        }
    }
}
