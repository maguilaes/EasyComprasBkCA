using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string Privilegios { get; set; }
        public int IdcRol { get; set; }
        public string Empresa { get; set; }
        public int IdEmpresa { get; set; }
        public string Sucursal { get; set; }
        public int IdSucursal { get; set; }
        public bool Estado { get; set; }
        public int? IdUsuarioRegistro { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
