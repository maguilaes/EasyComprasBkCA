using Application.Clasificadores.Queries.GetClasificadores;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Clasificadores.Coomands.Create
{
    public sealed class CreateClasificadorCommandHandler : IRequestHandler<CreateClasificadorCommand, ClasficadorVM>
    {
        private readonly IClasificadorRepository _datRepository;
        private readonly IMapper _mapper;
        public CreateClasificadorCommandHandler(IClasificadorRepository detalleRepository, IMapper mapper)
        {
            _datRepository = detalleRepository ?? throw new ArgumentNullException(nameof(detalleRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<ClasficadorVM> Handle(CreateClasificadorCommand command, CancellationToken cancellationToken)
        {

            var data = new BaseClasificadores
            {
                Descripcion = command.Descripcion,
                Estado = true,
                IdTipo = command.IdTipo
            };

            var valor = await _datRepository.CreateAsync(data);

            if (valor != null)
            {
                return _mapper.Map<ClasficadorVM>(data);
            }
            throw new KeyNotFoundException($"Error al insertar {command.Descripcion}");

        }
    }
}
