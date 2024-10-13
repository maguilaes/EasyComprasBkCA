using Application.Direcciones.Queries.GetDirecciones;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Direcciones.Commands.Create;

public class CreateDireccionCommandHandler : IRequestHandler<CreateDireccionCommand, DireccionVM>
{
    private readonly IDireccionRepository _entityRepository;
    private readonly IMapper _mapper;

    public CreateDireccionCommandHandler(IDireccionRepository entityRepository, IMapper mapper)
    {
        _entityRepository = entityRepository;
        _mapper = mapper;
    }

    public async Task<DireccionVM> Handle(CreateDireccionCommand command, CancellationToken cancellationToken)
    {
        switch (command.IdRelacion)
        {
            case "Empresa":
                break;
            case "Sucursal":
                break;
            default:
                break;
        }
        var data = new BaseDirecciones
        {
            IdcPais = command.IdcPais,
            IdcCiudad = command.IdcCiudad,
            Telefono = command.Telefono,
            Direccion = command.Direccion,
            CodigoPostal = command.CodigoPostal,
            Coordenadas = command.Coordenadas,
            Estado = true,
            IdRelacion = command.IdRelacion
        };

        var valor = await _entityRepository.CreateAsync(data);
        if (valor != null)
        {
            return _mapper.Map<DireccionVM>(data);
        }
        throw new KeyNotFoundException($"Error al insertar {command.Direccion}");
    }
}

