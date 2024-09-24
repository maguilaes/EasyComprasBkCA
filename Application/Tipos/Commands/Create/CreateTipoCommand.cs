using Application.Tipos.Queries.GetTipos;
using MediatR;

namespace Application.Tipos.Commands.Create;
public class CreateTipoCommand : IRequest<TiposVM>
{
    public string Descripcion { get; set; }
    public bool Estado { get; set; }
}


