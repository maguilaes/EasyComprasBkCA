using Application.Usuarios.Queries.GetUsuarios;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Usuarios.Commands.Create;

public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, UsuariosVM>
{
    private readonly IUsuarioRepository _entityRepository;
    private readonly IMapper _mapper;
    private readonly IHashService _hash;

    public CreateUsuarioCommandHandler(IUsuarioRepository entityRepository, IMapper mapper, IHashService hash)
    {
        _entityRepository = entityRepository;
        _mapper = mapper;
        _hash = hash;
    }

    public async Task<UsuariosVM> Handle(CreateUsuarioCommand command, CancellationToken cancellationToken)
    {
        var data = new SegUsuarios
        {
            NombreCompleto = command.NombreCompleto,
            Email = command.Email,
            Clave = _hash.ConvertirSha256(command.Clave),
            IdcRol = command.IdcRol,
            IdEmpresa = command.IdEmpresa,
            IdSucursal = command.IdSucursal,    
            FechaRegistro = DateTime.Now.Date,
            Estado = command.Estado
        };

        var valor = await _entityRepository.CreateAsync(data);
        if (valor != null)
        {
            return _mapper.Map<UsuariosVM>(data);
        }
        throw new KeyNotFoundException($"Error al insertar {command.NombreCompleto}");
    }
}
