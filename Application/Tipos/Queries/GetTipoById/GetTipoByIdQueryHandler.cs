using Application.Tipos.Queries.GetTipos;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Tipos.Queries.GetTipoById
{
    public class GetTipoByIdQueryHandler : IRequestHandler<GetTipoByIdQuery, TiposVM>
    {
        private readonly ITipoRepository _tipoRepository;
        private readonly IMapper _mapper;

        public GetTipoByIdQueryHandler(ITipoRepository blogRepository, IMapper mapper)
        {
            _tipoRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<TiposVM> Handle(GetTipoByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _tipoRepository.GetByIdAsync(request.TipoId);
            return _mapper.Map<TiposVM>(data);
        }
    }
}
