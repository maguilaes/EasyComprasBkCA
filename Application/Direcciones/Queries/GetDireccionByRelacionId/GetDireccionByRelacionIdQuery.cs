using Application.DTOs;
using MediatR;

namespace Application.Direcciones.Queries.GetDireccionByRelacionId
{
    public class GetDireccionByRelacionIdQuery : IRequest<DireccionDto>
    {
        public string RelacionId { get; set; }
    }
}
