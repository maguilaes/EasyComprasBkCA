namespace Domain.Entity
{
    public class IniEmail
    {
        public int Id { get; set; }
        public string Para { get; set; } = string.Empty;
        public string Asunto { get; set; } = string.Empty;
        public string Contenido { get; set; } = string.Empty;
        public bool Estado { get; set; }
    }
}
