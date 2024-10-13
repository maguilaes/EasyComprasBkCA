using Application.CuentaPagos.Queries.GetCuentaPagos;
using Application.CuentaPagos.Queries.GetCuentaPagosById;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.CuentaPagos.Queries.GetCuentaPagoById
{
    public class GetCuentaPagoByIdQueryHandler : IRequestHandler<GetCuentaPagoByIdQuery, CuentaPagosVM>
    {
        private readonly ICuentaPagoRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetCuentaPagoByIdQueryHandler(ICuentaPagoRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<CuentaPagosVM> Handle(GetCuentaPagoByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _entityRepository.GetByIdAsync(request.CuentaPagoId);
            return _mapper.Map<CuentaPagosVM>(data);
        }
    }
}
