using MediatR;

namespace Application.Sucursales.Commands.Update
{
    public class UpdateSucursalCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int IdcCiudad { get; set; }
        public string NombreSucursal { get; set; }
        public bool Estado { get; set; }
        public int IdEmpresa { get; set; }
        //public int? IdUsuarioRegistro { get; set; }
        //public DateTime? FechaRegistro { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
