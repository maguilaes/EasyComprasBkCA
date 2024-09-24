using MediatR;

namespace Application.Direcciones.Queries.GetDirecciones
{
    public class GetDireccionQuery : IRequest<List<DireccionVM>>
    {
    }
}
