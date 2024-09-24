using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Usuarios.Queries.GetUsuarios
{
    public class GetUsuarioQueryHandler : IRequestHandler<GetUsuarioQuery, List<UsuariosVM>>
    {
        private readonly IUsuarioRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetUsuarioQueryHandler(IUsuarioRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<List<UsuariosVM>> Handle(GetUsuarioQuery request, CancellationToken cancellationToken)
        {
            var resul = await _entityRepository.GetAllAsync();
            //var blogList =  blogs.Select(x => new BlogVm 
            //  { Author = x.Author, Name = x.Name, 
            //      Description = x.Description , Id = x.Id }).ToList();

            var resulList = _mapper.Map<List<UsuariosVM>>(resul);
            return resulList;
        }
    }
}
