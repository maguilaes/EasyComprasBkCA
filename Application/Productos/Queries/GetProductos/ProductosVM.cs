﻿using Application.Common.Mappings;
using Domain.Entity;
using Microsoft.AspNetCore.Http;

namespace Application.Productos.Queries.GetProductos
{
    public class ProductosVM : IMapFrom<NegProductos>
    {
        public int Id { get; set; }
        public int IdSucursal { get; set; }
        public int IdcCategoria { get; set; }
        public string Codigo { get; set; }
        public string? NombreProducto { get; set; }
        public string? Descripcion { get; set; }
        public int Stock { get; set; }
        public int IdcMedida { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public string? UrlImagen { get; set; }
        //public string? NombreEmpresa { get; set; }
        //public string? CarpetaDestino { get; set; }
        public bool Estado { get; set; }
        public int? IdUsuarioRegistro { get; set; }
        public DateTime? FechaRegistro { get; set; }
        //public int? IdUsuarioModificacion { get; set; }
        //public DateTime? FechaModificacion { get; set; }
    }
}
