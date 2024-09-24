using Application.Sucursales.Queries.GetSucursales;
using MediatR;

namespace Application.Sucursales.Commands.Create;

public class CreateSucursalCommand : IRequest<SucursalesVM>
{
    public int IdcCiudad { get; set; }
    public string NombreSucursal { get; set; }
    public bool Estado { get; set; }
    public int IdEmpresa { get; set; }
    public int? IdUsuarioRegistro { get; set; }
    public DateTime? FechaRegistro { get; set; }
}

