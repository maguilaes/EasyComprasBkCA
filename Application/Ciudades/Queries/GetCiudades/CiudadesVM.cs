using Application.Common.Mappings;
using Domain.Entity;

namespace Application.Ciudades.Queries.GetCiudades
{
    public class ConfigVM : IMapFrom<BaseCiudades>
    {
        public int Id { get; set; }
        public string Ciudad { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public int IdcPais { get; set; }
    }
}
