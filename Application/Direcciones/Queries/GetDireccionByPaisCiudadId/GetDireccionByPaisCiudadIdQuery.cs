using Application.DTOs;
using MediatR;

namespace Application.Direcciones.Queries.GetDireccionByPaisCiudadId
{
    public class GetDireccionByPaisCiudadIdQuery : IRequest<DireccionDto>
    {
        public int? PaisId { get; set; }
        public int? CiudadId { get; set; }
    }
}
