using MediatR;

namespace Application.Ciudades.Queries.GetCiudades
{
    public class GetCiudadQuery : IRequest<List<ConfigVM>>
    {
    }
}
