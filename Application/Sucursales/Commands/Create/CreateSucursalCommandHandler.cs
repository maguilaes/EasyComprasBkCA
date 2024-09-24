using Application.Empresas.Queries.GetEmpresas;
using Application.Sucursales.Queries.GetSucursales;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Sucursales.Commands.Create;

public class CreateSucursalCommandHandler : IRequestHandler<CreateSucursalCommand, SucursalesVM>
{
    private readonly ISucursalRepository _entityRepository;
    private readonly IMapper _mapper;

    public CreateSucursalCommandHandler(ISucursalRepository entityRepository, IMapper mapper)
    {
        _entityRepository = entityRepository;
        _mapper = mapper;
    }

    public async Task<SucursalesVM> Handle(CreateSucursalCommand command, CancellationToken cancellationToken)
    {
        var data = new NegSucursales
        {
            IdcCiudad = command.IdcCiudad,
            NombreSucursal = command.NombreSucursal,
            IdEmpresa = command.IdEmpresa,
            Estado = command.Estado,
            IdUsuarioRegistro = command.IdUsuarioRegistro,
            FechaRegistro = DateTime.UtcNow
        };

        var valor = await _entityRepository.CreateAsync(data);
        if (valor != null)
        {
            return _mapper.Map<SucursalesVM>(data);
        }
        throw new KeyNotFoundException($"Error al insertar {command.NombreSucursal}");
    }
}

