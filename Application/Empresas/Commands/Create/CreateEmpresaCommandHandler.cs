using Application.Empresas.Queries.GetEmpresas;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Empresas.Commands.Create;

public class CreateEmpresaCommandHandler : IRequestHandler<CreateEmpresaCommand, EmpresasVM>
{
    private readonly IEmpresaRepository _entityRepository;
    private readonly IMapper _mapper;

    public CreateEmpresaCommandHandler(IEmpresaRepository entityRepository, IMapper mapper)
    {
        _entityRepository = entityRepository;
        _mapper = mapper;
    }

    public async Task<EmpresasVM> Handle(CreateEmpresaCommand command, CancellationToken cancellationToken)
    {
        var data = new NegEmpresas
        {
            NitEmpresa = command.NitEmpresa,
            NombreEmpresa = command.NombreEmpresa,
            Email = command.Email,
            Leyenda = command.Leyenda,
            UrlLogo = command.UrlLogo,
            NombreContacto = command.NombreContacto,
            TelefonoContacto = command.TelefonoContacto,
            IdcCategoria = command.IdcCategoria,
            Ubicacion = command.Ubicacion,
            Estado = command.Estado,
            Coordenadas = command.Coordenadas,
            IdUsuarioRegistro = command.IdUsuarioRegistro,
            FechaRegistro = DateTime.UtcNow
        };

        var valor = await _entityRepository.CreateAsync(data);
        if (valor != null)
        {
            return _mapper.Map<EmpresasVM>(data);
        }
        throw new KeyNotFoundException($"Error al insertar {command.NombreEmpresa}");
    }
}

