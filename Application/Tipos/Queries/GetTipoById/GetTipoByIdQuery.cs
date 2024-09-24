using Application.Tipos.Queries.GetTipos;
using MediatR;

namespace Application.Tipos.Queries.GetTipoById
{
    public class GetTipoByIdQuery : IRequest<TiposVM>
    {
        public int TipoId { get; set; }
    }
}
