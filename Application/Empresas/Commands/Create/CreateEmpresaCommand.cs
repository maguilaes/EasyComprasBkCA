using Application.Empresas.Queries.GetEmpresas;
using MediatR;

namespace Application.Empresas.Commands.Create;

public class CreateEmpresaCommand : IRequest<EmpresasVM>
{
    public string NitEmpresa { get; set; }
    public string NombreEmpresa { get; set; }
    public string Email { get; set; }
    public string? Leyenda { get; set; }
    public string? UrlLogo { get; set; }
    public string? NombreContacto { get; set; }
    public string? TelefonoContacto { get; set; }
    public int IdcCategoria { get; set; }
    public bool Estado { get; set; }
    public bool Ubicacion { get; set; }
    public string? Coordenadas { get; init; }
    public int? IdUsuarioRegistro { get; set; }
    public DateTime? FechaRegistro { get; set; }
    //public int? IdUsuarioModificacion { get; set; }
    //public DateTime? FechaModificacion { get; set; }
}

