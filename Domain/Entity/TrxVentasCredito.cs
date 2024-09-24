namespace Domain.Entity
{
    public class TrxVentasCredito
    {
        public int Id { get; set; }
        public int IdcEstadoCredito { get; set; }
        public decimal DeudaInicial { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal DeudaActual { get; set; }
        public int IdVenta { get; set; }
        public int? IdUsuarioRegistro { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
