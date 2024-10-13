using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Empresas.Commands.Update
{
    public class UpdateEmpresaCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string NitEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string Email { get; set; }
        public string? Leyenda { get; set; }
        public IFormFile? UrlLogo { get; set; }
        public string? NombreContacto { get; set; }
        public string? TelefonoContacto { get; set; }
        public int IdcCategoria { get; set; }
        public bool Estado { get; set; }
        public bool Ubicacion { get; set; }
        public string? Coordenadas { get; init; }
        public int? IdUsuarioModificacion { get; set; }
    }
}
