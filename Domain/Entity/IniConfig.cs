namespace Domain.Entity
{
    public class IniConfig
    {
        public int Id { get; set; }
        public string? Recurso { get; set; }
        public string? Propiedad { get; set; }
        public string? Valor { get; set; }
        public bool Estado { get; set; }
    }
}
