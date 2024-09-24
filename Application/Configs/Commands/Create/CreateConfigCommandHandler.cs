using Application.Configs.Queries.GetConfigs;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Configs.Commands.Create;

public class CreateConfigCommandHandler : IRequestHandler<CreateConfigCommand, ConfigVM>
{
    private readonly IConfigRepository _entityRepository;
    private readonly IMapper _mapper;

    public CreateConfigCommandHandler(IConfigRepository entityRepository, IMapper mapper)
    {
        _entityRepository = entityRepository;
        _mapper = mapper;
    }

    public async Task<ConfigVM> Handle(CreateConfigCommand command, CancellationToken cancellationToken)
    {
        var data = new IniConfig
        {
            Recurso = command.Recurso,
            Propiedad = command.Propiedad,
            Valor = command.Valor,
            Estado = command.Estado
        };

        var valor = await _entityRepository.CreateAsync(data);
        if (valor != null)
        {
            return _mapper.Map<ConfigVM>(data);
        }
        throw new KeyNotFoundException($"Error al insertar {command.Recurso}");
    }
}

