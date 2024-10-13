
namespace Domain.Entity
{
    public class BaseClasificadores
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public int IdTipo { get; set; }

        public async Task ToListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
