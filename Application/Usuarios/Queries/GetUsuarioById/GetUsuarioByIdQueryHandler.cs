using Application.Usuarios.Queries.GetUsuarios;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Usuarios.Queries.GetUsuarioById
{
    public class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, UsuariosVM>
    {
        private readonly IUsuarioRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetUsuarioByIdQueryHandler(IUsuarioRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<UsuariosVM> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _entityRepository.GetByIdAsync(request.UsuarioId);
            return _mapper.Map<UsuariosVM>(data);
        }
    }
}
