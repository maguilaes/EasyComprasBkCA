using Application.Clasificadores.Queries.GetClasificadores;
using MediatR;

namespace Application.Clasificadores.Queries.GetClasificadorByTipoId
{
    public class GetClasificadorByTipoIdQuery : IRequest<ClasficadorVM>
    {
        public int TipoId { get; set; }
    }
}
