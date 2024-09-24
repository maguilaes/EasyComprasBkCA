using Application.Tipos.Queries.GetTipos;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Tipos.Commands.Create
{
    public class CreateTipoCommandHandler : IRequestHandler<CreateTipoCommand, TiposVM> // : IRequestHandler<CreateCatalogoMaestroCommand, Unit>
    {
        private readonly ITipoRepository _tipoRepository;
        private readonly IMapper _mapper;
        public CreateTipoCommandHandler(ITipoRepository tipoRepository, IMapper mapper)
        {
            _tipoRepository = tipoRepository;
            _mapper = mapper;
        }
        public async Task<TiposVM> Handle(CreateTipoCommand command, CancellationToken cancellationToken)
        {

            var data = new BaseTipos()
            {
                Descripcion = command.Descripcion,
                Estado = true,
            };

            var valor = await _tipoRepository.CreateAsync(data);
            if (valor != null)
            {
                return _mapper.Map<TiposVM>(data);
            }
            throw new KeyNotFoundException($"Error al insertar {command.Descripcion}");
        }
    }
}
