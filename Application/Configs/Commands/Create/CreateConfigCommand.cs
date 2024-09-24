﻿using Application.Configs.Queries.GetConfigs;
using MediatR;

namespace Application.Configs.Commands.Create;

public class CreateConfigCommand : IRequest<ConfigVM>
{
    public string? Recurso { get; set; }
    public string? Propiedad { get; set; }
    public string? Valor { get; set; }
    public bool Estado { get; set; }
}

