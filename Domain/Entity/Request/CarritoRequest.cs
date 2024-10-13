namespace Domain.Entity.Request
{
    public class CarritoRequest
    {
        public List<TrxDetalleVentas> ProductoLista { get; set; }

        public CarritoRequest()
        {
            this.ProductoLista = new List<TrxDetalleVentas>();
        }

        public class TrxDetalleVentas
        {
            public string CodigoProducto { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public int IdMedida { get; set; }
            public decimal PrecioUnitario { get; set; }
            public int Cantidad { get; set; }
            public decimal SubTotal { get; set; }
            public int IdVenta { get; set; }
        }
    }
}
