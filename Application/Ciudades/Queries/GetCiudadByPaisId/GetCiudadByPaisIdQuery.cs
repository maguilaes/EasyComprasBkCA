using Application.Ciudades.Queries.GetCiudades;
using MediatR;

namespace Application.Ciudades.Queries.GetCiudadByPaisId
{
    public class GetCiudadByPaisIdQuery : IRequest<CiudadVM>
    {
        public int PaisId { get; set; }
    }
}
