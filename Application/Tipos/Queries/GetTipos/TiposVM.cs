using Application.Common.Mappings;
using Domain.Entity;

namespace Application.Tipos.Queries.GetTipos
{
    public class TiposVM : IMapFrom<BaseTipos>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
