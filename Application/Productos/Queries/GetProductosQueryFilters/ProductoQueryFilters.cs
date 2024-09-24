namespace Application.Productos.Queries.GetProductosQueryFilters
{
    public class ProductoQueryFilters
    {
        public int? SucursalId { get; set; }
        public int? CategoriaId { get; set; }
        public string? NombreProducto { get; set; }
        //public string? Descripcion { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
