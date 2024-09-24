using Application.Ciudades.Queries.GetCiudades;
using MediatR;

namespace Application.Ciudades.Queries.GetCiudadById
{
    public class GetCiudadByIdQuery : IRequest<ConfigVM>
    {
        public int CiudadId { get; set; }
    }
}
