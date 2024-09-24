using Application.Ciudades.Queries.GetCiudades;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Configs.Queries.GetConfigById
{
    public class GetConfigByIdQueryHandler : IRequestHandler<GetConfigByIdQuery, ConfigVM>
    {
        private readonly IConfigRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetConfigByIdQueryHandler(IConfigRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<ConfigVM> Handle(GetConfigByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _entityRepository.GetByIdAsync(request.ConfigId);
            return _mapper.Map<ConfigVM>(data);
        }
    }
}
