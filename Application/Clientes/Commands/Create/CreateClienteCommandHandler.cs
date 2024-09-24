using Application.Clientes.Queries.GetClientes;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Clientes.Commands.Create;

public sealed class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, ClientesVM>
{
    private readonly IClienteRepository _entityRepository;
    private readonly IMapper _mapper;

    public CreateClienteCommandHandler(IClienteRepository entityRepository, IMapper mapper)
    {
        _entityRepository = entityRepository;
        _mapper = mapper;
    }

    public async Task<ClientesVM> Handle(CreateClienteCommand command, CancellationToken cancellationToken)
    {
        var data = new NegClientes
        {
            Documento = command.Documento,
            Nombres = command.Nombres,
            Apellidos = command.Apellidos,
            NombreCompleto = command.Nombres + " " + command.Apellidos,
            Email = command.Email,
            IdUsuarioRegistro = command.IdUsuarioRegistro,
            FechaRegistro = command.FechaRegistro,
            IdSucursal = command.IdSucursal,
            Estado = true
        };

        var valor = await _entityRepository.CreateAsync(data);
        if (valor != null)
        {
            return _mapper.Map<ClientesVM>(data);
        }
        throw new KeyNotFoundException($"Error al insertar {command.NombreCompleto}");
    }
}
