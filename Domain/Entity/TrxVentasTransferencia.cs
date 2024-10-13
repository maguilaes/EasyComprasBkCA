namespace Domain.Entity
{
    public class TrxVentasTransferencia
    {
        public int Id { get; set; }
        public int IdcEstadoTransferencia { get; set; }
        public int IdCliente { get; set; }
        public decimal MontoTransferencia { get; set; }
        public string? UrlComprobante { get; set; }
        public decimal MontoRecibido { get; set; }
        public string? Comentarios { get; set; }
        public int IdVenta { get; set; }
        public int? IdUsuarioRegistro { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public bool Estado { get; set; }
    }
}
