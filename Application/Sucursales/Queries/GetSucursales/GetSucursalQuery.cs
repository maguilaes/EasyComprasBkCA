using MediatR;

namespace Application.Sucursales.Queries.GetSucursales
{
    public class GetSucursalQuery : IRequest<List<SucursalesVM>>
    {
    }
}
