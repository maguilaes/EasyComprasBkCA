using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.CuentaPagos.Queries.GetCuentaPagos
{
    public class GetCuentaPagoQueryHandler : IRequestHandler<GetCuentaPagoQuery, List<CuentaPagosVM>>
    {
        private readonly ICuentaPagoRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetCuentaPagoQueryHandler(ICuentaPagoRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<List<CuentaPagosVM>> Handle(GetCuentaPagoQuery request, CancellationToken cancellationToken)
        {
            var resul = await _entityRepository.GetAllAsync();
            var resulList = _mapper.Map<List<CuentaPagosVM>>(resul);
            return resulList;
        }
    }
}
