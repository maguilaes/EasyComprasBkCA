using Application.Configs.Queries.GetConfigs;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Configs.Queries.GetConfigByRecurso
{
    public class GetConfigByRecursoQueryHandler : IRequestHandler<GetConfigByRecursoQuery, ConfigVM>
    {
        private readonly IConfigRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetConfigByRecursoQueryHandler(IConfigRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<ConfigVM> Handle(GetConfigByRecursoQuery request, CancellationToken cancellationToken)
        {
            var data = await _entityRepository.GetByRecursoAsync(request.strRecursto);
            return _mapper.Map<ConfigVM>(data);
        }
    }
}
