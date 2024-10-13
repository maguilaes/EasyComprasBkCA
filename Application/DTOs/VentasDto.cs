namespace Application.DTOs
{
    public class VentasDto
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        //public string NombreCliente { get; set; }
        public string Coordenadas { get; set; }
        public int IdcFormaEntrega { get; set; }
        //public string FormaEntrega { get; set; }
        public int IdcFormaPago { get; set; }
        //public string FormaPago { get; set; }
        public int IdcEstadoPago { get; set; }
        //public string EstadoPago { get; set; }
        public int IdcEstadoVenta { get; set; }
        //public string EstadoVenta { get; set; }
        public int IdSucursal { get; set; }
        public int? IdUsuarioRegistro { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public bool Estado { get; set; }
    }
}
