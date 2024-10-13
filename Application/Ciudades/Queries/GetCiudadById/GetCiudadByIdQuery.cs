using Application.Ciudades.Queries.GetCiudades;
using MediatR;

namespace Application.Ciudades.Queries.GetCiudadById
{
    public class GetCiudadByIdQuery : IRequest<CiudadVM>
    {
        public int CiudadId { get; set; }
    }
}
