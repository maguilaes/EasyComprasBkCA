using Application.Direcciones.Queries.GetDirecciones;
using MediatR;

namespace Application.Direcciones.Queries.GetDireccionById
{
    public class GetDireccionByIdQuery : IRequest<DireccionVM>
    {
        public int DireccionId { get; set; }
    }
}
