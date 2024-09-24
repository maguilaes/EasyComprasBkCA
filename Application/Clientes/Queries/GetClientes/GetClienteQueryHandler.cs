using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Clientes.Queries.GetClientes
{
    public class GetClienteQueryHandler : IRequestHandler<GetClienteQuery, List<ClientesVM>>
    {
        private readonly IClienteRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetClienteQueryHandler(IClienteRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<List<ClientesVM>> Handle(GetClienteQuery request, CancellationToken cancellationToken)
        {
            var resul = await _entityRepository.GetAllAsync();
            //var blogList =  blogs.Select(x => new BlogVm 
            //  { Author = x.Author, Name = x.Name, 
            //      Description = x.Description , Id = x.Id }).ToList();

            var resulList = _mapper.Map<List<ClientesVM>>(resul);
            return resulList;
        }
    }
}
