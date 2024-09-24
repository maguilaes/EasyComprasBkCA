using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Configs.Queries.GetConfigs
{
    public class GetConfigQueryHandler : IRequestHandler<GetConfigQuery, List<ConfigVM>>
    {
        private readonly IConfigRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetConfigQueryHandler(IConfigRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<List<ConfigVM>> Handle(GetConfigQuery request, CancellationToken cancellationToken)
        {
            var resul = await _entityRepository.GetAllAsync();
            //var blogList =  blogs.Select(x => new BlogVm 
            //  { Author = x.Author, Name = x.Name, 
            //      Description = x.Description , Id = x.Id }).ToList();

            var resulList = _mapper.Map<List<ConfigVM>>(resul);
            return resulList;
        }
    }
}
