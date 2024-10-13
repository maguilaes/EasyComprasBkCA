namespace Domain.Entity
{
    public class TrxVentas
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string? Coordenadas { get; set; }
        public int IdcFormaEntrega { get; set; }
        public int IdcFormaPago { get; set; }
        public int IdcEstadoPago { get; set; }
        public int IdcEstadoVenta { get; set; }
        public int IdSucursal { get; set; }
        public decimal MontoVenta { get; set; }
        public int? IdUsuarioRegistro { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public bool Estado { get; set; }
    }
}
