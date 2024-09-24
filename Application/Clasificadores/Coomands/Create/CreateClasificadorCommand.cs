using Application.Clasificadores.Queries.GetClasificadores;
using MediatR;

namespace Application.Clasificadores.Coomands.Create;
public class CreateClasificadorCommand : IRequest<ClasficadorVM>
{
    public string Descripcion { get; set; }
    public int IdTipo { get; set; }
    public bool Estado { get; set; }
}


