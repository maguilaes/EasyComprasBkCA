using Application.Clasificadores.Queries.GetClasificadores;
using MediatR;

namespace Application.Clasificadores.Queries.GetClasificadorById
{
    public class GetClasificadorByIdQuery : IRequest<ClasficadorVM>
    {
        public int ClasificadorId { get; set; }
    }
}
