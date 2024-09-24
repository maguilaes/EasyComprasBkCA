using Application.Clientes.Queries.GetClientes;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Clientes.Queries.GetClienteById
{
    public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, ClientesVM>
    {
        private readonly IClienteRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetClienteByIdQueryHandler(IClienteRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<ClientesVM> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _entityRepository.GetByIdAsync(request.ClienteId);
            return _mapper.Map<ClientesVM>(data);
        }
    }
}
