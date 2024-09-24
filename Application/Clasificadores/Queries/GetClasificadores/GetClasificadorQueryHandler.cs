using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Clasificadores.Queries.GetClasificadores
{
    public class GetClasificadorQueryHandler : IRequestHandler<GetClasificadorQuery, List<ClasficadorVM>>
    {
        private readonly IClasificadorRepository _dataRepository;
        private readonly IMapper _mapper;

        public GetClasificadorQueryHandler(IClasificadorRepository dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }
        public async Task<List<ClasficadorVM>> Handle(GetClasificadorQuery request, CancellationToken cancellationToken)
        {
            var res = await _dataRepository.GetAllAsync();
            //var blogList =  blogs.Select(x => new BlogVm 
            //  { Author = x.Author, Name = x.Name, 
            //      Description = x.Description , Id = x.Id }).ToList();

            var resList = _mapper.Map<List<ClasficadorVM>>(res);
            return resList;
        }
    }
}
