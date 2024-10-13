namespace Application.DTOs
{
    public class DireccionDto
    {
        public int Id { get; set; }
        public string Pais { get; init; }
        public int IdcPais { get; init; }
        public string Ciudad { get; init; }
        public int IdcCiudad { get; init; }
        public string Telefono { get; set; }
        public string Direccion { get; init; }
        public string? CodigoPostal { get; init; }
        public string? Coordenadas { get; init; }
        public bool Estado { get; init; }
        public string IdRelacion { get; set; }
    }
}
