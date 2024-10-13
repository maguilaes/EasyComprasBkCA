using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.CuentaPagos.Commands.Update
{
    public class UpdateCuentaPagoCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string NroCuentaPagos { get; set; }
        public string BancoPagos { get; set; }
        public string NombreTitular { get; set; }
        public string DocumentoTitular { get; set; }
        public string NombreEmpresa { get; set; }
        public IFormFile? UrlQr { get; set; }
        public int IdSucursal { get; set; }
        public bool Estado { get; set; }
        public string? Coordenadas { get; init; }
        public int? IdUsuarioModificacion { get; set; }
    }
}
