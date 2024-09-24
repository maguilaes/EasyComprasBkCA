namespace Domain.Entity
{
    public class BaseCiudades
    {
        public int Id { get; set; }
        public string Ciudad { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public int IdcPais { get; set; }
    }
}
