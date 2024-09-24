using Application.Common.Mappings;
using Domain.Entity;

namespace Application.Clasificadores.Queries.GetClasificadores
{
    public class ClasficadorVM : IMapFrom<BaseClasificadores>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public int IdTipo { get; set; }
    }
}
