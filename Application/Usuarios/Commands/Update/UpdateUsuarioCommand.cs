﻿using MediatR;

namespace Application.Usuarios.Commands.Update
{
    public class UpdateUsuarioCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public int IdcRol { get; set; }
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public bool Estado { get; set; }
        //public int? IdUsuarioRegistro { get; set; }
        //public DateTime? FechaRegistro { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
