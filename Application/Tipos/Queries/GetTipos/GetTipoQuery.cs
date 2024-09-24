using MediatR;

namespace Application.Tipos.Queries.GetTipos
{
    public class GetTipoQuery : IRequest<List<TiposVM>>
    {
    }
}
