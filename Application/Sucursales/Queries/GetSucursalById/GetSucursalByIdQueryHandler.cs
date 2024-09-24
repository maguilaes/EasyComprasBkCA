using Application.Sucursales.Queries.GetSucursalById;
using Application.Sucursales.Queries.GetSucursales;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Sucursales.Queries.GetsucursalById
{
    public class GetSucursalByIdQueryHandler : IRequestHandler<GetSucursalByIdQuery, SucursalesVM>
    {
        private readonly IEmpresaRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetSucursalByIdQueryHandler(IEmpresaRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<SucursalesVM> Handle(GetSucursalByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _entityRepository.GetByIdAsync(request.SucursalId);
            return _mapper.Map<SucursalesVM>(data);
        }
    }
}
