using Application.Empresas.Queries.GetEmpresas;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Empresas.Queries.GetEmpresaById
{
    public class GetEmpresaByIdQueryHandler : IRequestHandler<GetEmpresaByIdQuery, EmpresasVM>
    {
        private readonly IEmpresaRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetEmpresaByIdQueryHandler(IEmpresaRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<EmpresasVM> Handle(GetEmpresaByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _entityRepository.GetByIdAsync(request.EmpresaId);
            return _mapper.Map<EmpresasVM>(data);
        }
    }
}
