using Application.Ciudades.Queries.GetCiudades;
using MediatR;

namespace Application.Ciudades.Commands.Create;

public class CreateCiudadCommand : IRequest<ConfigVM>
{
    public string Ciudad { get; set; } = string.Empty;
    public bool Estado { get; set; }
    public int IdcPais { get; set; }
}

