using Application.Clientes.Queries.GetClientes;
using MediatR;

namespace Application.Clientes.Commands.Create;

public class CreateClienteCommand : IRequest<ClientesVM>
{
    public string Documento { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string NombreCompleto { get; set; }
    public string Email { get; set; }
    public int IdSucursal { get; set; }
    public bool Estado { get; set; }
    public int? IdUsuarioRegistro { get; set; }
    public DateTime? FechaRegistro { get; set; }
    public int? IdUsuarioModificacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
}