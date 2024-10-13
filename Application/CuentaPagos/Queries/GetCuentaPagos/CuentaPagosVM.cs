using Application.Common.Mappings;
using Domain.Entity;

namespace Application.CuentaPagos.Queries.GetCuentaPagos
{
    public class CuentaPagosVM : IMapFrom<NegCuentaPagos>
    {
        public int Id { get; set; }
        public string NroCuentaPagos { get; set; }
        public string BancoPagos { get; set; }
        public string NombreTitular { get; set; }
        public string DocumentoTitular { get; set; }
        public string? UrlQr { get; set; }
        public int IdSucursal { get; set; }
        public bool Estado { get; set; }
        public int? IdUsuarioRegistro { get; set; }
    }
}
