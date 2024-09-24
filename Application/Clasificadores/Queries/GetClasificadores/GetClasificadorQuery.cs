using MediatR;

namespace Application.Clasificadores.Queries.GetClasificadores
{
    public class GetClasificadorQuery : IRequest<List<ClasficadorVM>>
    {
    }
}
