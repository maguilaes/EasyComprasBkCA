namespace Domain.Entity.Request
{
    public class VentaRequest
    {
        public string DocumentoCliente { get; set; }
        public decimal? Total { get; set; }
        public string Usuario { get; set; }
        //public DateTime? FechaRegistro { get; set; }
        //public int esActivo { get; set; }
        public string? FormaEntrega { get; set; }
        public List<TrxDetalleVentas> CarritoVentas { get; set; }

        public VentaRequest()
        {
            this.CarritoVentas = new List<TrxDetalleVentas>();
        }
    }

    public class TrxDetalleVentas
    {
        //public int DetalleVentaId { get; set; }

        //public int VentaId { get; set; }

        public string CodigoProducto { get; set; }

        public int Cantidad { get; set; }

        //public decimal PrecioUnitario { get; set; }

        //public decimal Total { get; set; }
    }
}
