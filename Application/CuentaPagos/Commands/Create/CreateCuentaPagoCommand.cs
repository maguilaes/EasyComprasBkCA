using Application.CuentaPagos.Queries.GetCuentaPagos;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.CuentaPagos.Commands.Create;

public class CreateCuentaPagoCommand : IRequest<CuentaPagosVM>
{
    public string NroCuentaPagos { get; set; }
    public string BancoPagos { get; set; }
    public string NombreTitular { get; set; }
    public string DocumentoTitular { get; set; }
    public string NombreEmpresa { get; set; }
    public IFormFile UrlQr { get; set; }
    public int IdSucursal { get; set; }
    public bool Estado { get; set; }
    public int? IdUsuarioRegistro { get; set; }
}