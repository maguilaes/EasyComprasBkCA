using Application.Ciudades.Queries.GetCiudades;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Ciudades.Commands.Create;

public class CreateCiudadCommandHandler : IRequestHandler<CreateCiudadCommand, CiudadVM>
{
    private readonly ICiudadRepository _entityRepository;
    private readonly IMapper _mapper;

    public CreateCiudadCommandHandler(ICiudadRepository entityRepository, IMapper mapper)
    {
        _entityRepository = entityRepository;
        _mapper = mapper;
    }

    public async Task<CiudadVM> Handle(CreateCiudadCommand command, CancellationToken cancellationToken)
    {
        var data = new BaseCiudades
        {
            IdcPais = command.IdcPais,
            Ciudad = command.Ciudad,
            Estado = command.Estado
        };

        var valor = await _entityRepository.CreateAsync(data);
        if (valor != null)
        {
            return _mapper.Map<CiudadVM>(data);
        }
        throw new KeyNotFoundException($"Error al insertar {command.Ciudad}");
    }
}

